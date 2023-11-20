﻿namespace Maze
{
    public enum CellType { HALL, WALL, MEDAL, ENEMY, HERO, HEALING_POTION, EXIT };

    public class Cell
    {
        public static Bitmap[] Images = {
            new Bitmap(Properties.Resources.hall),
            new Bitmap(Properties.Resources.wall),
            new Bitmap(Properties.Resources.medal),
            new Bitmap(Properties.Resources.enemy), 
            new Bitmap(Properties.Resources.player),
            new Bitmap(Properties.Resources.healing_potion)
        };

        public CellType Type { get; set; }

        public Image Texture { get; set; }

        public Cell(CellType type)
        {
            Type = type;
            if(type != CellType.EXIT) Texture = Images[(int)Type];
            else Texture = Images[0];
        }

        public bool isHall()
        {
            if (this.Type == CellType.HALL) return true;
            else return false;
        }
    }
}