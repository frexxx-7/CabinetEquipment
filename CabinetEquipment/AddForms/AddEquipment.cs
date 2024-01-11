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
    public partial class AddEquipment : Form
    {
        private string idEquipment;
        public AddEquipment(string idEquipment)
        {
            InitializeComponent();
            this.idEquipment = idEquipment;
        }
        private void loadInfoKabinets()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM kabinets";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                KabinetComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoTypeEquipmnet()
        {
            DB db = new DB();
            string queryInfo = $"SELECT id, name FROM typeequipment";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = $" {reader[1]}";
                item.Value = reader[0];
                typeEquipmentComboBox.Items.Add(item);
            }
            reader.Close();

            db.closeConnection();
        }
        private void loadInfoForEquipment()
        {
            DB db = new DB();
            string queryInfo = $"select * from equipment " +
                $"where equipment.id = {idEquipment}";
            MySqlCommand mySqlCommand = new MySqlCommand(queryInfo, db.getConnection());

            db.openConnection();

            MySqlDataReader reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                NameTextBox.Text = reader["name"].ToString();
                countTextBox.Text = reader["count"].ToString();
                for (int i = 0; i < KabinetComboBox.Items.Count; i++)
                {
                    if (reader["idKabinet"].ToString() != "")
                    {
                        if (Convert.ToInt32((KabinetComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idKabinet"]))
                        {
                            KabinetComboBox.SelectedIndex = i;
                        }
                    }
                }
                for (int i = 0; i < typeEquipmentComboBox.Items.Count; i++)
                {
                    if (reader["idTypeEquipment"].ToString() != "")
                    {
                        if (Convert.ToInt32((typeEquipmentComboBox.Items[i] as ComboboxItem).Value) == Convert.ToInt32(reader["idTypeEquipment"]))
                        {
                            typeEquipmentComboBox.SelectedIndex = i;
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
            if (idEquipment == null)
            {
                MySqlCommand command = new MySqlCommand($"INSERT into equipment (name, count, idKabinet, idTypeEquipment) values(@name, @count, @idKabinet, @idTypeEquipment)", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@count", countTextBox.Text);
                command.Parameters.AddWithValue("@idKabinet", (KabinetComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idTypeEquipment", (typeEquipmentComboBox.SelectedItem as ComboboxItem).Value);
                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Оснащение добавлено");
                    this.Close();

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
            else
            {
                MySqlCommand command = new MySqlCommand($"update equipment set name = @name, count = @count, idKabinet = @idKabinet, idTypeEquipment = @idTypeEquipment where id = {idEquipment}", db.getConnection());
                command.Parameters.AddWithValue("@name", NameTextBox.Text);
                command.Parameters.AddWithValue("@count", countTextBox.Text);
                command.Parameters.AddWithValue("@idKabinet", (KabinetComboBox.SelectedItem as ComboboxItem).Value);
                command.Parameters.AddWithValue("@idTypeEquipment", (typeEquipmentComboBox.SelectedItem as ComboboxItem).Value);

                db.openConnection();

                try
                {
                    command.ExecuteNonQuery();
                    MessageBox.Show("Оснащение изменено");
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                db.closeConnection();
            }
        }

        private void AddEquipment_Load(object sender, EventArgs e)
        {
            loadInfoKabinets();
            loadInfoTypeEquipmnet();

            if (idEquipment != null)
            {
                label1.Text = "Изменить оснащение";
                AddButton.Text = "Изменить";
                loadInfoForEquipment();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
