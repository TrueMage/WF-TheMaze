using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal abstract class Weapon
    {
        private int _ammoCount;
        private int _energyConsumption;

        public abstract void Shoot();
    }
}
