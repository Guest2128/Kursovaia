using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class ShowChangeK : Form {
        public static string connectionString;
        public ShowChangeK() {
            InitializeComponent();
            Fill_Table();
        }

        public void dataGried(DataTable table) {
            dataGridView.AutoGenerateColumns = true;
            dataGridView.DataSource = table;
            dataGridView.Visible = true;
        }

        private void textBox_Enter(object sender, EventArgs e) {
            if (textBox.Text == "номер") {
                textBox.Text = "";
            }
        }

        private void textBox_Leave(object sender, EventArgs e) {
            if (textBox.Text == "") {
                textBox.Text = "номер";
            }
        }

        private void textBox1_Enter(object sender, EventArgs e) {
            if (textBox1.Text == "адрес") {
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e) {
            if (textBox1.Text == "") {
                textBox1.Text = "адрес";
            }
        }

        private void Fill_Table() {
            var query = "Select номер, адрес From Корпус";
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
                MessageBox.Show("Корпус был успешно удалён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            var num = textBox.Text;
            var adr = textBox1.Text;
            if (num == "номер") {
                MessageBox.Show("Укажите номер корпуса.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (adr == "адрес") {
                MessageBox.Show("Укажите адрес корпуса.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Корпус Where номер = {num})";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Insert into Корпус Values(({num}), '{adr}')";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка добавления корпуса.\n" + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Корпус был добавлен.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Корпус с таким номером существует.\n",
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
            var num = dataGridView.CurrentCell.Value.ToString();
            query("Delete From [Отметка турникета] Where [id Турникет] in (Select id From Турникет Where [id Корпус] = " +
                $"(Select id From Корпус Where номер = {num})) Delete From Турникет Where [id Корпус] = (Select id From Корпус Where номер = {num}) " +
                $"Delete From Аудитория Where [id Корпус] = (Select id From Корпус Where номер = {num}) Delete From Студент Where [id Группа] in " +
                "(Select id From Группа Where [id Специальность] in (Select id From Специальность Where [id Факультет] in " +
                $"(Select id From Факультет Where [id Корпус] = (Select id From Корпус Where номер = {num})))) Delete From Расписание Where [id Группа] in " +
                "(Select id From Группа Where [id Специальность] in (Select id From Специальность Where [id Факультет] in " +
                $"(Select id From Факультет Where [id Корпус] = (Select id From Корпус Where номер = {num})))) Delete From Студент Where [id Группа] in " +
                "(Select id From Группа Where [id Специальность] in (Select id From Специальность Where [id Факультет] in " +
                $"(Select id From Факультет Where [id Корпус] = (Select id From Корпус Where номер = {num})))) " +
                "Delete From Группа Where [id Специальность] in (Select id From Специальность Where [id Факультет] in " +
                $"(Select id From Факультет Where [id Корпус] = (Select id From Корпус Where номер = {num}))) " +
                "Delete From Специальность Where [id Факультет] in (Select id From Факультет Where [id Корпус] = " +
                $"(Select id From Корпус Where номер = {num})) Delete From Факультет Where [id Корпус] = (Select id From Корпус Where номер = {num}) " +
                $"Delete From Корпус Where номер = {num}");
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            var num = textBox.Text;
            var adr = textBox1.Text;
            if (num == "номер") {
                MessageBox.Show("Укажите номер корпуса.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (adr == "адрес") {
                MessageBox.Show("Укажите адрес корпуса.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Корпус Where номер = {num})";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Update Корпус Set номер = {num}, адрес = '{adr}' " +
                                    $"Where номер = {dataGridView.CurrentCell.Value.ToString()}";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка обновления корпуса.\n" + query + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Корпус был обновлён.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Корпус с таким номером существует.\n",
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
    }
}
