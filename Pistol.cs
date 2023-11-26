﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Maze
{
    internal class Pistol : Weapon
    {
        Random rand = new Random();
        private SoundPlayer shootSound = new SoundPlayer(Properties.Resources.pistol_shoot);
        private LevelForm Parent;
        public Pistol(LevelForm parent)
        {
            Parent = parent;
            _ammoCount = rand.Next(3, 10);
            EnergyConsumption = 20;

            Parent.PistolIcon.Visible = true;
            Parent.PistolIcon.ToolTipText = _ammoCount.ToString();
        }

        public override void Shoot()
        {
            _ammoCount--;
            shootSound.Play();
            if (_ammoCount <= 0)
            {
                Parent.PistolIcon.Enabled = false;
                Parent.PistolIcon.ToolTipText = "Пустой";
            }
            else
            {
                Parent.PistolIcon.ToolTipText = _ammoCount.ToString();
            }
        }
    }
}