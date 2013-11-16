using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KursachV3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataTable table = Article.GetArticles(0);
            dataGridView1.DataSource = table;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            toIntervalDatePicker.Enabled = false;
            fromIntervalDatePicker.Enabled = false;
            allTypeFilterRadioButton.Checked = true;
        }

        private void ChangeFilter(object sender, EventArgs e)
        {
            int filtertype = 0;
            if (profitFilterRadioButton.Checked)
            {
                filtertype = 1;
            }
            if (consumptionFIlterRadioButton.Checked)
            {
                filtertype = 2;
            }
            if (monthFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetArticles(filtertype, 1);
            }
            if (threeMonthsFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetArticles(filtertype, 3);
            }
            if (yearFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetArticles(filtertype, 12);
            }
            if (intervalFilterRadioButton.Checked)
            {
                toIntervalDatePicker.MinDate = fromIntervalDatePicker.Value;
                dataGridView1.DataSource = Article.GetArticles(fromIntervalDatePicker.Value, toIntervalDatePicker.Value, filtertype);
                toIntervalDatePicker.Enabled = true;
                fromIntervalDatePicker.Enabled = true;
            }
            else
            {
                toIntervalDatePicker.Enabled = false;
                fromIntervalDatePicker.Enabled = false;
            }
           
        }
    }
}
