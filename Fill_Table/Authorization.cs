using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class Authorization : Form {
        // Создание строки подключения
        static string connectionString = "Server=localhost;Database=Турникет;Trusted_Connection=True;";
        //Server=192.168.100.2;Database=Турникет;User Id = sa; password = '33223311';
        //Server=localhost;Database=Турникет;Trusted_Connection=True;

        public Authorization() {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e) {
                // Создание запроса для валидации пользователя
                string query = "Select 1 Where exists (" +
                        $"Select 1 From Пользователи Where логин = '{textBoxLogin.Text}' and пароль = '{textBoxPassword.Text}')";
            try {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        if (command.ExecuteScalar() != null) {
                            // Установка строки подключения и создание окна
                            var flag = false;
                            if (textBoxLogin.Text == "admin") {
                                flag = true;
                            }
                            Main.connectionString = connectionString;
                            Main main = new Main(flag);
                            main.Show();
                            Visible = false;
                        } else {
                            MessageBox.Show("Отсутствует пользователь с указанным логином или паролем.\n",
                                "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }

                }
            } catch (Exception ex) {
                MessageBox.Show($"{ex}.\n",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
