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

        private void button1_Click(object sender, EventArgs e)
        {
            new Equipments().Show();
        }

        private void DirectoryButton_Click(object sender, EventArgs e)
        {
            new Directorys().Show();
            this.Hide();
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
