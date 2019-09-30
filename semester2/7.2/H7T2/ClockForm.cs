using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace H7T2
{
    public partial class Clock : Form
    {
        public Clock()
        {
            InitializeComponent();
        }

        private void OnTimerTick(object sender, EventArgs e)
        {
            DateUpdate();
        }

        private void DateUpdate()
        {
            this.Time.Text = System.DateTime.Now.ToLongTimeString();
            this.TimeZone.Text = System.TimeZoneInfo.Local.DisplayName;
            string fullDate = System.DateTime.Now.Date.Day.ToString() + "-" + System.DateTime.Now.Date.Month.ToString() + 
                "-" + System.DateTime.Now.Date.Year.ToString() + "\n( " + System.DateTime.Now.DayOfWeek.ToString() + " )";
            this.Date.Text = fullDate;
        }
    }
}
