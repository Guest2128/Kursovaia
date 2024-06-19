using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class TableWindow : Form {
        public static string connectionString;
        PairWindow pairWindow;
        string dis;
        string prep;
        string aud;
        string aud2;
        public TableWindow() {
            InitializeComponent();
            fill_ComboBox(comboBoxFaculty, "Select название From Факультет");
            comboBoxFaculty.SelectedIndex = 0;
            fill_ComboBox(comboBoxGroup, "Select Группа.название From Группа, Специальность " +
                $"Where [id Специальность] = Специальность.id and [id Факультет] = " +
                $"(Select id From Факультет Where название = '{comboBoxFaculty.Text}')");
            comboBoxGroup.SelectedIndex = 0;
            dataGridViewTable.Columns.Add("Номер пары", "Номер пары");
            for (var i = 0; i < 6; ++i) {
                string day = "";
                switch (i) {
                    case 0:
                        day = "Понедельник";
                        break;
                    case 1:
                        day = "Вторник";
                        break;
                    case 2:
                        day = "Среда";
                        break;
                    case 3:
                        day = "Четверг";
                        break;
                    case 4:
                        day = "Пятница";
                        break;
                    case 5:
                        day = "Суббота";
                        break;
                }
                dataGridViewTable.Columns.Add(day, day);
            }
            for (var i = 0; i < 5; ++i) {
                dataGridViewTable.Rows.Add();
            }
            for (var i = 0; i < dataGridViewTable.Rows.Count;++i) {
                PaintCell(i, 0, Color.LightGray, Color.Red);
                dataGridViewTable.Rows[i].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            PairWindow.connectionString = connectionString;
        }

        private void PaintCell(int rowIndex, int columnIndex, Color backColor, Color foreColor) {
            if (rowIndex >= 0 && rowIndex < dataGridViewTable.Rows.Count &&
                columnIndex >= 0 && columnIndex < dataGridViewTable.Columns.Count) {
                dataGridViewTable.Rows[rowIndex].Cells[columnIndex].Style.BackColor = backColor;
                dataGridViewTable.Rows[rowIndex].Cells[columnIndex].Style.ForeColor = foreColor;
            }
        }

        private void fill_ComboBox(ComboBox comboBox, string query) {
            comboBox.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                try {
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                comboBox.Items.Add(reader["название"].ToString());
                            }
                        }
                    }
                } catch (Exception ex) {
                    MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e) {
            fill_ComboBox(comboBoxGroup, "Select Группа.название From Группа, Специальность " +
                $"Where [id Специальность] = Специальность.id and [id Факультет] = (Select id From Факультет Where название = '{comboBoxFaculty.Text}')");
            comboBoxGroup.SelectedIndex = 0;
        }
        
        private void buttonF_Click(object sender, EventArgs e) {
            var query = "SELECT День.название AS 'День недели', [номер пары] AS 'Номер пары', Корпус.номер AS 'Номер корпуса', Аудитория.название AS 'Аудитория', " +
                "Дисциплина.название AS 'Дисциплина', Преподаватель.ФИО AS 'Преподаватель' FROM Расписание " +
                "INNER JOIN День ON Расписание.[id День] = День.id " +
                "INNER JOIN Пара ON Расписание.[id Пара] = Пара.id " +
                "LEFT JOIN Аудитория ON Расписание.[id Аудитория] = Аудитория.id " +
                "LEFT JOIN Корпус ON Аудитория.[id Корпус] = Корпус.id " +
                "INNER JOIN Дисциплина ON Расписание.[id Дисциплина] = Дисциплина.id " +
                "LEFT JOIN Преподаватель ON Расписание.[id Преподаватель] = Преподаватель.id " +
                "INNER JOIN Группа ON Расписание.[id Группа] = Группа.id " +
                "INNER JOIN Специальность ON Группа.[id Специальность] = Специальность.id " +
                "INNER JOIN Факультет ON Специальность.[id Факультет] = Факультет.id " +
                $"WHERE [id Группа] in (SELECT id From Группа Where название = '{comboBoxGroup.Text}') and " +
                $"[id Факультет] = (SELECT id From Факультет Where название = '{comboBoxFaculty.Text}') " +
                "ORDER BY Пара.id, День.id";
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.ExecuteNonQuery();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        var table = new DataTable();
                        adapter.Fill(table);
                        foreach (DataRow row in table.Rows) {
                            int column = 0;
                            switch (row["День недели"].ToString()) {
                                case "Понедельник":
                                    column = 1;
                                    break;
                                case "Вторник":
                                    column = 2;
                                    break;
                                case "Среда":
                                    column = 3;
                                    break;
                                case "Четверг":
                                    column = 4;
                                    break;
                                case "Пятница":
                                    column = 5;
                                    break;
                                case "Суббота":
                                    column = 6;
                                    break;
                            }
                            var dis = row["Дисциплина"].ToString();
                            var prep = row["Преподаватель"].ToString();
                              if (prep == "") {
                                prep = " ";
                            }
                            var audl = row["Аудитория"].ToString();
                            aud2 = " ";
                            var korpl = row["Номер корпуса"].ToString();
                            var aud = "к. " + korpl + ", ауд. " + audl;
                            dataGridViewTable.Rows[(int)row["Номер пары"] - 1].Cells[0].Value = row["Номер пары"];
                            if (korpl == "" || korpl == " ") {
                                aud = audl;
                                if (audl == ""  ||audl == " ") {
                                    aud = " ";
                                }
                            } else {
                                aud = "к. " + korpl + ", ауд. " + audl;
                                aud2 = audl;
                            }
                            var info = dis + "\n\n" + aud + "\n\n" + prep;
                            dataGridViewTable.Rows[(int)row["Номер пары"] - 1].Cells[column].Value = info;
                        }
                        dataGridViewTable.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells); 
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Введенные данные не соотвествуют формату.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e) {
            if (pairWindow == null || pairWindow.IsDisposed) {
                pairWindow = new PairWindow(dataGridViewTable.CurrentCell.RowIndex + 1,
                    /*dataGridViewTable.CurrentCell.ColumnIndex, */ comboBoxGroup.Text, monthCalendar1.SelectionStart, dis, prep, aud, aud2);
            }
            pairWindow.Show();
            pairWindow.BringToFront();
        }

        private void dataGridViewTable_CurrentCellChanged(object sender, EventArgs e) {
            object cellValue = dataGridViewTable.CurrentCell.Value;
            string cellContent = "";
            if (cellValue != null) {
                cellContent = cellValue.ToString();
            }
            dis = cellContent.Split('\n').Length == 0 ? "" : cellContent.Split('\n')[0];
            aud = cellContent.Split('\n').Length <= 2 ? "" : cellContent.Split('\n')[2];
            aud2 = (aud != "" && aud != " ") ? aud.Substring(aud.IndexOf("ауд.") + 5) : "";
            prep = cellContent.Split('\n').Length <= 4 ? "" : cellContent.Split('\n')[4];
        }
    }
}
