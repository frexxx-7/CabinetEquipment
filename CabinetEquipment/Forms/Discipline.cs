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
    public partial class Discipline : Form
    {
        public Discipline()
        {
            InitializeComponent();
        }
        private void loadInfoDiscipline()
        {
            DB db = new DB();

            DisciplineDataGridView.Rows.Clear();

            string query = $"select * from discipline";

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
                    DisciplineDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ae = new AddDiscipline(DisciplineDataGridView[0, DisciplineDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.FormClosed += ad_FormClosed;
            ae.ShowDialog();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ad = new AddDiscipline(null);
            ad.FormClosed += ad_FormClosed;
            ad.ShowDialog();
        }
        private void ad_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoDiscipline();
        }

        private void Discipline_Load(object sender, EventArgs e)
        {
            loadInfoDiscipline();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from discipline where id = {DisciplineDataGridView[0, DisciplineDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Предмет удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoDiscipline();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            DisciplineDataGridView.Rows.Clear();

            string searchString = $"select * from discipline " +
                $"where concat(name, CK) " +
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
                    DisciplineDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoDiscipline();
        }
    }
}
