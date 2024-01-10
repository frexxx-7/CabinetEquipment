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
    public partial class AddTeacher : Form
    {
        private string idTeacher;
        public AddTeacher(string idTeacher)
        {
            InitializeComponent();
            this.idTeacher = idTeacher;
        }
        private void loadInfoForTeacher()
        {
            DB db = new DB();
            string queryInfo = $"SELECT * FROM teachers WHERE id = '{idTeacher}'";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader[1].ToString();
                SurnameTextBox.Text = reader[2].ToString();
                PatronymicTextBox.Text = reader[3].ToString();
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
                NumberPhoneTextBox.Text = reader[5].ToString();
            }
            reader.Close();

            db.closeConnection();
        }
        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idTeacher == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into teachers (name, surname, patronymic, CK, numberPhone) values(@name, @surname, @patronymic, @CK, @numberPhone)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@CK", CKComboBox.SelectedItem);
                command.Parameters.AddWithValue("@numberPhone", NumberPhoneTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Преподаватель добавлен");
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
                MySqlCommand command = new MySqlCommand($"update teachers set name = @name, surname = @surname, patronymic = @patronymic, CK = @CK, numberPhone = @numberPhone where id = {idTeacher}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@surname", SurnameTextBox.Text);
                command.Parameters.AddWithValue("@patronymic", PatronymicTextBox.Text);
                command.Parameters.AddWithValue("@CK", CKComboBox.SelectedItem );
                command.Parameters.AddWithValue("@numberPhone", NumberPhoneTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Преподаватель изменен");
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

        private void AddTeacher_Load(object sender, EventArgs e)
        {
            if (idTeacher != null)
            {
                label1.Text = "Изменить преподавателя";
                AddButton.Text = "Изменить";
                loadInfoForTeacher();
            }
        }
    }
}
