using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

namespace Fill_Table {
    public partial class Window : Form {
        public Window() {
            InitializeComponent();
        }
        int Generate(long l, long r, Random random) {
            return random.Next(l, r);
        }
        private void buttonGKol_Click(object sender, EventArgs e) {
            Random r = new Random();
            DateTime dataGen() { 
                DateTime dateS = DateTime.Parse(dateTimePickerS.Text);
                DateTime dateF = DateTime.Parse(dateTimePickerF.Text);
                TimeSpan range = dateF.Subtract(dateS);
                DateTime dateTime;
                while (true) {
                    dateTime = dateS.AddDays(Generate(0, range.Days, r));
                    if (dateTime.DayOfWeek != DayOfWeek.Saturday || dateTime.DayOfWeek != DayOfWeek.Sunday)
                        break;
                }
                dateTime = dateTime.AddHours(Generate(8, 22, r));
                dateTime = dateTime.AddMinutes(Generate(0, 59, r));
                dateTime = dateTime.AddSeconds(Generate(0, 59, r));
                //MessageBox.Show($"{dateTime}", "result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return dateTime;
            }
            long chipGen() {
                return Generate(100_000_000_000, 999_999_999_999, r);
            }
        }
    }
}
