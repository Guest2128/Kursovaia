using System.Data;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class AddInfo : Form {
        public static string connectionString;
        public void dataGried(DataTable table) {
            dataGridViewAdd.AutoGenerateColumns = true;
            dataGridViewAdd.DataSource = table;
            dataGridViewAdd.Visible = true;
        }
        public AddInfo(bool flag) {
            InitializeComponent();
            string query;
            if (!flag) {
                label.Text = "Специальности";
                Text += " Группу";
                query = "Select название as 'Название группы' From Группа Where [id Специальность] is null";
            } else {
                label.Text = "Факультеты";
                Text += " Специальность";
                query = "Select название as 'Название специальности' From Специальность Where [id Факультет] is null";
            }
            Fill_Table(query, flag);
        }

        private void Fill_Table(string query, bool flag) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                var table = new DataTable();
                try {
                    adapter.Fill(table);
                    dataGried(table);
                } catch (Exception ex) {
                    MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                fill_ComboBox(!flag ? "Select название From Специальность" : "Select название From Факультет");
                comboBox.SelectedIndex = 0;
            }
        }

        private void fill_ComboBox(string query) {
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

        private void buttonAdd_Click(object sender, EventArgs e) {
            var name = dataGridViewAdd.CurrentCell;
            if (name == null) {
                MessageBox.Show("Выбрана пустая строка", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string table = Text.Split(' ')[1] == "Группу" ? "Группа" : "Специальность";
            string table2;
            if (table == "Группа") {
                table2 = "Специальность";
            } else {
                table2 = "Факультет";
            }
            var name2 = comboBox.Text;
            string query;
            if (table == "Группа") {
                query = $"Select 1 Where exists (Select 1 From Специальность Where название = '{name2}')";
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        if (command.ExecuteScalar() == null) {
                            DialogResult result = MessageBox.Show("Такой специальности нет. Вы хотите её добавить?",
                                "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes) {
                                query = $"Insert into Специальность Values(null, '{name2}');";
                                try {
                                    new SqlCommand(query, connection).ExecuteNonQuery();
                                } catch (Exception) {
                                    MessageBox.Show($"Ошибка добавления специальности.",
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                AddInfo addInfo = new AddInfo(true);
                                addInfo.ShowDialog();
                                addInfo.BringToFront();
                                query = $"Select 1 Where exists (Select 1 From Специальность Where [id Факультет] is null)";
                                using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                    if (command2.ExecuteScalar() != null) {
                                        MessageBox.Show("Факультет не был добавлен.",
                                            "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        query = $"Delete from Специальность Where название = '{name2}'";
                                        new SqlCommand(query, connection).ExecuteNonQuery();
                                        return;
                                    }
                                }
                            } else {
                                return;
                            }
                        }
                    }
                }
            }
            if (table == "Специальность") {
                query = $"Select 1 Where exists (Select 1 From Факультет Where название = '{name2}')";
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        if (command.ExecuteScalar() == null) {
                            MessageBox.Show("Такого факультета нет.",
                                "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            query = $"Update {table} Set [id {table2}] = (Select id From {table2} Where название = '{name2}') " +
                $"Where название = '{name.Value}'";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                try {
                    MessageBox.Show($"Изменено значений {new SqlCommand(query, connection).ExecuteNonQuery()}.", 
                        "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch (Exception ex) {
                    MessageBox.Show("Ошибка обновления таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            bool flag;
            if (table == "Группа") {
                query = "Select название as 'Название группы' From Группа Where [id Специальность] is null";
                flag = false;
            } else {
                query = "Select название as 'Название специальности' From Специальность Where [id Факультет] is null";
                flag = true;
            }
            Fill_Table(query, flag);
        }
    }
}
