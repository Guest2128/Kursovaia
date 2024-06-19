using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System;

namespace Fill_Table {
    public partial class PairWindow : Form {
        public static string connectionString;
        string day;
        string dis;
        string prep;
        string gr;
        string aud;
        string aud2;
        string num;
        public PairWindow(int para, string group, DateTime date, string d, string p, string a, string a2) {
            InitializeComponent();
            day = date.DayOfWeek.ToString();
            gr = group;
            dis = d;
            prep = p;
            aud = a;
            aud2 = a2;
            num = para.ToString();
            switch (day)
            {
                case "Monday":
                    day = "Понедельник";
                    break;
                case "Tuesday":
                    day = "Вторник";
                    break;
                case "Wednesday":
                    day = "Среда";
                    break;
                case "Thursday":
                    day = "Четверг";
                    break;
                case "Friday":
                    day = "Пятница";
                    break;
                case "Saturday":
                    day = "Суббота";
                    break;
            }
            Text = group + "    " + day + "    " + date.ToShortDateString();
            labelDR.Text = dis;
            if (prep != " " && prep != "") {
                labelPR.Text = prep;
            } else {
                labelPR.Text = "не указано";
            }
            if (aud != " " && aud != "") {
                labelAR.Text = aud;
            } else {
                labelAR.Text = "не указано";
            }
            Get_Group(group, date);
        }

        public void dataGried(DataTable table) {
            dataGridViewPair.AutoGenerateColumns = true;
            dataGridViewPair.DataSource = table;
            dataGridViewPair.Visible = true;
        }

        private void Get_Group(string group, DateTime date) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                object k1;
                string t1;
                using (SqlCommand command = new SqlCommand("Select Convert(varchar, [начало пары], 108) " +
                    $"From Пара Where [номер пары] = {num}", connection)) {
                    k1 = command.ExecuteScalar();
                    t1 = k1.ToString();
                    t1 = t1.Substring(0,t1.IndexOf(':', t1.IndexOf(':')  + 1));
                }
                object k2;
                string t2;
                using (SqlCommand command = new SqlCommand("Select Convert (varchar, [конец пары], 108) " +
                    $"From Пара Where [номер пары] = {num}", connection)) {
                    k2 = command.ExecuteScalar();
                    t2 = k2.ToString();
                    t2 = t2.Substring(0, t2.IndexOf(':', t2.IndexOf(':') + 1));
                }
                labelPaR.Text = t1 + " - " + t2;
                //                SqlCommand count = new SqlCommand(
                //                    $"Select count(*) From Студент, Группа Where Группа.id = [id Группа] and название = '{group}'", connection);
                var sql = "Select фамилия as Фамилия, имя as Имя, [Дата и время] as 'Время', вход as Вход " +
                    "From Расписание, Группа, Студент, [Отметка турникета], Дисциплина, День, Пара " +
                    "Where Расписание.[id Группа] = Группа.id and Студент.[id Группа] = Группа.id and Студент.чип = [Отметка турникета].чип and " +
                    "[id Дисциплина] = Дисциплина.id and [id Пара] = Пара.id and День.id = [id День] and " +
                    $"[Номер пары] = {num} and День.название = '{day}' and Группа.название = '{gr}' and Дисциплина.название = '{dis}' and " +
                    $"CONVERT(VARCHAR, [дата и время], 104) = '{date.ToShortDateString()}' and " +
                    $"Convert(Time, [Дата и время]) < Convert(Time, '{k2}')";
                if (aud2 != "" && aud != " ") {
                    sql = "Select фамилия as Фамилия, имя as Имя, [Дата и время] as 'Время', вход as Вход " +
                        "From Расписание, Группа, Студент, [Отметка турникета], Дисциплина, День, Пара, Аудитория " +
                        "Where Расписание.[id Группа] = Группа.id and Студент.[id Группа] = Группа.id and " +
                        "Студент.чип = [Отметка турникета].чип and [id Дисциплина] = Дисциплина.id and [id Пара] = Пара.id and " +
                        "День.id = [id День] and [id Аудитория] = Аудитория.id and " +
                        $"[Номер пары] = {num} and День.название = '{day}' and Группа.название = '{gr}' and " +
                        $"Дисциплина.название = '{dis}' and Аудитория.название = '{aud2}' and " +
                        $"CONVERT(VARCHAR, [дата и время], 104) = '{date.ToShortDateString()}' and " +
                        $"Convert(Time, [Дата и время]) < Convert(Time, '{k2}')";
                }
                if (prep != "" && prep != " ") {
                    sql = "Select фамилия as Фамилия, имя as Имя, [Дата и время] as 'Время', вход as Вход " +
                        "From Расписание, Группа, Студент, [Отметка турникета], Дисциплина, Преподаватель, День, Пара " +
                        "Where Расписание.[id Группа] = Группа.id and Студент.[id Группа] = Группа.id and " +
                        "Студент.чип = [Отметка турникета].чип and [id Дисциплина] = Дисциплина.id and [id Пара] = Пара.id and " +
                        "День.id = [id День] and Преподаватель.id = [id Преподаватель] and " +
                        $"[Номер пары] = {num} and День.название = '{day}' and Преподаватель.ФИО = '{prep}' and Группа.название = '{gr}' and " +
                        $"Дисциплина.название = '{dis}' and CONVERT(VARCHAR, [дата и время], 104) = '{date.ToShortDateString()}' and " +
                        $"Convert(Time, [Дата и время]) < Convert(Time, ' {k2}')";
                }
                if (aud2 != "" && prep != "" && aud2 != " " && prep != " ") {
                    sql = "Select фамилия as Фамилия, имя as Имя, [Дата и время] as 'Время', вход as Вход " +
                        "From Расписание, Группа, Студент, [Отметка турникета], Дисциплина, Преподаватель, День, Пара, Аудитория " +
                        "Where Расписание.[id Группа] = Группа.id and Студент.[id Группа] = Группа.id and " +
                        "Студент.чип = [Отметка турникета].чип and [id Дисциплина] = Дисциплина.id and [id Пара] = Пара.id and " +
                        "День.id = [id День] and Преподаватель.id = [id Преподаватель] and [id Аудитория] = Аудитория.id and " +
                        $"[Номер пары] = {num} and День.название = '{day}' and Преподаватель.ФИО = '{prep}' and Группа.название = '{gr}' and " +
                        $"Дисциплина.название = '{dis}' and Аудитория.название = '{aud2}' and " +
                        $"CONVERT(VARCHAR, [дата и время], 104) = '{date.ToShortDateString()}' and " +
                        $"Convert(Time, [Дата и время]) < Convert(Time, ' {k2}')";
                }
                var adapter = new SqlDataAdapter(sql, connectionString);
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
    }
}
