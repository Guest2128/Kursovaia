﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class ShowChangeSp : Form {
        public static string connectionString;
        public ShowChangeSp() {
            InitializeComponent();
            fill_ComboBox(comboBox, $"Select название From Факультет");
            comboBox.SelectedIndex = 0;
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
            var query = $"Select название From Специальность Where [id Факультет] in (Select id From Факультет Where название = '{comboBox.Text}')";
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
                MessageBox.Show("Специальность была успешно удалена.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonCreate_Click(object sender, EventArgs e) {
            var name = textBox.Text;
            if (name == "название") {
                MessageBox.Show("Укажите название специальности.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Специальность Where название = '{name}')";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Insert into Специальность Values((Select id From Факультет Where название = '{comboBox.Text}'), '{name}')";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка добавления специальности.\n" + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Специальность была добавлена.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Специальность с таким названием существует.\n",
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
            query("Delete From Расписание Where [id Группа] in (Select id From Группа Where [id Специальность] = " +
                $"(Select id From Специальность Where название = '{name}')) Delete From Студент Where[id Группа] in " +
                $"(Select id From Группа Where [id Специальность] = (Select id From Специальность Where  название = '{name}')) " +
                $"Delete From Группа Where [id Специальность] = (Select id From Специальность Where название = '{name}') " +
                $"Delete From Специальность Where название = '{name}'");
        }

        private void buttonUpdate_Click(object sender, EventArgs e) {
            var name = textBox.Text;
            if (name == "название") {
                MessageBox.Show("Укажите новое название для специальности.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Специальность Where название = '{name}')";
                try {
                    using (SqlConnection connection = new SqlConnection(connectionString)) {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(query, connection)) {
                            if (command.ExecuteScalar() == null) {
                                // Установка строки подключения и создание окна
                                query = $"Update Специальность Set название = '{name}' " +
                                    $"Where название = '{dataGridView.CurrentCell.Value.ToString()}'";
                                try {
                                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                        command2.ExecuteNonQuery();
                                    }
                                }
                                catch (Exception ex) {
                                    MessageBox.Show("Ошибка обновления специальности.\n" + query + ex,
                                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                Fill_Table();
                                MessageBox.Show("Специальность была обновлена.\n",
                                    "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else {
                                MessageBox.Show("Специальность с таким названием существует.\n",
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
            Fill_Table();
        }
    }
}
