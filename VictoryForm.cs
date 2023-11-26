using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
    public partial class VictoryForm : Form
    {
        private LevelForm _Parent;
        private Character _hero;
        public VictoryForm(LevelForm parent)
        {
            InitializeComponent();
            _Parent = parent;
            _hero = _Parent.Hero;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
            _Parent.Close();
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            this.Close();
            _Parent.RestartGame();
        }

        private void VictoryForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < _hero.Medals; i++)
            {
                Controls["med" + i].Visible = true;
                Debug.WriteLine(Controls["med" + i]);
            }
        }
    }
}
