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
    public partial class AddDiscipline : Form
    {
        private string idDiscipline;
        public AddDiscipline(string idDiscipline)
        {
            InitializeComponent();
            this.idDiscipline = idDiscipline;
        }
        private void loadInfoForDiscipline()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM discipline WHERE id = '{idDiscipline}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader[1].ToString();
                for (int i = 0; i < CKComboBox.Items.Count; i++)
                {
                    if (reader["CK"].ToString() != "")
                    {
                        if (CKComboBox.Items[i].ToString() == reader["CK"].ToString())
                        {
                            CKComboBox.SelectedIndex = i;
                        }
                    }
                }
            }
            reader.Close();

            db.closeConnection();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idDiscipline == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into discipline (name, CK) values(@name,  @CK)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@CK", CKComboBox.SelectedItem);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Предмет добавлен");
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
                MySqlCommand command = new MySqlCommand($"update discipline set name = @name, CK = @CK where id = {idDiscipline}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@CK", CKComboBox.SelectedItem);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Предмет изменен");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDiscipline_Load(object sender, EventArgs e)
        {
            if (idDiscipline != null)
            {
                label1.Text = "Изменить предмет";
                AddButton.Text = "Изменить";
                loadInfoForDiscipline();
            }
        }
    }
}
