using System;
using System.Data;
using System.Windows.Forms;

namespace KursachV3
{
    public partial class UpdateArticleForm : Form
    {
        public UpdateArticleForm()
        {
            InitializeComponent();
            comboBox1.DataSource = Article.GetNamesArticles();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

        }

        private void OnChangeArticle(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != "" && comboBox1.SelectedValue != null)
            {
                panel1.Visible = true;
                DataTable table = Db.Select("id,name,limit,type", "articles", "", "",
                    "id=" + ((DataRowView)comboBox1.SelectedItem).Row[0].ToString());
                textBox1.Text = table.Rows[0][1].ToString();
                textBox2.Text = table.Rows[0][2].ToString();
                comboBox2.SelectedIndex = (int)table.Rows[0][3];
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void DeleteArticleButtonClick(object sender, EventArgs e)
        {
            if (Db.Delete("articles", (int) ((DataRowView) comboBox1.SelectedItem).Row[0]))
            {
                MessageBox.Show("Статья удалена");
                Close();
            }
            else
            {
                MessageBox.Show("Статья не удалена");
                Close();
            }
        }

        private void EditButtonClick(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Не заполнено поле");
                return;
            }
            int limit = Convert.ToInt16(textBox2.Text);
            if (limit < 0)
            {
                MessageBox.Show("Неправильный планируемый расход/доход");
                return;
            }
            if (Article.CheckNameArticle(textBox1.Text))
            {
                MessageBox.Show("Имя статьи не должно повторяться");
                return;
            }
            if (Article.UpdateArticle(textBox1.Text, comboBox2.SelectedIndex, limit,(int) ((DataRowView) comboBox1.SelectedItem).Row[0]))
            {
                MessageBox.Show("Статья успешно обновлена");
                Close();
            }
            else
            {
                MessageBox.Show("Произошла ошибка попробуйте еще раз");
            }
        }
    }
}
