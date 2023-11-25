using System.Diagnostics;
using System.Media;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maze
{
    public partial class LevelForm : Form
    {
        public Maze maze; // ссылка на логику всего происходящего в лабиринте
        public Character Hero;
        private bool _gameEnded = false;
        public SoundPlayer PickUpSound = new SoundPlayer(Properties.Resources.item_pick_up);

        public LevelForm()
        {
            InitializeComponent();
            FormSettings();
            StartGameProcess();
            StatusLabelHP.BackColor = Color.White;
            StatusLabelStepCount.BackColor = Color.White;
        }

        public void FormSettings()
        {
            Text = Configuration.Title;
            BackColor = Configuration.Background;

            // размеры клиентской области формы
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
                    newX++;
                    break;

                case Keys.Left:
                    newX--;
                    break;

                case Keys.Up:
                    newY--;
                    break;

                case Keys.Down:
                    newY++;
                    break;
            }

            // Если выходит за границы поля
            if (newX < 0 || newY < 0 || newX > Configuration.Columns - 1 || newY > Configuration.Rows - 1) return;

            Cell destCell = maze.cells[newY, newX];

            switch (destCell.Type)
            {
                case CellType.WALL:
                    return;

                case CellType.EXIT:
                    EndGame();
                    MessageBox.Show("Вы победили!");
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
                    PickUpSound.Play();
                    Hero.GetRandomWeapon();
                    break;

                case CellType.MEDAL:
                    PickUpSound.Play();
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
            StatusLabelStepCount.Text = "Steps: " + hero.StepCount;
        }

        public void EndGame()
        {
            _gameEnded = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            StatusLabelHP.ForeColor = StatusLabelHP.ForeColor == Color.White ? Color.Red : Color.White;
        }
    }
}