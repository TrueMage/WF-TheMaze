using System.ComponentModel;
using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Maze
{
    public partial class LevelForm : Form
    {
        public bool SoundEffectOn = true;
        public bool MusicOn = true;

        public Maze maze; // ������ �� ������ ����� ������������� � ���������
        public Character Hero;
        private bool _gameEnded = false;

        // ������ SoundPlayer �� ����� ������ 2 ������������ ?! ������
        public WMPLib.WindowsMediaPlayer CaveMusic = new WMPLib.WindowsMediaPlayer();
        public SoundPlayer PickUpSound = new SoundPlayer(Properties.Resources.item_pick_up);
        public SoundPlayer Victory = new SoundPlayer(Properties.Resources.victory);

        public LevelForm()
        {
            InitializeComponent();
            FormSettings();
            StartGameProcess();
            statusStrip1.BackColor = Color.White;
            statusStrip1.ShowItemToolTips = true;

            CaveMusic.URL = Path.GetFullPath("../../../Resources/Caves.wav");
            //CaveMusic.URL = Properties.Resources.Caves - �����, ������� �� �������� ��-�� ������ WMP
            CaveMusic.settings.setMode("loop", true);
        }

        public void FormSettings()
        {
            Text = Configuration.Title;
            BackColor = Configuration.Background;

            // ������� ���������� ������� �����
            ClientSize = new Size(
                Configuration.Columns * Configuration.PictureSide,
                Configuration.Rows * Configuration.PictureSide + 20);

            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGameProcess()
        {
            Hero = new Character(this);
            maze = new Maze(this);
            maze.Generate();
            maze.Show();
        }

        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (_gameEnded) return;

            ushort newX = Hero.PosX;
            ushort newY = Hero.PosY;

            switch (e.KeyCode)
            {
                case Keys.Right:
                case Keys.D:
                    newX++;
                    break;

                case Keys.Left:
                case Keys.A:
                    newX--;
                    break;

                case Keys.Up:
                case Keys.W:
                    newY--;
                    break;

                case Keys.Down:
                case Keys.S:
                    newY++;
                    break;
                case Keys.Enter:
                    Hero.Shoot();
                    return;
            }

            // ���� ������� �� ������� ����
            if (newX < 0 || newY < 0 || newX > Configuration.Columns - 1 || newY > Configuration.Rows - 1) return;

            Cell destCell = maze.cells[newY, newX];

            switch (destCell.Type)
            {
                case CellType.WALL:
                    return;

                case CellType.EXIT:
                    EndGame();
                    CaveMusic.controls.stop();
                    Victory.Play();
                    VictoryForm vf = new VictoryForm(this);
                    vf.Show();
                    break;

                case CellType.HALL:
                    break;

                case CellType.ENEMY:
                    Hero.GetAttacked();
                    if (_gameEnded) return;
                    break;

                case CellType.HEALING_POTION:
                    Hero.GetHealed();
                    break;

                case CellType.WEAPON_CRATE:
                    if (SoundEffectOn) PickUpSound.Play();
                    Hero.GetRandomWeapon();
                    break;

                case CellType.MEDAL:
                    if (SoundEffectOn) PickUpSound.Play();
                    Hero.GetMedal();
                    break;
            }

            Hero.Clear();
            Hero.MoveTo(newX, newY);
            Hero.Show();
        }

        private void LevelForm_Load(object sender, EventArgs e)
        {

        }

        public void UpdateStatusBar(Character hero)
        {
            if (hero.Health < 50)
            {
                StatusLabelHP.ForeColor = Color.Red;
                timer1.Enabled = true;
            }
            else
            {
                StatusLabelHP.ForeColor = Color.Black;
                timer1.Enabled = false;
            }
            StatusLabelHP.Text = hero.Health + " HP";
            StatusLabelStepCount.Text = hero.StepCount.ToString();
            StatusLabelEnergy.Text = hero.Energy.ToString();
        }

        public void EndGame()
        {
            _gameEnded = true;
        }

        public void RestartGame()
        {
            timer1.Enabled = false;
            StatusLabelHP.ForeColor = Color.Black;
            _gameEnded = false;
            Controls.Clear();

            StatusStrip statusstrip = statusStrip1;
            Controls.Add(statusstrip);
            PistolIcon.Enabled = true;
            PistolIcon.Visible = false;

            if (CaveMusic.status != "playing" && MusicOn) CaveMusic.controls.play();
            StartGameProcess();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusLabelHP.ForeColor = StatusLabelHP.ForeColor == Color.White ? Color.Red : Color.White;
        }

        private void SoundSettingMenuItem_Click(object sender, EventArgs e)
        {
            SoundEffectOn = !SoundEffectOn;
            SoundSettingMenuItem.Checked = SoundEffectOn;
        }

        private void MusicSettingMenuItem_Click(object sender, EventArgs e)
        {
            MusicOn = !MusicOn;
            MusicSettingMenuItem.Checked = MusicOn;
            if (MusicOn) CaveMusic.controls.play();
            else CaveMusic.controls.stop();
        }

        private void StripStatusRestart_Click(object sender, EventArgs e)
        {
            RestartGame();
        }
    }
}