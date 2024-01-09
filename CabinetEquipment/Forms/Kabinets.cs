using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetEquipment.Forms
{
    public partial class Kabinets : Form
    {
        public Kabinets()
        {
            InitializeComponent();
        }

        private void Kabinets_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
