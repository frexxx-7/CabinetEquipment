using CabinetEquipment.Classes;
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

namespace CabinetEquipment.AddForms
{
    public partial class AddTypeEquipment : Form
    {
        private string idTypeEquipment;
        public AddTypeEquipment(string idTypeEquipment)
        {
            InitializeComponent();
            this.idTypeEquipment = idTypeEquipment;
        }
        private void loadInfoForTypeEquipment()
        {
            DB db = new DB();
            string queryInfo = $"select * from typeequipment " +
                $"where id = {idTypeEquipment}";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader[1].ToString();
            }
            reader.Close();

            db.closeConnection();
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTypeEquipment_Load(object sender, EventArgs e)
        {
            if (idTypeEquipment != null)
            {
                label1.Text = "Изменить вид оснащения";
                AddButton.Text = "Изменить";
                loadInfoForTypeEquipment();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idTypeEquipment == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into typeequipment (name) values(@name)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
          
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Вид осанщения добавлен");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update typeequipment set name = @name where id = {idTypeEquipment}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Вид оснащения изменен");
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
}
