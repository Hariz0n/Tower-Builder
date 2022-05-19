using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TowerBuilder.Domain;

namespace TowerBuilder
{
    public partial class Form1 : Form
    {
        public Game Game;
        public Form1()
        {
            InitializeComponent();

            Game = new Game("Mark", Difficulty.Easy);
        }
    }
}