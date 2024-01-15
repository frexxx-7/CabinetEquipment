using CabinetEquipment.Classes;
using CabinetEquipment.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CabinetEquipment.AddForms
{
    public partial class AddComponentEYMK : Form
    {
        public AddComponentEYMK()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"INSERT into componenteymk (type, title, content) values(@type, @title, @content)", db.getConnection());
            command.Parameters.AddWithValue("@title", TitleTextBox.Text);
            command.Parameters.AddWithValue("@type", TypeСomboBox.SelectedItem);
            command.Parameters.AddWithValue("@content", textBox1.Text);
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Элемент добавлен");
                this.Close();

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }
    }
}
