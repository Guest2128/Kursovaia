using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class ShowChangeT : Form {
        public static string connectionString;
        public ShowChangeT() {
            InitializeComponent();
            fill_ComboBox(comboBox, "Select номер From Корпус");
            comboBox.SelectedIndex = 0;
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

        private void fill_ComboBox(ComboBox comboBox, string query) {
            comboBox.Items.Clear();
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                try {
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        using (SqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                comboBox.Items.Add(reader["номер"].ToString());
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
            var query = "Select номер From Турникет";
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
                MessageBox.Show("Турникет был успешно удалён.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            var num = textBox.Text;
            if (num == "номер") {
                MessageBox.Show("Укажите номер турникета.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Турникет Where номер = {num})";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Insert into Турникет Values((Select id From Корпус Where номер = {comboBox.Text}), {num})";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка добавления турникета.\n" + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Турникет был добавлен.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Турникет с таким номером существует.\n",
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
            query($"Delete [Отметка турникета] Where [id Турникет] = (Select id From Турникет Where номер = {num}) " +
                $"Delete From Турникет Where номер = {num}");
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            var num = textBox.Text;
            if (num == "номер") {
                MessageBox.Show("Укажите новый номер для турникета.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Турникет Where номер = {num})";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Update Турникет Set номер = {num} " +
                                    $"Where номер = '{dataGridView.CurrentCell.Value.ToString()}'";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка обновления турникета.\n" + query + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Турникет был обновлён.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Турникет с таким номером существует.\n",
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
