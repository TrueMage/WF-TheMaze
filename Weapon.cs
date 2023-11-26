using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal abstract class Weapon
    {
        protected int _ammoCount;
        public int EnergyConsumption;

        public abstract void Shoot();

        public virtual bool isEmpty()
        {
            return _ammoCount <= 0;
        }
    }
}
