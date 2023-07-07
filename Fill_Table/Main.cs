using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class Main : Form {
        public Main() {
            InitializeComponent();
        }

        public void dataGried(DataTable table) {
            dataGridViewT.AutoGenerateColumns = true;
            dataGridViewT.DataSource = table;
            dataGridViewT.Visible = true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        Window window = new Window();

        private void генерацияToolStripMenuItem_Click(object sender, EventArgs e) {
            if (window == null || window.IsDisposed) {
                window = new Window();
            }
            window.Show();
            window.BringToFront();
        }

        private void query(string query) {
            var connectionString = "Server=localhost;Database=Турникет;Trusted_Connection=True;";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                var adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                try {
                    adapter.Fill(table);
                    dataGried(table);
                }
                catch (Exception ex) {
                    MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void корпусToolStripMenuItem_Click(object sender, EventArgs e) {
            query("Select Номер, Адрес From Корпус");
        }

        private void турникетToolStripMenuItem_Click(object sender, EventArgs e) {
            query("Select Адрес as [Корпус], [Номер турникета] From Турникет, Корпус Where Корпус.id = [id Корпус]");
        }

        private void факультетToolStripMenuItem_Click(object sender, EventArgs e) {
            query("Select Адрес as [Корпус], название From Факультет, Корпус Where Корпус.id = [id Корпус]");
        }

        private void специальностьToolStripMenuItem_Click(object sender, EventArgs e) {
            query("Select Факультет.название as [Факультет], Специальность.название From Специальность, Факультет Where Факультет.id = [id Факультет]");
        }

        private void группаToolStripMenuItem_Click(object sender, EventArgs e) {
            query("Select Специальность.название as [Специальность], Группа.Название, [год поступления], [год выпуска], [форма обучения] " +
                    "From Группа, Специальность Where Специальность.id = [id Специальность]");
        }

        private void студентToolStripMenuItem_Click(object sender, EventArgs e) {
            query("Select название as [Группа], чип, фамилия, имя, отчество, Студент.[форма обучения] " +
                    "From Студент, Группа Where Группа.id = [id Группа]");
        }
    }
}
