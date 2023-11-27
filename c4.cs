using System;
using System.Collections.Generic;
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

        public C4(LevelForm parent)
        {
            Parent = parent;
            _ammoCount = 1;
            _shootSound = new SoundPlayer(Properties.Resources.pistol_shoot);
            EnergyConsumption = 40;

            Parent.WeaponIcon.Visible = true;
            Parent.WeaponIcon.Image = Properties.Resources.c4;
            Parent.WeaponIcon.ToolTipText = _ammoCount.ToString();
        }

        public override void Shoot(int PosX, int PosY, Character.Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}
