using System.Diagnostics;
using System.Media;

namespace Maze
{
    public class Character
    {
        public enum Direction
        {
            UP, DOWN, LEFT, RIGHT
        }

        Random r = new Random();
        private int _health = 100;
        private int _stepcount = 0;
        private int _energy = 500;
        private int _medals = 0;

        int lastEnergized = 0;
        Direction _lastdirection = Direction.RIGHT;

        private List<Weapon> _weapons = new List<Weapon>();
        private int _currentWeapon = -1;

        SoundPlayer HurtSound = new SoundPlayer(Properties.Resources.hurt);

        public CellType NotUsed = CellType.HALL;

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

        public int Medals
        {
            get
            {
                return _medals;
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
                Cell.Images[(int)(Parent.maze.cells[PosY, PosX].Type = NotUsed)];
            NotUsed = CellType.HALL;
        }

        public void MoveTo(ushort PosX, ushort PosY, Direction direction)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            _lastdirection = direction;

            _stepcount++;
            _energy--;
            lastEnergized++;

            if (_stepcount % 20 == 0)
            {
                Parent.maze.SpawnByChance(CellType.ENEMY, 200);
            }

            Parent.UpdateStatusBar(this);
            if (_energy <= 0) Parent.EndGame("У вас закончилось \nэнергия");
        }

        public void GetAttacked()
        {
            if (Parent.SoundEffectOn) HurtSound.Play();
            _health -= 25;
            Parent.UpdateStatusBar(this);

            if (_health <= 0) Parent.EndGame("У вас закончилось \nздоровье");
        }

        public void GetHealed()
        {
            if (_health >= 100)
            {
                NotUsed = CellType.HEALING_POTION;
                return;
            }
            if (Parent.SoundEffectOn) Parent.PickUpSound.Play();
            _health += 25;
            Parent.UpdateStatusBar(this);
        }

        public void GetEnergized()
        {
            if (lastEnergized < 30)
            {
                NotUsed = CellType.REDBULL;
                return;
            }
            if (Parent.SoundEffectOn) Parent.DrinkSound.Play();

            _energy += 25;
            lastEnergized = 0;

            Parent.UpdateStatusBar(this);
        }

        public void GetMedal()
        {
            _medals++;
        }

        public void GetRandomWeapon()
        {
            switch (r.Next(0,2))
            {
                case 0: _weapons.Add(new Pistol(Parent));
                    break;
                case 1: _weapons.Add(new C4(Parent)); 
                    break;
            }
            _currentWeapon = _weapons.Count()-1;
        }

        public void Shoot()
        {
            if(_currentWeapon <= -1) return;
            if (_weapons[_currentWeapon].isEmpty()) return;
            _weapons[_currentWeapon].Shoot(PosX, PosY, _lastdirection);
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