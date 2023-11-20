namespace Maze
{
    public class Character
    {
        Random r = new Random();
        private int _health = 100;
        private int _stepcount = 0;
        // позиция главного персонажа
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
                Cell.Images[(int)(Parent.maze.cells[PosY, PosX].Type = CellType.HALL)];
        }

        public void MoveTo(ushort PosX, ushort PosY)
        {
            this.PosX = PosX;
            this.PosY = PosY;

            _stepcount++;
            Parent.UpdateStepCount(_stepcount);
        }

        public void GetAttacked()
        {
            _health -= 25;
            Parent.UpdateHealth(_health);
            if (_health <= 0)
            {
                Parent.EndGame();
                MessageBox.Show("Вы проиграли");
            }
        }

        public void GetHealed()
        { 
            _health += 25;
            Parent.UpdateHealth(_health);
        }

        public void Show()
        {
            Parent.Controls["pic" + PosY + "_" + PosX].BackgroundImage =
                Parent.maze.cells[PosY, PosX].Texture =
                Cell.Images[(int)(Parent.maze.cells[PosY, PosX].Type = CellType.HERO)];
        }
    }
}