namespace KursachV3
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.статьиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.редактированиеУдалениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.турыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.подборТуровToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.toIntervalDatePicker = new System.Windows.Forms.DateTimePicker();
            this.fromIntervalDatePicker = new System.Windows.Forms.DateTimePicker();
            this.intervalFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.yearFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.threeMonthsFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.monthFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.allTypeFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.consumptionFIlterRadioButton = new System.Windows.Forms.RadioButton();
            this.profitFilterRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.добавитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статьиToolStripMenuItem,
            this.записиToolStripMenuItem,
            this.турыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(818, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // статьиToolStripMenuItem
            // 
            this.статьиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.редактированиеToolStripMenuItem});
            this.статьиToolStripMenuItem.Name = "статьиToolStripMenuItem";
            this.статьиToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
            this.статьиToolStripMenuItem.Text = "Статьи";
            // 
            // добавитьToolStripMenuItem
            // 
            this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(265, 24);
            this.добавитьToolStripMenuItem.Text = "Добавление";
            this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.AddArticleButtonClick);
            // 
            // редактированиеToolStripMenuItem
            // 
            this.редактированиеToolStripMenuItem.Name = "редактированиеToolStripMenuItem";
            this.редактированиеToolStripMenuItem.Size = new System.Drawing.Size(265, 24);
            this.редактированиеToolStripMenuItem.Text = "Редактирование/Удаление";
            this.редактированиеToolStripMenuItem.Click += new System.EventHandler(this.UpdateArticleButtonClick);
            // 
            // записиToolStripMenuItem
            // 
            this.записиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem2,
            this.редактированиеУдалениеToolStripMenuItem});
            this.записиToolStripMenuItem.Name = "записиToolStripMenuItem";
            this.записиToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.записиToolStripMenuItem.Text = "Записи";
            // 
            // добавитьToolStripMenuItem2
            // 
            this.добавитьToolStripMenuItem2.Name = "добавитьToolStripMenuItem2";
            this.добавитьToolStripMenuItem2.Size = new System.Drawing.Size(265, 24);
            this.добавитьToolStripMenuItem2.Text = "Добавление";
            this.добавитьToolStripMenuItem2.Click += new System.EventHandler(this.AddAccountingButtonClick);
            // 
            // редактированиеУдалениеToolStripMenuItem
            // 
            this.редактированиеУдалениеToolStripMenuItem.Name = "редактированиеУдалениеToolStripMenuItem";
            this.редактированиеУдалениеToolStripMenuItem.Size = new System.Drawing.Size(265, 24);
            this.редактированиеУдалениеToolStripMenuItem.Text = "Редактирование/Удаление";
            // 
            // турыToolStripMenuItem
            // 
            this.турыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.подборТуровToolStripMenuItem});
            this.турыToolStripMenuItem.Name = "турыToolStripMenuItem";
            this.турыToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.турыToolStripMenuItem.Text = "Туры";
            // 
            // подборТуровToolStripMenuItem
            // 
            this.подборТуровToolStripMenuItem.Name = "подборТуровToolStripMenuItem";
            this.подборТуровToolStripMenuItem.Size = new System.Drawing.Size(176, 24);
            this.подборТуровToolStripMenuItem.Text = "Подбор туров";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 52);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(523, 317);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.dataGridView1_CellContextMenuStripNeeded);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.toIntervalDatePicker);
            this.groupBox1.Controls.Add(this.fromIntervalDatePicker);
            this.groupBox1.Controls.Add(this.intervalFilterRadioButton);
            this.groupBox1.Controls.Add(this.yearFilterRadioButton);
            this.groupBox1.Controls.Add(this.threeMonthsFilterRadioButton);
            this.groupBox1.Controls.Add(this.monthFilterRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(541, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 222);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтрация";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "по";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "с";
            // 
            // toIntervalDatePicker
            // 
            this.toIntervalDatePicker.Location = new System.Drawing.Point(48, 169);
            this.toIntervalDatePicker.Name = "toIntervalDatePicker";
            this.toIntervalDatePicker.Size = new System.Drawing.Size(151, 22);
            this.toIntervalDatePicker.TabIndex = 5;
            this.toIntervalDatePicker.ValueChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // fromIntervalDatePicker
            // 
            this.fromIntervalDatePicker.Location = new System.Drawing.Point(48, 141);
            this.fromIntervalDatePicker.Name = "fromIntervalDatePicker";
            this.fromIntervalDatePicker.Size = new System.Drawing.Size(151, 22);
            this.fromIntervalDatePicker.TabIndex = 4;
            this.fromIntervalDatePicker.ValueChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // intervalFilterRadioButton
            // 
            this.intervalFilterRadioButton.AutoSize = true;
            this.intervalFilterRadioButton.Location = new System.Drawing.Point(15, 114);
            this.intervalFilterRadioButton.Name = "intervalFilterRadioButton";
            this.intervalFilterRadioButton.Size = new System.Drawing.Size(93, 21);
            this.intervalFilterRadioButton.TabIndex = 3;
            this.intervalFilterRadioButton.TabStop = true;
            this.intervalFilterRadioButton.Text = "Интервал";
            this.intervalFilterRadioButton.UseVisualStyleBackColor = true;
            this.intervalFilterRadioButton.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // yearFilterRadioButton
            // 
            this.yearFilterRadioButton.AutoSize = true;
            this.yearFilterRadioButton.Location = new System.Drawing.Point(15, 87);
            this.yearFilterRadioButton.Name = "yearFilterRadioButton";
            this.yearFilterRadioButton.Size = new System.Drawing.Size(71, 21);
            this.yearFilterRadioButton.TabIndex = 2;
            this.yearFilterRadioButton.TabStop = true;
            this.yearFilterRadioButton.Text = "За год";
            this.yearFilterRadioButton.UseVisualStyleBackColor = true;
            this.yearFilterRadioButton.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // threeMonthsFilterRadioButton
            // 
            this.threeMonthsFilterRadioButton.AutoSize = true;
            this.threeMonthsFilterRadioButton.Location = new System.Drawing.Point(15, 59);
            this.threeMonthsFilterRadioButton.Name = "threeMonthsFilterRadioButton";
            this.threeMonthsFilterRadioButton.Size = new System.Drawing.Size(110, 21);
            this.threeMonthsFilterRadioButton.TabIndex = 1;
            this.threeMonthsFilterRadioButton.TabStop = true;
            this.threeMonthsFilterRadioButton.Text = "За 3 месяца";
            this.threeMonthsFilterRadioButton.UseVisualStyleBackColor = true;
            this.threeMonthsFilterRadioButton.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // monthFilterRadioButton
            // 
            this.monthFilterRadioButton.AutoSize = true;
            this.monthFilterRadioButton.Location = new System.Drawing.Point(15, 32);
            this.monthFilterRadioButton.Name = "monthFilterRadioButton";
            this.monthFilterRadioButton.Size = new System.Drawing.Size(90, 21);
            this.monthFilterRadioButton.TabIndex = 0;
            this.monthFilterRadioButton.TabStop = true;
            this.monthFilterRadioButton.Text = "За месяц";
            this.monthFilterRadioButton.UseVisualStyleBackColor = true;
            this.monthFilterRadioButton.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.allTypeFilterRadioButton);
            this.groupBox2.Controls.Add(this.consumptionFIlterRadioButton);
            this.groupBox2.Controls.Add(this.profitFilterRadioButton);
            this.groupBox2.Location = new System.Drawing.Point(541, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(105, 110);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Типы";
            // 
            // allTypeFilterRadioButton
            // 
            this.allTypeFilterRadioButton.AutoSize = true;
            this.allTypeFilterRadioButton.Location = new System.Drawing.Point(15, 83);
            this.allTypeFilterRadioButton.Name = "allTypeFilterRadioButton";
            this.allTypeFilterRadioButton.Size = new System.Drawing.Size(53, 21);
            this.allTypeFilterRadioButton.TabIndex = 2;
            this.allTypeFilterRadioButton.TabStop = true;
            this.allTypeFilterRadioButton.Text = "Все";
            this.allTypeFilterRadioButton.UseVisualStyleBackColor = true;
            // 
            // consumptionFIlterRadioButton
            // 
            this.consumptionFIlterRadioButton.AutoSize = true;
            this.consumptionFIlterRadioButton.Location = new System.Drawing.Point(16, 56);
            this.consumptionFIlterRadioButton.Name = "consumptionFIlterRadioButton";
            this.consumptionFIlterRadioButton.Size = new System.Drawing.Size(85, 21);
            this.consumptionFIlterRadioButton.TabIndex = 1;
            this.consumptionFIlterRadioButton.TabStop = true;
            this.consumptionFIlterRadioButton.Text = "Расходы";
            this.consumptionFIlterRadioButton.UseVisualStyleBackColor = true;
            this.consumptionFIlterRadioButton.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // profitFilterRadioButton
            // 
            this.profitFilterRadioButton.AutoSize = true;
            this.profitFilterRadioButton.Location = new System.Drawing.Point(16, 29);
            this.profitFilterRadioButton.Name = "profitFilterRadioButton";
            this.profitFilterRadioButton.Size = new System.Drawing.Size(80, 21);
            this.profitFilterRadioButton.TabIndex = 0;
            this.profitFilterRadioButton.TabStop = true;
            this.profitFilterRadioButton.Text = "Доходы";
            this.profitFilterRadioButton.UseVisualStyleBackColor = true;
            this.profitFilterRadioButton.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(171, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Таблица учета статей";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem1,
            this.удалитьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 52);
            // 
            // добавитьToolStripMenuItem1
            // 
            this.добавитьToolStripMenuItem1.Name = "добавитьToolStripMenuItem1";
            this.добавитьToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.добавитьToolStripMenuItem1.Text = "Редактировать";
            // 
            // удалитьToolStripMenuItem
            // 
            this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
            this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.удалитьToolStripMenuItem.Text = "Удалить";
            this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(662, 259);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(144, 114);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Группировка";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 83);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(54, 21);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Нет";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 56);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(115, 21);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "По названию";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 29);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(82, 21);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "По дате";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.ChangeFilter);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 377);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.ChangeFilter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem статьиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редактированиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem турыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem подборТуровToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker toIntervalDatePicker;
        private System.Windows.Forms.DateTimePicker fromIntervalDatePicker;
        private System.Windows.Forms.RadioButton intervalFilterRadioButton;
        private System.Windows.Forms.RadioButton yearFilterRadioButton;
        private System.Windows.Forms.RadioButton threeMonthsFilterRadioButton;
        private System.Windows.Forms.RadioButton monthFilterRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton allTypeFilterRadioButton;
        private System.Windows.Forms.RadioButton consumptionFIlterRadioButton;
        private System.Windows.Forms.RadioButton profitFilterRadioButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.ToolStripMenuItem записиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem редактированиеУдалениеToolStripMenuItem;


    }
}

