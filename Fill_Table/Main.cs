using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class Main : Form {
        static string connectionString = "Server=localhost;Database=Турникет;Trusted_Connection=True;";
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

        GenerateWindow generateWindow = new GenerateWindow(connectionString);

        private void генерацияToolStripMenuItem_Click(object sender, EventArgs e) {
            if (generateWindow == null || generateWindow.IsDisposed) {
                generateWindow = new GenerateWindow(connectionString);
            }
            generateWindow.Show();
            generateWindow.BringToFront();
        }

        TableWindow tableWindow = new TableWindow(connectionString);

        private void расписаниеToolStripMenuItem_Click(object sender, EventArgs e) {
            if (tableWindow == null || tableWindow.IsDisposed) {
                tableWindow = new TableWindow(connectionString);
            }
            tableWindow.Show();
            tableWindow.BringToFront();
        }

        private void query(string query) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                var adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();
                try {
                    adapter.Fill(table);
                    dataGried(table);
                } catch (Exception ex) {
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

        private string highDirectory(string path) {
            int lastIndex = path.LastIndexOf('\\');
            if (lastIndex != -1) {
                return path.Substring(0, lastIndex);
            } else {
                return path;
            }
        }

        AddInfo addInfo = new AddInfo(connectionString, false);

        private void импортРасписанияToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            string workedDirectory = highDirectory(highDirectory(highDirectory(highDirectory(highDirectory(
                Directory.GetCurrentDirectory()))))) + "\\excel";

            openFileDialog.InitialDirectory = workedDirectory;
            openFileDialog.Filter = "CSV файлы|*.csv|Текстовые файлы|*.txt|Все файлы|*.*";
            openFileDialog.Title = "Выберите файл";

            if (openFileDialog.ShowDialog() == DialogResult.OK) {
                string selectedFileName = openFileDialog.FileName;
                var t = selectedFileName.LastIndexOf("\\") + 1;
                var group = selectedFileName.Substring(t, selectedFileName.LastIndexOf(".") - t);
                string query = "Select 1 Where exists (" +
                    $"Select 1 From Группа Where название = '{group}')";
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        if (command.ExecuteScalar() != null) {
                            DialogResult result = MessageBox.Show("Расписание для этой группы уже есть. Вы хотите его заменить?",
                                "Уведомление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes) {
                                query = $"Delete from Расписание Where [id Группа] = (Select id From Группа Where название = '{group}')";
                                    //$" Delete from Группа Where название = '{group}'";
                                using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                    MessageBox.Show($"Все данные с этой группой были удалены. Удалено записей: {command2.ExecuteNonQuery()}\n",
                                        "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            } else {
                                return;
                            }
                        }
                    }
                }
                var discipline = new String[6];
                var auditory = new String[6];
                var corpus = new String[6];
                var teacher = new String[6];
                int count = 0;
                string pair = "";
                int counter = 0;

                using (StreamReader reader = new StreamReader(selectedFileName, Encoding.GetEncoding(1251))) {
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine().Split(';');
                        if (count > 0) {
                            if (count % 3 == 2) {
                                pair = line[0];
                                for (var i = 0; i < 6; ++i) {
                                    var temp = line[i + 1];
                                    if (temp == "") {
                                        corpus[i] = "";
                                        auditory[i] = "";
                                    } else {
                                        corpus[i] = temp.Split(',')[0];
                                        auditory[i] = temp.Split(',')[1];
                                    }
                                }
                            }
                            
                            if (count % 3 == 1) {
                                Array.Copy(line, 1, discipline, 0, 6);
                            }

                            if (count % 3 == 0) {
                                Array.Copy(line, 1, teacher, 0, 6);
                                for (var i = 0; i < 6; ++i) {
                                    string day = "";
                                    switch (i) {
                                        case 0:
                                            day = "Понедельник";
                                            break;
                                        case 1:
                                            day = "Вторник";
                                            break;
                                        case 2:
                                            day = "Среда";
                                            break;
                                        case 3:
                                            day = "Четверг";
                                            break;
                                        case 4:
                                            day = "Пятница";
                                            break;
                                        case 5:
                                            day = "Суббота";
                                            break;
                                    }
                                    var result = tableWindowInfo(groupInfo(group),
                                        dayInfo(day), pairInfo(pair), auditoryInfo(corpus[i], auditory[i]),
                                        disciplineInfo(discipline[i]), teacherInfo(teacher[i]));
                                    if (result != -1 && result != -2 && result != -3) {
                                        ++counter;
                                    }
                                }
                            }
                        }
                        ++count;
                    }
                }
                MessageBox.Show($"Было успешно добавлено {counter} записей.\n", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                addInfo = new AddInfo(connectionString, false);
            }

        }

        private static int? tableWindowInfo(int groupId, int dayId, int pairId, int? auditoryId, int? disciplineId, int? teacherId) {
            if (groupId == -1 || dayId == -1 || pairId == -1 || auditoryId == -1 || disciplineId == -1 || teacherId == -1) {
                MessageBox.Show("Ошибка добавления пункта расписания.\n", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            if (disciplineId == null) {
                return -2;
            }
            string query = $"Select 1 Where exists (Select 1 From Расписание Where [id Группа] = {groupId} and [id День] = {dayId} and " +
                $"[id Пара] = {pairId} and [id Дисциплина] = {disciplineId}";
            string auditory = auditoryId.ToString();
            if (auditoryId == null) {
                auditory = "null";
                query += $" and [id Аудитория] is {auditory}";
            } else {
                query += $" and [id Аудитория] = {auditory}";
            }
            string teacher = teacherId.ToString();
            if (teacherId == null) {
                teacher = "null";
                query += $" and [id Преподаватель] is {teacher})";
            } else {
                query += $" and [id Преподаватель] = {teacher})";
            }
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    if (command.ExecuteScalar() == null) {
                        query = $"Insert into Расписание Values({groupId}, {dayId}, {pairId}, {auditory}, {disciplineId}, {teacher})";
                        try {
                            using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                command2.ExecuteNonQuery();
                                //    MessageBox.Show($"Успешно добавлен пункт расписания, изменено строк: {command2.ExecuteNonQuery()}.\n",
                                //"Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        } catch (Exception ex) {
                            MessageBox.Show("Ошибка добавления расписания.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } else {
                        return -3;
                    }
                }
                query = $"Select id From Расписание Where [id Группа] = {groupId} and [id День] = {dayId} and [id Пара] = {dayId}" +
                            $" and [id Аудитория] = {auditory} and [id Дисциплина] = {disciplineId} and [id Преподаватель] = {teacher}";
                try {
                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                        return (int?)command2.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int groupInfo(string group) {
            string query = $"Select 1 Where exists (Select 1 From Группа Where название = '{group}')";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    if (command.ExecuteScalar() == null) {
                        query = $"Insert into Группа Values(null, '{group}', null, null, 'дневная')";
                        try {
                            using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                command2.ExecuteNonQuery();
                                //MessageBox.Show($"Успешно добавлена группа '{group}', изменено строк: {command2.ExecuteNonQuery()}.\n",
                                //    "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        } catch (Exception ex) {
                            MessageBox.Show("Ошибка добавления группы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                query = $"Select id From Группа Where название = '{group}'";
                try {
                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                        return (int)command2.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int dayInfo(string day) {
            string query = $"Select id From День Where название = '{day}'";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                try {
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        return (int)command.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int pairInfo(string pair) {
            string query = $"Select id From Пара Where [номер пары] = {pair}";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                try {
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        return (int)command.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int? corpusInfo(string corpus) {
            if (corpus == "") {
                return null;
            }
            string query = $"Select id From Корпус Where номер = {corpus}";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                try {
                    using (SqlCommand command = new SqlCommand(query, connection)) {
                        return (int)command.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int? auditoryInfo(string corpus, string auditory) {
            int? corpusId = corpusInfo(corpus);
            if (corpusId == null) {
                return null;
            }
            string query = $"Select 1 Where exists (Select 1 From Аудитория Where название = '{auditory}' and [id Корпус] = {corpusId})";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    if (command.ExecuteScalar() == null) {
                        query = $"Insert into Аудитория Values({corpusId}, '{auditory}')";
                        try {
                            using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                command2.ExecuteNonQuery();
                                //MessageBox.Show($"Успешно добавлена аудитория '{auditory}', изменено строк: {command2.ExecuteNonQuery()}.\n",
                                //    "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        } catch (Exception ex) {
                            MessageBox.Show("Ошибка добавления аудитории.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                query = $"Select id From Аудитория Where название = '{auditory}' and [id Корпус] = {corpusId}";
                try {
                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                        return (int)command2.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int? disciplineInfo(string discipline) {
            if (discipline == "") {
                return null;
            }
            string query = $"Select 1 Where exists (Select 1 From Дисциплина Where название = '{discipline}')";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    if (command.ExecuteScalar() == null) {
                        try {
                            query = $"Insert into Дисциплина Values('{discipline}')";
                            using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                command2.ExecuteNonQuery();
                                //MessageBox.Show($"Успешно добавлена дисциплина '{discipline}', изменено строк: {command2.ExecuteNonQuery()}.\n",
                                //    "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        } catch (Exception ex) {
                            MessageBox.Show("Ошибка добавления дисциплины.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                query = $"Select id From Дисциплина Where название = '{discipline}'";
                try {
                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                        return (int)command2.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private static int? teacherInfo(string teacher) {
            if (teacher == "") {
                return null;
            }
            string query = $"Select 1 Where exists (Select 1 From Преподаватель Where ФИО = '{teacher}')";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    if (command.ExecuteScalar() == null) {
                        query = $"Insert into Преподаватель Values('{teacher}')";
                        try {
                            using (SqlCommand command2 = new SqlCommand(query, connection)) {
                                command2.ExecuteNonQuery();
                                //MessageBox.Show($"Успешно добавлен преподаватель '{teacher}', изменено строк: {command2.ExecuteNonQuery()}.\n",
                                //    "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        } catch (Exception ex) {
                            MessageBox.Show("Ошибка добавления преподавателя.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                query = $"Select id From Преподаватель Where ФИО = '{teacher}'";
                try {
                    using (SqlCommand command2 = new SqlCommand(query, connection)) {
                        return (int)command2.ExecuteScalar();
                    }
                } catch (Exception) {
                    return -1;
                }
            }
        }

        private void добавитьСпециальностьКГруппеToolStripMenuItem_Click(object sender, EventArgs e) {
            if (addInfo == null || addInfo.IsDisposed) {
                addInfo = new AddInfo(connectionString, false);
            }
            addInfo.Show();
            addInfo.BringToFront();
        }
    }
}
