using CabinetEquipment.AddForms;
using CabinetEquipment.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CabinetEquipment.Forms
{
    public partial class Teachers : Form
    {
        public Teachers()
        {
            InitializeComponent();
        }
        private void loadInfoTeachers()
        {
            DB db = new DB();

            TeachersDataGridView.Rows.Clear();

            string query = $"select * from teachers";

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
                    TeachersDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void Teachers_Load(object sender, EventArgs e)
        {
            loadInfoTeachers();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoTeachers();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var at = new AddTeacher(null);
            at.FormClosed += as_FormClosed;
            at.ShowDialog();
        }
        private void as_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoTeachers();
        }
        private void EditButton_Click(object sender, EventArgs e)
        {
            var at = new AddTeacher(TeachersDataGridView[0, TeachersDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            at.FormClosed += as_FormClosed;
            at.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from teachers where id = {TeachersDataGridView[0, TeachersDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Преподаватель удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoTeachers();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            TeachersDataGridView.Rows.Clear();

            string searchString = $"select * from teachers where concat (name, surname, patronymic, CK, numberPhone) like '%" + SearchTextBox.Text + "%'";

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
                    TeachersDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
