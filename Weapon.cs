using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal abstract class Weapon
    {
        protected int _ammoCount;
        public int EnergyConsumption;
        protected SoundPlayer _shootSound;

        public abstract void Shoot(int PosX, int PosY, Character.Direction direction);

        public virtual bool isEmpty()
        {
            return _ammoCount <= 0;
        }
    }
}
