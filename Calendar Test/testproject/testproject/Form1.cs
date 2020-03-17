using Pabo.Calendar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace testproject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FormatDates();
        }

        private void FormatDates()
        {
            DateItem[] d = new DateItem[5];
            d.Initialize();
            for (int i = 0; i < 5; i++)
                d[i] = new DateItem();

            d[0].Date = new DateTime(2020, 3, 3);
            d[0].BackColor1 = Color.Red;
            d[0].ImageListIndex = 3;
            d[0].Text = "Help";
            d[1].Date = new DateTime(2020, 3, 12);
            d[1].ImageListIndex = 2;
            d[2].Date = new DateTime(2020, 3, 16);
            d[2].BackColor1 = Color.LightBlue;
            d[2].ImageListIndex = 8;
            d[3].Date = new DateTime(2020, 3, 18);
            d[3].BackColor1 = Color.GreenYellow;
            d[3].ImageListIndex = 1;
            d[3].Text = "NorDev";
            d[4].Date = new DateTime(2020, 3, 22);
            d[4].ImageListIndex = 1;
            d[4].Text = "Cebit";

            monthCalendar2.AddDateInfo(d);
        }

        private void monthCalendar2_DayClick(object sender, DayClickEventArgs e)
        {
            label1.Text = monthCalendar2.SelectedDates[0].ToString();
        }
    }
}
