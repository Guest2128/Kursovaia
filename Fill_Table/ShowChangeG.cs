using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class ShowChangeG : Form {
        public static string connectionString;
        public ShowChangeG() {
            InitializeComponent();
            fill_ComboBox(comboBox, $"Select название From Факультет");
            comboBox.SelectedIndex = 0;
            fill_ComboBox(comboBox1, $"Select название From Специальность Where [id Факультет] = " +
                $"(Select id From Факультет Where название = '{comboBox.Text}')");
            comboBox1.SelectedIndex = 0;
            comboBox2.Items.Add("дневная");
            comboBox2.Items.Add("заочная");
            comboBox2.SelectedIndex = 0;
            Fill_Table();
        }

        public void dataGried(DataTable table) {
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = table;
            dataGridView.Visible = true;
        }

        private void textBoxName_Enter(object sender, EventArgs e) {
            if (textBox.Text == "название") {
                textBox.Text = "";
            }
        }

        private void textBoxName_Leave(object sender, EventArgs e) {
            if (textBox.Text == "") {
                textBox.Text = "название";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e) {
            if (textBox1.Text == "год поступления") {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                textBox1.Text = "год поступления";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e) {
            if (textBox2.Text == "год выпуска") {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e) {
            if (textBox2.Text == "") {
                textBox2.Text = "год выпуска";
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

        private void Fill_Table() {
            var query = "Select название, [год поступления], [год выпуска], [форма обучения] From Группа Where [id Специальность] in " +
                $"(Select id From Специальность Where название = '{comboBox1.Text}')";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                var table = new DataTable();
                try {
                    adapter.Fill(table);
                    dataGried(table);
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void query(string query) {
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        command.ExecuteNonQuery();
                    }
                }
                Fill_Table();
                MessageBox.Show("Группа была успешно удалена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            var name = textBox.Text;
            var y1 = textBox1.Text;
            var y2 = textBox2.Text;
            if (name == "название") {
                MessageBox.Show("Укажите название группы.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!int.TryParse(y1, out int result1) || !int.TryParse(y2, out int result2) 
                || 1900 >= int.Parse(y1) || int.Parse(y1) >= int.Parse(y2) || int.Parse(y2) >= 2100) {
                MessageBox.Show("Проверьте, что года являются валидными числами.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Группа Where название = '{name}')";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = "Insert into Группа Values((Select id From Специальность Where название = " +
                                    $"'{comboBox1.Text}'), '{name}', {y1}, {y2}, '{comboBox2.Text}')";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка добавления группы.\n" + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Группа была добавлена.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Группа с таким названием существует.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"{ex}.\n",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            var name = dataGridView.CurrentCell.Value.ToString();
            query($"Delete From Расписание Where [id Группа] = (Select id From Группа Where название = '{name}') " +
                $"Delete From Студент Where[id Группа] = (Select id From Группа Where название = '{name}') " +
                $"Delete From Группа Where название = '{name}'");
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            var name = textBox.Text;
            var y1 = textBox1.Text;
            var y2 = textBox2.Text;
            if (name == "название") {
                MessageBox.Show("Укажите новое название для группы.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (!int.TryParse(y1, out int result1) || !int.TryParse(y2, out int result2)
                || 1900 >= int.Parse(y1) || int.Parse(y1) >= int.Parse(y2) || int.Parse(y2) >= 2100) {
                MessageBox.Show("Проверьте, что года являются валидными числами.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Группа Where название = '{name}')";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Update Группа Set название = '{name}', " +
                                    $"[год поступления] = {y1}, [год выпуска] = {y2}, [форма обучения] = '{comboBox2.Text}'" +
                                    $"Where название = '{dataGridView.CurrentCell.Value.ToString()}'";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка обновления группы.\n" + query + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Группа была обновлёна.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Группа с таким названием существует.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                }
                catch (Exception ex) {
                    MessageBox.Show($"{ex}.\n",
                                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e) {
            fill_ComboBox(comboBox1, $"Select название From Специальность Where [id Факультет] = " +
                $"(Select id From Факультет Where название = '{comboBox.Text}')");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            Fill_Table();
        }
    }
}
