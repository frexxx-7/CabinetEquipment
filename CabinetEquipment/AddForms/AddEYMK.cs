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
    public partial class AddEYMK : Form
    {
        private string idEYMK;
        public AddEYMK(string idEYMK)
        {
            InitializeComponent();
            this.idEYMK = idEYMK;
        }
        private void loadInfoElements()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, title FROM componenteymk";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                ElementComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoDiscipline()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM discipline";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                disciplineComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoTeachers()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM teachers";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                teachersComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoForEYMK()
        {
            DB db = new DB();
            string queryInfo = $"select * from EYMK " +
                $"where id = {idEYMK}";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                for (int i = 0; i < disciplineComboBox.Items.Count; i++)
                {
                    if (reader["idDiscipline"].ToString() != "")
                    {
                        if (Convert.ToInt32((disciplineComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idDiscipline"]))
                        {
                            disciplineComboBox.SelectedIndex = i;
                        }
                    }
                }
                for (int i = 0; i < teachersComboBox.Items.Count; i++)
                {
                    if (reader["idTeacher"].ToString() != "")
                    {
                        if (Convert.ToInt32((teachersComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idTeacher"]))
                        {
                            teachersComboBox.SelectedIndex = i;
                        }
                    }
                }
                for (int i = 0; i < ElementComboBox.Items.Count; i++)
                {
                    if (reader["idComponentEYMK"].ToString() != "")
                    {
                        if (Convert.ToInt32((ElementComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idComponentEYMK"]))
                        {
                            ElementComboBox.SelectedIndex = i;
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
            if (idEYMK == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into eymk (idDiscipline, idTeacher, idComponentEYMK) values(@idDiscipline, @idTeacher, @idComponentEYMK)", db.getConnection());
                command.Parameters.AddWithValue("@idDiscipline", (disciplineComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idTeacher", (teachersComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idComponentEYMK", (ElementComboBox.SelectedItem as ComboboxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("ЭУМК добавлено");
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update eymk set idDiscipline = @idDiscipline, idTeacher = @idTeacher, idComponentEYMK = @idComponentEYMK where id = {idEYMK}", db.getConnection());
                command.Parameters.AddWithValue("@idDiscipline", (disciplineComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idTeacher", (teachersComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idComponentEYMK", (ElementComboBox.SelectedItem as ComboboxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("ЭУМК изменено");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void AddEYMK_Load(object sender, EventArgs e)
        {
            loadInfoDiscipline();
            loadInfoTeachers();
            loadInfoElements();

            if (idEYMK != null)
            {
                label1.Text = "Изменить ЭУМК";
                AddButton.Text = "Изменить";
                loadInfoForEYMK();
            }
        }

        private void CanceledButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
