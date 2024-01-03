using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class PairWindow : Form {
        static string connectionString;
        public PairWindow(string connection, string selected) {
            InitializeComponent();
            connectionString = connection;
            Get_Group(selected);
        }
        private void Get_Group(string selected) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand count = new SqlCommand(
                    "Select count() " +
                    "From Студент, Группа, Специальность, Расписание Where Группа.id = [id Группа] and Специальность.id = [id Специальность] and " +
                    $"Расписание.id = [id Расписание] and Специальность.название = {selected}", connection);
                SqlCommand students = new SqlCommand(
                    "Select фамилия " +
                    "From Студент, [Отметка турникета] Where Студент.чип = [Отметка турникета].чип and вход is true", connection);
            }
        }
    }
}
