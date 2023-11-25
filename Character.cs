using System.Media;

namespace Maze
{
    public class Character
    {
        Random r = new Random();

        private int _health = 100;
        private int _stepcount = 0;
        private int _energy = 500;
        private Weapon _weapon;
        SoundPlayer GameOverSound = new SoundPlayer(Properties.Resources.game_over);

        // позиция главного персонажа

        public int Health
        {
            get
            {
                return _health;
            }
        }

        public int StepCount
        {
            get
            {
                return _stepcount;
            }
        }

        public ushort PosX { get; set; }
        public ushort PosY { get; set; }
        public LevelForm Parent { get; set; }

        public Character(LevelForm parent)
        {
            PosX = 0;
            PosY = 2; // Convert.ToUInt16(r.Next(2, Configuration.Rows-2))
            Parent = parent;
        }

        public void Clear()
        {
            Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage =
                Parent.maze.cells[PosY, PosX].Texture =
                Cell.Images[(int)(Parent.maze.cells[PosY, PosX].Type = CellType.HALL)];
        }

        public void MoveTo(ushort PosX, ushort PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;

            _stepcount++;
            _energy--;

            if (_stepcount % 20 == 0)
            {
                Parent.maze.SpawnEnemies(300);
            }

            Parent.UpdateStatusBar(this);
        }

        public void GetAttacked()
        {
            _health -= 25;
            Parent.UpdateStatusBar(this);

            if (_health <= 0)
            {
                GameOverSound.Play();
                Parent.EndGame();
                Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage = Properties.Resources.player_with_blackeye;
                MessageBox.Show("У вас закончилось здоровье. Вы проиграли");
            }
        }

        public void GetHealed()
        { 
            if(_health >= 100) return;
            Parent.PickUpSound.Play();
            _health += 25;
            Parent.UpdateStatusBar(this);
        }

        public void GetRandomWeapon()
        {

        }

        public void Show()
        {
            Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage =
                Parent.maze.cells[PosY, PosX].Texture =
                Cell.Images[(int)(Parent.maze.cells[PosY, PosX].Type = CellType.HERO)];
        }
    }
}