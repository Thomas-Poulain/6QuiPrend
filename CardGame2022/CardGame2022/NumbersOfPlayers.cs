using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame2022
{
    public partial class NumbersOfPlayers : Form
    {
        public NumbersOfPlayers()
        {
            InitializeComponent();
        }

        public int NbPlayers { get { return (int)numericUpDownNbPlayers.Value; } }

        private void buttonOkNbPlayers_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
