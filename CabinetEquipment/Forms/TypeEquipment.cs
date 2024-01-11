using CabinetEquipment.AddForms;
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

namespace CabinetEquipment.Forms
{
    public partial class TypeEquipment : Form
    {
        public TypeEquipment()
        {
            InitializeComponent();
        }
        private void loadInfoTypeEquipment()
        {
            DB db = new DB();

            typeEquipmentsDataGridView.Rows.Clear();

            string query = $"select * from typeequipment";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(query, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    typeEquipmentsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void TypeEquipment_Load(object sender, EventArgs e)
        {
            loadInfoTypeEquipment();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoTypeEquipment();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ate = new AddTypeEquipment(null);
            ate.FormClosed += ate_FormClosed;
            ate.ShowDialog();
        }
        private void ate_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoTypeEquipment();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ate = new AddTypeEquipment(typeEquipmentsDataGridView[0, typeEquipmentsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ate.FormClosed += ate_FormClosed;
            ate.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from typeequipment where id = {typeEquipmentsDataGridView[0, typeEquipmentsDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Тип оснащения удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoTypeEquipment();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            typeEquipmentsDataGridView.Rows.Clear();

            string searchString = $"select * from typeequipment where concat(name) like '%" + SearchTextBox.Text + "%'";

            db.openConnection();
            using (MySqlCommand mySqlCommand = new MySqlCommand(searchString, db.getConnection()))
            {
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                List<string[]> dataDB = new List<string[]>();
                while (reader.Read())
                {
                    dataDB.Add(new string[reader.FieldCount]);

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        dataDB[dataDB.Count - 1][i] = reader[i].ToString();
                    }
                }
                reader.Close();
                foreach (string[] s in dataDB)
                    typeEquipmentsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
