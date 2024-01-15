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
    public partial class EYMK : Form
    {
        public EYMK()
        {
            InitializeComponent();
        }
        private void loadInfoEYMK()
        {
            DB db = new DB();

            EYMKDataGridView.Rows.Clear();

            string query = $"select EYMK.id, teachers.name, discipline.name, componentEYMK.title from eymk " +
                $"inner join teachers on teachers.id = EYMK.idTeacher " +
                $"inner join discipline on discipline.id = EYMK.idDiscipline "+
                $"inner join componenteymk on componenteymk.id = EYMK.idComponentEYMK";

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
                    EYMKDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEYMK(null);
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }
        private void ae_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoEYMK();
        }

        private void EYMK_Load(object sender, EventArgs e)
        {
            loadInfoEYMK();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ae = new AddEYMK(EYMKDataGridView[0, EYMKDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.FormClosed += ae_FormClosed;
            ae.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from EYMK where id = {EYMKDataGridView[0, EYMKDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("ЭУМК удалено");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoEYMK();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            EYMKDataGridView.Rows.Clear();

            string searchString = $"select EYMK.id, teachers.name, discipline.name, componentEYMK.title from eymk " +
                $"inner join teachers on teachers.id = EYMK.idTeacher " +
                $"inner join discipline on discipline.id = EYMK.idDiscipline " +
                $"inner join compoenteymk on compoenteymk.id = EYMK.idComponentEYMK" +
                $"where concat (teachers.name, discipline.name) " +
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
                    EYMKDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoEYMK();
        }
    }
}
