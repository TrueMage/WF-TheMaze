using System.Diagnostics;

namespace Maze
{
    public class Maze
    {
        public LevelForm Parent { get; set; } // ссылка на родительскую форму

        public Cell[,] cells;
        public static Random r = new Random();

        public Maze(LevelForm parent)
        {
            Parent = parent;
            cells = new Cell[Configuration.Rows, Configuration.Columns];
        }

        public void Generate()
        {
            for (ushort row = 0; row < Configuration.Rows; row++)
            {
                for (ushort col = 0; col < Configuration.Columns; col++)
                {
                    CellType cell = CellType.HALL;

                    // в 1 случае из 5 - ставим стену в текуще ячейке
                    if (r.Next(5) == 0)
                    {
                        cell = CellType.WALL;
                    }

                    // стены по периметру лабиринта
                    if (row == 0 || col == 0 ||
                        row == Configuration.Rows - 1 ||
                        col == Configuration.Columns - 1)
                    {
                        cell = CellType.WALL;
                    }

                    // наш персонажик
                    if (col == Parent.Hero.PosX &&
                        row == Parent.Hero.PosY)
                    {
                        cell = CellType.HERO;
                    }

                    if (col == Parent.Hero.PosX + 1 &&
                        row == Parent.Hero.PosY)
                    {
                        cell = CellType.HALL;
                    }

                    // есть выход, и соседняя ячейка справа всегда свободна
                    if (col == Configuration.Columns - 1 &&
                        row == Configuration.Rows - 3)
                    {
                        cell = CellType.EXIT;
                    }

                    cells[row, col] = new Cell(cell);

                    var picture = new PictureBox();
                    picture.Name = "pic" + row + "_" + col;
                    picture.Width = Configuration.PictureSide;
                    picture.Height = Configuration.PictureSide;
                    picture.Location = new Point(
                        col * Configuration.PictureSide,
                        row * Configuration.PictureSide);

                    picture.BackgroundImage = cells[row, col].Texture;
                    picture.Visible = false;
                    Parent.Controls.Add(picture);
                }
            }

            SpawnEnemies(20);
            SpawnHealing(150);
            SpawnMedals(3);
        }

        #region SpawnMethods
        public void SpawnEnemies(int chance)
        {
            for (int i = 1; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1)-1; j++)
                {
                    if (!cells[i,j].isHall()) continue;
                    else if (r.Next(chance) == 0)
                    {
                        Debug.WriteLine("CREATED ENEMY AT" + i + " " + j);
                        cells[i, j].Type = CellType.ENEMY;

                        Parent.Controls["pic" + i + "_" + j].BackgroundImage =
                            Parent.maze.cells[i, j].Texture =
                                Cell.Images[(int)(Parent.maze.cells[i, j].Type = CellType.ENEMY)];
                    }
                }
            }
        }

        public void SpawnHealing(int chance)
        {
            bool pity = true;
            
            for (int i = 1; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1) - 1; j++)
                {
                    if (!cells[i, j].isHall()) continue;
                    else if (r.Next(chance) == 0)
                    {
                        pity = false;
                        Debug.WriteLine("CREATED HEALING_POTION AT" + i + " " + j);
                        cells[i, j].Type = CellType.HEALING_POTION;

                        Parent.Controls["pic" + i + "_" + j].BackgroundImage =
                            Parent.maze.cells[i, j].Texture =
                                Cell.Images[(int)(Parent.maze.cells[i, j].Type = CellType.HEALING_POTION)];
                    }
                }
            }

            if (pity)
            {
                while (true)
                {
                    int posX = r.Next(1, cells.GetLength(0));
                    int posY = r.Next(cells.GetLength(0) - 1);

                    if (!cells[posX, posY].isHall()) continue;

                    cells[posX, posY].Type = CellType.HEALING_POTION;
                    Parent.Controls["pic" + posX + "_" + posY].BackgroundImage =
                        Parent.maze.cells[posX, posY].Texture =
                            Cell.Images[(int)(Parent.maze.cells[posX, posY].Type = CellType.HEALING_POTION)];
                    break;
                }
            }
        }

        public void SpawnMedals(int count)
        {
            while (count != 0)
            {
                int posX = r.Next(1,cells.GetLength(0));
                int posY = r.Next(cells.GetLength(0)-1);

                if (!cells[posX, posY].isHall()) continue;

                cells[posX, posY].Type = CellType.MEDAL;
                Parent.Controls["pic" + posX + "_" + posY].BackgroundImage =
                    Parent.maze.cells[posX, posY].Texture =
                        Cell.Images[(int)(Parent.maze.cells[posX, posY].Type = CellType.MEDAL)];
                count--;
            }
        }

        #endregion

        public void Show()
        {
            foreach (var control in Parent.Controls)
            {
                if (control is StatusStrip) continue;
                ((PictureBox)control).Visible = true;
            }
        }
    }
}