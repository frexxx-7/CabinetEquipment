﻿using CabinetEquipment.AddForms;
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
    public partial class CompoundEYMK : Form
    {
        private string nameChapter = null;
        public CompoundEYMK()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadInfoEYMKInChapter()
        {
            DB db = new DB();

            EYMKDataGridView.Rows.Clear();

            string query = $"select compoundeymk.id, teachers.name, discipline.name from compoundeymk " +
                $"inner join eymk on compoundeymk.idEYMK = eymk.id " +
                $"inner join teachers on teachers.id = EYMK.idTeacher " +
                $"inner join discipline on discipline.id = EYMK.idDiscipline " +
                $"where compoundeymk.name = '{nameChapter}'";

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
            var ace = new AddCompoundEYMK(null);
            ace.FormClosed += ace_FormClosed;
            ace.ShowDialog();
        }
        private void ace_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoEYMKInChapter();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ae = new AddCompoundEYMK(EYMKDataGridView[0, EYMKDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ae.FormClosed += ace_FormClosed;
            ae.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from compoundeymk where id = {EYMKDataGridView[0, EYMKDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Состав ЭУМК удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
        }

        private void CompoundEYMK_Load(object sender, EventArgs e)
        {
            ChapterСomboBox.SelectedIndex = 0;
        }

        private void ChapterСomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            nameChapter = ChapterСomboBox.SelectedItem.ToString();
            loadInfoEYMKInChapter();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoEYMKInChapter();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            EYMKDataGridView.Rows.Clear();

            string searchString = $"select compoundeymk.id, teachers.name, discipline.name from compoundeymk " +
                $"inner join eymk on compoundeymk.idEYMK = eymk.id " +
                $"inner join teachers on teachers.id = EYMK.idTeacher " +
                $"inner join discipline on discipline.id = EYMK.idDiscipline " +
                $"where compoundeymk.name = '{nameChapter}' AND concat (teachers.name, discipline.name) " +
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
    }
}