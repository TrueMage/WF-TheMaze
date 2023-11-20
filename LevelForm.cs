using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Maze
{
    public partial class LevelForm : Form
    {
        public Maze maze; // ссылка на логику всего происходящего в лабиринте
        public Character Hero;
        private bool _gameEnded = false;

        public LevelForm()
        {
            InitializeComponent();
            FormSettings();
            StartGameProcess();
            //this.Text += " 100 HP";
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
            if(newX < 0 || newY < 0 || newX > Configuration.Columns-1 || newY > Configuration.Rows - 1) return;

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
                    break;

                case CellType.HEALING_POTION:
                    Hero.GetHealed();
                    break;

                case CellType.MEDAL:
                    break;
            }

            Hero.Clear();
            Hero.MoveTo(newX, newY);
            Hero.Show();

        }

        private void LevelForm_Load(object sender, EventArgs e)
        {

        }

        public void UpdateHealth(int health)
        {
            //this.Text = "Maze " + health + "HP";
            StatusLabelHP.Text = health + "HP";
        }

        public void UpdateStepCount(int step)
        {
            //this.Text = "Maze " + health + "HP";
            StatusLabelStepCount.Text = "Steps: " + step;
        }

        public void EndGame()
        {
            _gameEnded = true;
        }
    }
}