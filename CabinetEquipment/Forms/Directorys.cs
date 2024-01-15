using CabinetEquipment.AddForms;
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
    public partial class Directorys : Form
    {
        public Directorys()
        {
            InitializeComponent();
        }

        private void KabinetButton_Click(object sender, EventArgs e)
        {
            new TypeEquipment().Show();
        }

        private void BackButtonButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Main().Show();
        }

        private void Directorys_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void SubjectsButton_Click(object sender, EventArgs e)
        {
            new Discipline().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddComponentEYMK().Show();
        }
    }
}
