using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class Otchet : Form {
        public static string connectionString;
        public Otchet() {
            InitializeComponent();
            comboBox.Items.Add("Пропуски всех студентов");
            comboBox.Items.Add("Пропуски групп");
            comboBox.Items.Add("Пропуски факультетов");
            comboBox.Items.Add("Студенты без пропусков");
            comboBox.Items.Add("Аудитории свободные в указанный день (левый пикер)");
            comboBox.Items.Add("Сводка использования аудиторий по расписанию");
            comboBox.SelectedIndex = 0;
        }

        private void sendDataToExcel(DataGridView dgv, string filename, string sheetName) {

            DataTable dt = new DataTable();
            foreach (DataGridViewColumn column in dgv.Columns) {
                dt.Columns.Add(column.HeaderText, column.ValueType);
            }
            foreach (DataGridViewRow row in dgv.Rows) {
                DataRow newRow = dt.Rows.Add();
                foreach (DataGridViewCell cell in row.Cells) {
                    newRow[cell.ColumnIndex] = cell.Value;
                }
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            saveFileDialog.Title = "Save Excel File";
            saveFileDialog.FileName = $"{filename}.xlsx";
            ExcelPackage.LicenseContext =OfficeOpenXml.LicenseContext.NonCommercial;
            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                FileInfo file = new FileInfo(saveFileDialog.FileName);
                using (ExcelPackage package = new ExcelPackage(file)) {
                    ExcelWorksheet worksheet;
                    try {

                        ExcelWorksheet existingWorksheet = package.Workbook.Worksheets[$"{sheetName}"];
                        if (existingWorksheet != null) {
                            package.Workbook.Worksheets.Delete(existingWorksheet);
                        }
                        worksheet = package.Workbook.Worksheets.Add(sheetName); // Используем название отчета
                    }
                    catch (Exception ex) {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    for (int col = 1;col <= dt.Columns.Count;col++) {
                        worksheet.Cells[1, col].Value = dt.Columns[col - 1].ColumnName;
                    }

                    // Сохраняем данные из DataTable
                    for (int row = 0;row < dt.Rows.Count;row++) {
                        for (int col = 0;col < dt.Columns.Count;col++) {
                            if (dt.Columns[col].DataType == typeof(DateTime)) {
                                worksheet.Cells[row + 2, col + 1].Value = (DateTime)dt.Rows[row][col];
                                worksheet.Cells[row + 2, col + 1].Style.Numberformat.Format = "yyyy-MM-dd"; // Установка формата даты
                            }
                            else {
                                worksheet.Cells[row + 2, col + 1].Value = dt.Rows[row][col];
                            }
                        }
                    }

                    package.Save();
                }

                MessageBox.Show("Отчёт создан успешно", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void button_Click(object sender, EventArgs e) {
            var current = comboBox.SelectedIndex;
            var t1 = dateTimePicker1.Value;
            var t2 = dateTimePicker2.Value;
            var query = "";
            switch (current) {
                case 0:
                    query = $"EXEC GetStudentAbsences @Start = '{t1}', @End = '{t2}';";
                    break;
                case 1:
                    query = $"EXEC GetGroupAbsences @Start = '{t1}', @End = '{t2}';";
                    break;
                case 2:
                    query = $"EXEC GetFacultyAbsences @Start = '{t1}', @End = '{t2}';";
                    break;
                case 3:
                    query = $"EXEC GetStudentNoAbsences @Start = '{t1}', @End = '{t2}';";
                    break;
                case 4:
                    query = $"EXEC GetAvailableRooms @date = '{t1}';";
                    break;
                case 5:
                    query = "EXEC GetRoomUsage;";
                    break;
            }
            using (SqlConnection conn = new SqlConnection(connectionString)) {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            sendDataToExcel(dataGridView, $"{comboBox.Text}", "Отчёт");
        }
    }
}
