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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CabinetEquipment.AddForms
{
    public partial class AddKabinet : Form
    {
        private string idKabinet;
        public AddKabinet(string idKabinet)
        {
            InitializeComponent();
            this.idKabinet = idKabinet;
        }
        private void loadInfoTeachers()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name, surname, patronymic FROM teachers";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]} {reader[3]} {reader[2]}";
                item.Value = reader[0];
                TeacherComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoForKabinet()
        {
            DB db = new DB();
            string queryInfo = $"select *, concat(teachers.surname, ' ', teachers.name, ' ', teachers.patronymic) as teacherFIO from kabinets " +
                $"inner join teachers on teachers.id = kabinets.idTeacher " +
                $"where kabinets.id = {idKabinet}";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader[1].ToString();
                AreaTextBox.Text = reader[2].ToString();
                for (int i = 0; i < TeacherComboBox.Items.Count; i++)
                {
                    if (reader["idTeacher"].ToString() != "")
                    {
                        if (Convert.ToInt32((TeacherComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idTeacher"]))
                        {
                            TeacherComboBox.SelectedIndex = i;
                        }
                    }
                }
                floorTextBox.Text = reader[4].ToString();
            }
            reader.Close();

            db.closeConnection();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddKabinet_Load(object sender, EventArgs e)
        {
            loadInfoTeachers();

            if (idKabinet != null)
            {
                label1.Text = "Изменить кабинет";
                AddButton.Text = "Изменить";
                loadInfoForKabinet();
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            if (idKabinet == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into kabinets (name, area, idTeacher, floor) values(@name, @area, @idTeacher, @floor)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@area", AreaTextBox.Text);
                command.Parameters.AddWithValue("@idTeacher", (TeacherComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@floor", floorTextBox.Text);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Кабинет добавлен");
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
                MySqlCommand command = new MySqlCommand($"update kabinets set name = @name, area = @area, idTeacher = @idTeacher, floor = @floor where id = {idKabinet}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@area", AreaTextBox.Text);
                command.Parameters.AddWithValue("@idTeacher", (TeacherComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@floor", floorTextBox.Text);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Кабинет изменен");
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
