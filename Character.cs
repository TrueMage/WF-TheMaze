using System.Diagnostics;
using System.Media;

namespace Maze
{
    public class Character
    {
        Random r = new Random();
        private int _health = 100;
        private int _stepcount = 0;
        private int _energy = 500;

        private List<Weapon> _weapons = new List<Weapon>();
        private int _currentWeapon = -1;

        SoundPlayer GameOverSound = new SoundPlayer(Properties.Resources.game_over);
        SoundPlayer HurtSound = new SoundPlayer(Properties.Resources.hurt);

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

        public int Energy
        {
            get
            {
                return _energy;
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
            Debug.WriteLine(this.PosX + " " + this.PosY);
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
            if (Parent.SoundEffectOn) HurtSound.Play();
            _health -= 25;
            Parent.UpdateStatusBar(this);

            if (_health <= 0)
            {
                GameOverSound.Play();
                Parent.EndGame();
                Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage = Properties.Resources.player_with_blackeye;

                DialogResult result = MessageBox.Show("У вас закончилось здоровье. Вы проиграли","Конец игры", MessageBoxButtons.RetryCancel);
                if (result == DialogResult.Retry) Parent.RestartGame();
            }
        }

        public void GetHealed()
        { 
            if(_health >= 100) return;
            if (Parent.SoundEffectOn) Parent.PickUpSound.Play();
            _health += 25;
            Parent.UpdateStatusBar(this);
        }

        public void GetRandomWeapon()
        {
            _weapons.Add(new Pistol(Parent));
            _currentWeapon = _weapons.Count()-1;
        }

        public void Shoot()
        {
            if(_currentWeapon <= -1) return;
            if (_weapons[_currentWeapon].isEmpty()) return;
            _weapons[_currentWeapon].Shoot();
            _energy -= _weapons[_currentWeapon].EnergyConsumption;
            Parent.UpdateStatusBar(this);
        }

        public void Show()
        {
            Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage =
                Parent.maze.cells[PosY, PosX].Texture =
                Cell.Images[(int)(Parent.maze.cells[PosY, PosX].Type = CellType.HERO)];
        }
    }
}