using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class PairWindow : Form {
        static string connectionString;
        public PairWindow(string connection, int i, int j, string group) {
            InitializeComponent();
            connectionString = connection;
            Get_Group(i, j, group);
        }
        private void Get_Group(int i, int j, string group) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand count = new SqlCommand(
                    $"Select count(*) From Студент, Группа Where Группа.id = [id Группа] and название = '{group}'", connection);
                SqlCommand students = new SqlCommand(
                    "Select фамилия as Фамилия, имя as Имя {} as Присутствие на паре" +
                    "From Студент, [Отметка турникета] Where Студент.чип = [Отметка турникета].чип and вход is true", connection);
            }
        }

        private void button_Click(object sender, System.EventArgs e) {

        }
    }
}
