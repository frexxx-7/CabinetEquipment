using CabinetEquipment.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetEquipment
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void KabinetButton_Click(object sender, EventArgs e)
        {
            new Kabinets().Show();
        }

        private void TeachersButton_Click(object sender, EventArgs e)
        {
            new Teachers().Show();
        }
    }
}
