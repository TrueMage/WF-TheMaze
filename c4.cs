using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class C4 : Weapon
    {
        Random rand = new Random();
        private LevelForm Parent;

        int PosX = 0;
        int PosY = 0;
        bool planted = false;

        public C4(LevelForm parent)
        {
            Parent = parent;
            _ammoCount = 1;
            _shootSound = new SoundPlayer(Properties.Resources.plant);
            EnergyConsumption = 40;

            Parent.WeaponIcon.Visible = true;
            Parent.WeaponIcon.Image = Properties.Resources.c4;
            Parent.WeaponIcon.ToolTipText = _ammoCount.ToString();
        }

        public void DestroyInArea()
        {
            const int area = 3;
            for (int i = -1; i < area - 1; i++)
            {
                for (int j = -1; j < area - 1; j++)
                {
                    if (Parent.maze.cells[PosY + j, PosX + i].Type == CellType.HERO)
                    {
                        Parent.EndGame("У вас знатно бомбануло!");
                        Parent.Hero.Health = 0;
                        Parent.UpdateStatusBar();
                    }


                    Parent.maze.cells[PosY + j, PosX + i].Type = CellType.HALL;
                    Parent.Controls["pic" + (PosY + j) + "_" + (PosX + i)].BackgroundImage = Properties.Resources.hall;
                }
            }
        }

        public override void Shoot(int PosX, int PosY, Character.Direction direction)
        {
            if (!planted)
            {
                this.PosX = PosX;
                this.PosY = PosY;
                planted = true;
                Parent.Hero.NotUsed = CellType.C4;
                _shootSound.Play();

                _shootSound = new SoundPlayer(Properties.Resources.explosion);
            }
            else
            {
                DestroyInArea();
                _ammoCount--;
                Parent.WeaponIcon.Enabled = false;
                Parent.WeaponIcon.ToolTipText = "Пустой";
                _shootSound.Play();
            }
        }
    }
}
