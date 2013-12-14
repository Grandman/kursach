using System;
using System.Data;
using System.Windows.Forms;

namespace KursachV3
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DataTable table = Article.GetAccounting(0);
            dataGridView1.DataSource = table;
            toIntervalDatePicker.Enabled = false;
            fromIntervalDatePicker.Enabled = false;
            allTypeFilterRadioButton.Checked = true;
            monthFilterRadioButton.Checked = true;
            radioButton3.Checked = true;
        }

        private void ChangeFilter(object sender, EventArgs e)
        {
            string groupby = "";
            if (radioButton1.Checked)
            {
                groupby = "date";    
            }
            if (radioButton2.Checked)
            {
                groupby = "name";
            }
            if (groupby == "")
            {
                profitFilterRadioButton.Enabled = true;
                consumptionFIlterRadioButton.Enabled = true;
                allTypeFilterRadioButton.Enabled = true;
            }
            else
            {
                profitFilterRadioButton.Enabled = false;
                consumptionFIlterRadioButton.Enabled = false;
                allTypeFilterRadioButton.Enabled = false;
            }
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
                dataGridView1.DataSource = Article.GetAccounting(filtertype, 1, groupby);
            }
            if (threeMonthsFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetAccounting(filtertype, 3, groupby);
            }
            if (yearFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetAccounting(filtertype, 12, groupby);
            }
            if (intervalFilterRadioButton.Checked)
            {
                toIntervalDatePicker.MinDate = fromIntervalDatePicker.Value;
                dataGridView1.DataSource = Article.GetAccounting(fromIntervalDatePicker.Value, toIntervalDatePicker.Value, filtertype, groupby);
                toIntervalDatePicker.Enabled = true;
                fromIntervalDatePicker.Enabled = true;
            }
            else
            {
                toIntervalDatePicker.Enabled = false;
                fromIntervalDatePicker.Enabled = false;
            }

        }

        private void dataGridView1_CellContextMenuStripChanged(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString());
        }

        private void dataGridView1_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position);
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedRow = dataGridView1.CurrentCell.RowIndex;
            var dataGridViewCell = dataGridView1[0, selectedRow];
            if (dataGridViewCell == null || dataGridViewCell.Value.ToString() == "") 
                return;
            if (Article.DeleteArticle(Convert.ToInt16(dataGridViewCell.Value)))
                MessageBox.Show("Запись удалена");
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
                dataGridView1.DataSource = Article.GetAccounting(filtertype, 1);
            }
            if (threeMonthsFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetAccounting(filtertype, 3);
            }
            if (yearFilterRadioButton.Checked)
            {
                dataGridView1.DataSource = Article.GetAccounting(filtertype, 12);
            }
            if (intervalFilterRadioButton.Checked)
            {
                toIntervalDatePicker.MinDate = fromIntervalDatePicker.Value;
                dataGridView1.DataSource = Article.GetAccounting(fromIntervalDatePicker.Value, toIntervalDatePicker.Value, filtertype,"name");
                toIntervalDatePicker.Enabled = true;
                fromIntervalDatePicker.Enabled = true;
            }
            else
            {
                toIntervalDatePicker.Enabled = false;
                fromIntervalDatePicker.Enabled = false;
            }
        }

        private void AddArticleButtonClick(object sender, EventArgs e)
        {
            AddArticleForm addArticleForm = new AddArticleForm();
            addArticleForm.ShowDialog();
        }

        private void UpdateArticleButtonClick(object sender, EventArgs e)
        {
            UpdateArticleForm updateArticleForm = new UpdateArticleForm();
            updateArticleForm.ShowDialog();
        }

        private void AddAccountingButtonClick(object sender, EventArgs e)
        {
            AddAcountingForm addAcountingForm = new AddAcountingForm();
            addAcountingForm.ShowDialog();
        }
    }
}
