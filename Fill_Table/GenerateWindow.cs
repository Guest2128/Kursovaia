﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Fill_Table {
    public partial class GenerateWindow : Form {
        static string connectionString;
        public GenerateWindow(string connection) {
            InitializeComponent();
            connectionString = connection;
        }

        private void buttonGKol_Click(object sender, EventArgs e) {
            var random = new Random();
            int Generate(int l, int r) {
                return random.Next(l, r);
            }

            DateTime dataGen() {
                var dateS = DateTime.Parse(dateTimePickerS.Text);
                var dateF = DateTime.Parse(dateTimePickerF.Text);
                var range = dateF.Subtract(dateS);
                DateTime dateTime;
                while (true) {
                    dateTime = dateS.AddDays(Generate(0, range.Days + 1));
                    if (dateTime.DayOfWeek != DayOfWeek.Saturday || dateTime.DayOfWeek != DayOfWeek.Sunday)
                        break;
                }
                dateTime = dateTime.AddHours(Generate(8, 23));
                dateTime = dateTime.AddMinutes(Generate(0, 60));
                dateTime = dateTime.AddSeconds(Generate(0, 60));
                return dateTime;
            }

            DateTime dataGen2(DateTime dateTime) {
                return dateTime.AddHours(Generate(0, 23 - dateTime.Hour));
            }

            int checkKol() {
                var value = 0;
                try {
                    if (textBoxKol.Text.Length == 0)
                        throw new Exception("Не введено количество входов.");
                    value = int.Parse(textBoxKol.Text);
                }
                catch (Exception ex) {
                    MessageBox.Show("Введенные данные не соотвествуют формату числа в поле количества входов.\n" + ex, "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return value;
            }

            var kol = checkKol();
            if (kol != 0) {
                using (SqlConnection connection = new SqlConnection(connectionString)) {
                    connection.Open();
                    SqlCommand sChipGen = new SqlCommand(
                        "Declare Курсор_Студент Cursor For Select id From Студент Open Курсор_Студент Declare @id int, @чип bigint " +
                        "Fetch Курсор_Студент Into @id While @@FETCH_STATUS = 0 Begin Set @чип = CAST(RAND() * 999999999 AS INT) " +
                        "Update[Отметка турникета] Set чип = @чип Where чип = (Select чип From Студент Where id = @id) " +
                        "Update Студент Set чип = @чип Where id = @id " +
                        "Fetch Курсор_Студент Into @id End Close Курсор_Студент Deallocate Курсор_Студент", connection);
                    sChipGen.ExecuteNonQuery();
                    for (var i = 0; i < kol; ++i) {
                        int genID;
                        while (true) {
                            int sq;
                            using (var squery = new SqlCommand("Select max(id) From Турникет", connection)) {
                                sq = int.Parse(squery.ExecuteScalar().ToString());
                            }
                            genID = Generate(1, sq + 1);
                            int check;
                            using (var squery = new SqlCommand($"Select count(*) From Турникет Where id = {genID}", connection)) {
                                check = int.Parse(squery.ExecuteScalar().ToString());
                            }
                            if (check > 0) {
                                break;
                            }
                        }
                        int genS;
                        while (true) {
                            int sq;
                            using (var squery = new SqlCommand("Select max(id) From Студент", connection)) {
                                sq = int.Parse(squery.ExecuteScalar().ToString());
                            }
                            genS = Generate(1, sq + 1);
                            int check;
                            using (var squery = new SqlCommand($"Select count(*) From Студент Where id = {genS}", connection)) {
                                check = int.Parse(squery.ExecuteScalar().ToString());
                            }
                            if (check > 0) {
                                break;
                            }
                        }
                        int chip;
                        using (var squery = new SqlCommand("Select чип " + $"From Студент Where id = {genS}", connection)) {
                            chip = int.Parse(squery.ExecuteScalar().ToString());
                        }
                        var dateTime = dataGen();
                        SqlCommand sFilling = 
                            new SqlCommand($"Insert [Отметка турникета] Values ({genID}, {chip}, {1}, '{dateTime}')", connection);
                        sFilling.ExecuteNonQuery();
                        dateTime = dataGen2(dateTime);
                        sFilling =
                            new SqlCommand($"Insert [Отметка турникета] Values ({genID}, {chip}, {0}, '{dateTime}')", connection);
                        sFilling.ExecuteNonQuery();
                    }
                    MessageBox.Show("Выполнено успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        Info info = new Info(connectionString);

        private void buttonShow_Click(object sender, EventArgs e) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                var adapter = new SqlDataAdapter("Select [Номер турникета] as Турникет, Студент.id, фамилия, имя, отчество, вход, [дата и время] " +
                    "From [Отметка турникета], Турникет, Студент Where [id Турникет] = Турникет.id and [Отметка турникета].чип = Студент.чип", connection);
                DataTable table = new DataTable();
                try {     
                    adapter.Fill(table);
                    if (info == null || info.IsDisposed) {
                        info = new Info(connectionString);
                    }
                    info.Show();
                    info.BringToFront();
                    info.dataGried(table);
                } catch (Exception ex) {
                    MessageBox.Show("Ошибка отображения данных таблицы.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                connection.Open();
                SqlCommand sChipGen = new SqlCommand("Delete [Отметка турникета]", connection);
                sChipGen.ExecuteNonQuery();
            }
            MessageBox.Show("Выполнено успешно.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
