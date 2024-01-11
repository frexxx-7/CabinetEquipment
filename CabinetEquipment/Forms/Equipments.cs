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
    public partial class Equipments : Form
    {
        public Equipments()
        {
            InitializeComponent();
        }
        private void loadInfoEquipment()
        {
            DB db = new DB();

            EquipmentsDataGridView.Rows.Clear();

            string query = $"select equipment.id, typeequipment.name, equipment.name, equipment.count, kabinets.name from equipment " +
                $"inner join kabinets on equipment.idKabinet = kabinets.id "+
                $"inner join typeequipment on equipment.idTypeEquipment= typeequipment.id ";

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
                    EquipmentsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEquipment(null);
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }
        private void ae_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoEquipment();
        }

        private void Equipments_Load(object sender, EventArgs e)
        {
            loadInfoEquipment();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEquipment(EquipmentsDataGridView[0, EquipmentsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from equipment where id = {EquipmentsDataGridView[0, EquipmentsDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Оснащение удалено");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoEquipment();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            EquipmentsDataGridView.Rows.Clear();

            string searchString = $"select equipment.id, typeequipment.name, equipment.name, equipment.count, kabinets.name from equipment " +
                $"inner join kabinets on equipment.idKabinet = kabinets.id " +
                $"inner join typeequipment on equipment.idTypeEquipment= typeequipment.id " +
                $"where concat (typeequipment.name, equipment.name, equipment.count, kabinets.name) " +
                $"like '%" + SearchTextBox.Text + "%'";

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
                    EquipmentsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoEquipment();
        }
    }
}
