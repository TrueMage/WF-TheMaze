using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Pistol : Weapon
    {
        Random rand = new Random();
        private LevelForm Parent;

        public Pistol(LevelForm parent)
        {
            Parent = parent;
            _ammoCount = rand.Next(3, 10);
            _shootSound = new SoundPlayer(Properties.Resources.pistol_shoot);
            EnergyConsumption = 20;

            Parent.WeaponIcon.Visible = true;
            Parent.WeaponIcon.Image = Properties.Resources.pistol;
            Parent.WeaponIcon.ToolTipText = _ammoCount.ToString();
        }

        public void DestoryInTheWay(int PosX, int PosY, Character.Direction direction)
        {
            if (Parent.maze.cells[PosY, PosX].Type == CellType.WALL) return;
            else
            {
                Debug.WriteLine(Parent.maze.cells[PosY, PosX].Type);
                Parent.maze.cells[PosY, PosX].Type = CellType.HALL;
                Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage = Properties.Resources.hall;
                switch (direction)
                {
                    case Character.Direction.UP: // x+
                        DestoryInTheWay(PosX, --PosY, direction);
                        break;
                    case Character.Direction.DOWN: // x-
                        DestoryInTheWay(PosX, ++PosY, direction);
                        break;
                    case Character.Direction.LEFT: // x-
                        DestoryInTheWay(--PosX, PosY, direction);
                        break;
                    case Character.Direction.RIGHT: // x+
                        DestoryInTheWay(++PosX, PosY, direction);
                        break;
                }
            }
        }


        public override void Shoot(int PosX, int PosY, Character.Direction direction)
        {
            _ammoCount--;

            switch (direction)
            {
                case Character.Direction.UP: // x+
                    DestoryInTheWay(PosX, --PosY, direction);
                    break;
                case Character.Direction.DOWN: // x-
                    DestoryInTheWay(PosX, ++PosY, direction);
                    break;
                case Character.Direction.LEFT: // x-
                    DestoryInTheWay(--PosX, PosY, direction);
                    break;
                case Character.Direction.RIGHT: // x+
                    DestoryInTheWay(++PosX, PosY, direction);
                    break;
            }

            _shootSound.Play();
            if (_ammoCount <= 0)
            {
                Parent.WeaponIcon.Enabled = false;
                Parent.WeaponIcon.ToolTipText = "Пустой";
            }
            else
            {
                Parent.WeaponIcon.ToolTipText = _ammoCount.ToString();
            }
        }
    }
}
