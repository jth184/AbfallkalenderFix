using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ical.Net;
namespace ICSKorrektur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            numericUpDown1.Value = Properties.Settings.Default.Offset;
            checkBox1.Checked = Properties.Settings.Default.Reminder;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Logic.RepairCalendar();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            Logic.Reminder = checkBox1.Checked;
            Properties.Settings.Default.Reminder = Logic.Reminder;
            Properties.Settings.Default.Save();

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Logic.Offset = (int)numericUpDown1.Value;
            Properties.Settings.Default.Offset = Logic.Offset;
            Properties.Settings.Default.Save();
        }
    }
}
