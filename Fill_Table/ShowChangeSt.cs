using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class ShowChangeSt : Form {
        public static string connectionString;
        public ShowChangeSt() {
            InitializeComponent();
            fill_ComboBox(comboBox, $"Select название From Факультет");
            comboBox.SelectedIndex = 0;
            fill_ComboBox(comboBox1, $"Select название From Специальность Where [id Факультет] = " +
                $"(Select id From Факультет Where название = '{comboBox.Text}')");
            comboBox1.SelectedIndex = 0;
            fill_ComboBox(comboBox3, $"Select название From Группа Where [id Специальность] = " +
                $"(Select id From Специальность Where название = '{comboBox1.Text}')");
            comboBox3.SelectedIndex = 0;
            comboBox2.Items.Add("бюджет");
            comboBox2.Items.Add("платное");
            comboBox2.SelectedIndex = 0;
            Fill_Table();
        }

        public void dataGried(DataTable table) {
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = table;
            dataGridView.Visible = true;
        }

        private void textBox_Enter(object sender, EventArgs e) {
            if (textBox.Text == "Фамилия") {
                textBox.Text = "";
            }
        }

        private void textBox_Leave(object sender, EventArgs e) {
            if (textBox.Text == "") {
                textBox.Text = "Фамилия";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e) {
            if (textBox1.Text == "Имя") {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                textBox1.Text = "Имя";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e) {
            if (textBox2.Text == "Отчество") {
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e) {
            if (textBox2.Text == "") {
                textBox2.Text = "Отчество";
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
            var query = "Select фамилия, имя, отчество, [форма обучения], чип From Студент Where [id Группа] in " +
                $"(Select id From Группа Where название = '{comboBox3.Text}' and [id Специальность] = " +
                $"(Select id From Специальность Where название = '{comboBox1.Text}'))";
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
                MessageBox.Show("Студент был успешно удалён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            var n1 = textBox.Text;
            var n2 = textBox1.Text;
            var n3 = textBox2.Text;
            if (n1 == "Фамилия" || n2 == "Имя" || n3 == "Отчество") {
                MessageBox.Show("Укажите полное имя.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Студент Where фамилия = '{n1}' and имя = '{n2}' and отчество = '{n3}')";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = "Insert into Студент Values((Select id From Группа Where название = " +
                                    $"'{comboBox3.Text}'), CAST(RAND() * 999999999 AS INT), '{n1}', '{n2}', '{n3}', '{comboBox2.Text}')";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка добавления студента.\n" + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Студент был добавлен.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Студент с таким именем существует.\n",
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
            var code = dataGridView.CurrentCell.Value.ToString();
            query($"Delete From Студент Where чип = {code}");
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            var n1 = textBox.Text;
            var n2 = textBox1.Text;
            var n3 = textBox2.Text;
            if (n1 == "Фамилия" || n2 == "Имя" || n3 == "Отчество") {
                MessageBox.Show("Укажите полное имя.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Студент Where фамилия = '{n1}' and имя = '{n2}' and отчество = '{n3}')";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Update Студент Set фамилия = '{n1}', " +
                                    $"имя = '{n2}', отчество = '{n3}', [форма обучения] = '{comboBox2.Text}'" +
                                    $"Where чип = {dataGridView.CurrentCell.Value.ToString()}";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка обновления студента.\n" + query + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Студент был обновлён.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Студент с таким именем существует.\n",
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
            fill_ComboBox(comboBox3, $"Select название From Группа Where [id Специальность] = " +
                $"(Select id From Специальность Where название = '{comboBox1.Text}')");
            comboBox3.SelectedIndex = 0;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e) {
            Fill_Table();
        }
    }
}
