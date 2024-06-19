using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class Users_reg : Form {
        public static string connectionString;
        public Users_reg() {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e) {
            // Создание запроса для добавления пользователя
            string query = "Select 1 Where exists (" +
                    $"Select 1 From Пользователи Where логин = '{textBoxLogin.Text}')";
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        if (command.ExecuteScalar() == null) {
                            // Установка строки подключения и создание окна
                            query = $"Insert into Пользователи Values('{textBoxLogin.Text}', '{textBoxPassword.Text}')";
                            try {
                                using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                    command2.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex) {
                                MessageBox.Show("Ошибка добавления пользователя.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            MessageBox.Show("Пользователь был добавлен.\n",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else {
                            MessageBox.Show("Пользователь уже существует.\n",
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
