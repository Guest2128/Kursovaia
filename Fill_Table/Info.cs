using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class Info : Form {
        public Info() {
            InitializeComponent();
            if (comboBoxT.SelectedItem.ToString() == "все")
                textBoxT.Visible = false;
            if (comboBoxS.SelectedItem.ToString() == "все")
                textBoxS.Visible = false;
        }

        public void dataGried(DataTable table) {
            dataGridViewT.AutoGenerateColumns = true;
            dataGridViewT.DataSource = table;
            dataGridViewT.Visible = true;
        }

        private void buttonF_Click(object sender, EventArgs e) {
            var tur = comboBoxT.Text;
            var stud = comboBoxS.Text;
            var all = "все";
            try {
                if (tur != all)
                    if (int.TryParse(textBoxT.Text, out int number))
                        tur = number.ToString();
                    else
                        if (tur.Length == 0)
                            throw new Exception("Вы ничего не ввели в поле турникета.");
                        else
                            throw new Exception("Должно быть введено число в поле турникета.");
                if (stud != all)
                    if (int.TryParse(textBoxS.Text, out int number))
                        stud = number.ToString();
                    else
                        if (stud.Length == 0)
                        throw new Exception("Вы ничего не ввели в поле студента.");
                    else
                        throw new Exception("Должно быть введено число в поле студента.");
                var connectionString = "Server=localhost;Database=Турникет;Trusted_Connection=True;";
                var sql = "Select [Номер турникета] as Турникет, Студент.id, фамилия, имя, отчество, вход, [дата и время] " +
                    "From [Отметка турникета], Турникет, Студент Where [id Турникет] = Турникет.id and [Отметка турникета].чип = Студент.чип";
                var sqlS = " and Студент.id = ";
                var sqlT = " and Турникет.[номер турникета] = ";
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    SqlDataAdapter adapter;
                    if (tur == all && stud == all)
                        adapter = new SqlDataAdapter(sql, connection);
                    else
                        if (tur == all)
                            adapter = new SqlDataAdapter(sql + sqlS + int.Parse(stud), connection);
                    else
                        if (stud == all)
                            adapter = new SqlDataAdapter(sql + sqlT + int.Parse(tur), connection);
                    else
                        adapter = new SqlDataAdapter(sql + sqlS + int.Parse(stud) + sqlT + int.Parse(tur), connection);
                    var table = new DataTable();
                    try {
                        adapter.Fill(table);
                        dataGried(table);
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Введенные данные не соотвествуют формату.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBoxT_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxT.SelectedItem.ToString() == "все")
                textBoxT.Visible = false;
            else
                textBoxT.Visible = true;
        }

        private void comboBoxS_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBoxS.SelectedItem.ToString() == "все")
                textBoxS.Visible = false;
            else
                textBoxS.Visible = true;
        }
    }
}
