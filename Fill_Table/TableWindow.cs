using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class TableWindow : Form {
        static string connectionString;
        public TableWindow(string connection) {
            InitializeComponent();
            connectionString = connection;
            fill_ComboBox(comboBoxFaculty, "Select название From Факультет");
            updateGroup();
            comboBoxFaculty.SelectedIndex = 0;
            comboBoxGroup.SelectedIndex = 0;
            dataGridViewTable.Columns.Add("Пара", "Номер пары");
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
            for (var i = 0;i < 5;++i) {
                dataGridViewTable.Rows.Add();
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
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void updateGroup() {
            fill_ComboBox(comboBoxGroup, "Select Группа.название From Группа, Специальность " +
                $"Where[id Специальность] = Специальность.id and[id Факультет] = (Select id From Факультет Where название = '{comboBoxFaculty.Text}')");
        }

        private void comboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e) {
            comboBoxFaculty.SelectedItem = comboBoxFaculty.Text;
            updateGroup();
            comboBoxGroup.SelectedItem = comboBoxGroup.Items[0];
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
                $"WHERE [id Группа] = (SELECT id From Группа Where название = '{comboBoxGroup.Text}') and " +
                $"[id Факультет] = (SELECT id From Факультет Where название = '{comboBoxFaculty.Text}') " +
                "ORDER BY Пара.id, День.id";
            try {
                var connectionString = "Server=localhost;Database=Турникет;Trusted_Connection=True;";
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
                            dataGridViewTable.Rows[(int)row["Номер пары"]].Cells[0].Value = row["Номер пары"];
                            var info = row["Дисциплина"] + "\n" + row["Номер корпуса"] + "\n" + row["Аудитория"] + "\n" + row["Преподаватель"];
                            dataGridViewTable.Rows[(int)row["Номер пары"]].Cells[column].Value = info;
                        }
                        dataGridViewTable.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells); 
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Введенные данные не соотвествуют формату.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e) {

        }

        //string selected;

        //private void dataGridView_SelectionChanged(object sender, EventArgs e) {
        //    selected = dataGridViewTable.SelectedCells[0].ToString();
        //    //Text = selected;
        //    new PairWindow(connectionString, selected);
        //}
    }
}
