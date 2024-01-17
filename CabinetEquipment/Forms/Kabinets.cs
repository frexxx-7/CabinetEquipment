using CabinetEquipment.AddForms;
using CabinetEquipment.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CabinetEquipment.Forms
{
    public partial class Kabinets : Form
    {
        public Kabinets()
        {
            InitializeComponent();
        }
        private void loadInfoKabinets()
        {
            DB db = new DB();

            KabinetsDataGridView.Rows.Clear();

            string query = $"select kabinets.id, kabinets.name, kabinets.area, concat(teachers.surname, ' ', teachers.name, ' ', teachers.patronymic) as teacherFIO, kabinets.floor from kabinets " +
                $"inner join teachers on teachers.id = kabinets.idTeacher";

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
                    KabinetsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void Kabinets_Load(object sender, EventArgs e)
        {
            loadInfoKabinets();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            loadInfoKabinets();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var ak = new AddKabinet(null);
            ak.FormClosed += ak_FormClosed;
            ak.ShowDialog();
        }
        private void ak_FormClosed(object sender, FormClosedEventArgs e)
        {
            loadInfoKabinets();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var ak = new AddKabinet(KabinetsDataGridView[0, KabinetsDataGridView.SelectedCells[0].RowIndex].Value.ToString());
            ak.FormClosed += ak_FormClosed;
            ak.ShowDialog();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlCommand command = new MySqlCommand($"delete from kabinets where id = {KabinetsDataGridView[0, KabinetsDataGridView.SelectedCells[0].RowIndex].Value}", db.getConnection());
            db.openConnection();

            try
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Кабинет удален");

            }
            catch
            {
                MessageBox.Show("Ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            db.closeConnection();
            loadInfoKabinets();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            DB db = new DB();

            KabinetsDataGridView.Rows.Clear();

            string searchString = $"select *, concat(teachers.surname, ' ', teachers.name, ' ', teachers.patronymic) as teacherFIO from kabinets " +
                $"inner join teachers on teachers.id = kabinets.idTeacher " +
                $"where concat (kabinets.name, area, patronymic, concat(teachers.surname, ' ', teachers.name, ' ', teachers.patronymic), floor) " +
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
                    KabinetsDataGridView.Rows.Add(s);
            }
            db.closeConnection();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            Excel.Workbook workbook = excelApp.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.ActiveSheet;
            for (int j = 0; j < KabinetsDataGridView.Columns.Count; j++)
            {
                if (KabinetsDataGridView.Columns[j].Visible)
                {
                    worksheet.Cells[1, j] = KabinetsDataGridView.Columns[j].HeaderText;
                }
            }
            for (int i = 0; i < KabinetsDataGridView.Rows.Count; i++)
            {
                for (int j = 0; j < KabinetsDataGridView.Columns.Count; j++)
                {
                    if (KabinetsDataGridView.Columns[j].Visible)
                    {
                        worksheet.Cells[i + 2, j] = KabinetsDataGridView.Rows[i].Cells[j].Value;
                    }
                }
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Excel File|*.xlsx";
            saveFileDialog1.Title = "Сохранить Excel файл";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                workbook.SaveAs(saveFileDialog1.FileName);
            }
            workbook.Close();
            excelApp.Quit();
        }
    }
}
