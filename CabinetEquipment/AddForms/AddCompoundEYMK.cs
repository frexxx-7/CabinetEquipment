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
    public partial class AddCompoundEYMK : Form
    {
        private string idCompoundEYMK;
        public AddCompoundEYMK(string idCompoundEYMK)
        {
            InitializeComponent();
            this.idCompoundEYMK = idCompoundEYMK;
        }
        private void loadInfoForCompoundEYMK()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM compoundeymk WHERE id = '{idCompoundEYMK}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < ChapterСomboBox.Items.Count; i++)
                {
                    if (reader["name"].ToString() != "")
                    {
                        if (ChapterСomboBox.Items[i].ToString() == reader["name"].ToString())
                        {
                            ChapterСomboBox.SelectedIndex = i;
                        }
                    }
                }
                foreach (DataGridViewRow row in EYMKDataGridView.Rows)
                {
                    string id = row.Cells["idEYMKColumn"].Value.ToString();

                    if (id == reader["idEYMK"].ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
                foreach (DataGridViewRow row in EYMKDataGridView.Rows)
                {
                    string id = row.Cells["idComponentEYMK"].Value.ToString();

                    if (id == reader["idEYMK"].ToString())
                    {
                        row.DefaultCellStyle.BackColor = Color.Green;
                    }
                }
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoEYMK()
        {
            DB db = new DB();

            EYMKDataGridView.Rows.Clear();

            string query = $"select EYMK.id, teachers.name, discipline.name from eymk " +
                $"inner join teachers on teachers.id = EYMK.idTeacher " +
                $"inner join discipline on discipline.id = EYMK.idDiscipline";

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
        private void AddCompoundEYMK_Load(object sender, EventArgs e)
        {
            loadInfoEYMK();
            if (idCompoundEYMK != null)
            {
                label3.Text = "Изменить состав ЭУМК";
                AddButton.Text = "Изменить";
                loadInfoForCompoundEYMK();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idCompoundEYMK == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into compoundeymk (name, idEYMK) values(@name,  @idEYMK)", db.getConnection());
                command.Parameters.AddWithValue("@name", ChapterСomboBox.SelectedItem);
                command.Parameters.AddWithValue("@idEYMK", EYMKDataGridView[0, EYMKDataGridView.SelectedCells[0].RowIndex].Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Состав ЭУМК добавлен");
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
                MySqlCommand command = new MySqlCommand($"update compoundeymk set name = @name, idEYMK = @idEYMK where id = {idCompoundEYMK}", db.getConnection());
                command.Parameters.AddWithValue("@name", ChapterСomboBox.SelectedItem);
                command.Parameters.AddWithValue("@idEYMK", EYMKDataGridView[0, EYMKDataGridView.SelectedCells[0].RowIndex].Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Состав ЭУМК изменен");
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
