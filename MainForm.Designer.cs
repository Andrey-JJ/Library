namespace Library
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.DataBaseDGV = new System.Windows.Forms.DataGridView();
            this.bdTableTree = new System.Windows.Forms.TreeView();
            this.tCActions = new System.Windows.Forms.TabControl();
            this.tPInsert = new System.Windows.Forms.TabPage();
            this.btnInsert = new System.Windows.Forms.Button();
            this.tPUpdate_Delete = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tPAdditional = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnUpdate = new System.Windows.Forms.Button();
            this.nUDIns2 = new System.Windows.Forms.NumericUpDown();
            this.lbIns6 = new System.Windows.Forms.Label();
            this.nUDIns1 = new System.Windows.Forms.NumericUpDown();
            this.lbIns5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbIns4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lbIns3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbIns2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lbIns1 = new System.Windows.Forms.Label();
            this.dtPIns1 = new System.Windows.Forms.DateTimePicker();
            this.dtPIns2 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseDGV)).BeginInit();
            this.tCActions.SuspendLayout();
            this.tPInsert.SuspendLayout();
            this.tPUpdate_Delete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns1)).BeginInit();
            this.SuspendLayout();
            // 
            // DataBaseDGV
            // 
            this.DataBaseDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataBaseDGV.Location = new System.Drawing.Point(205, 12);
            this.DataBaseDGV.Name = "DataBaseDGV";
            this.DataBaseDGV.RowHeadersWidth = 51;
            this.DataBaseDGV.RowTemplate.Height = 24;
            this.DataBaseDGV.Size = new System.Drawing.Size(752, 379);
            this.DataBaseDGV.TabIndex = 5;
            this.DataBaseDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataBaseDGV_CellClick);
            // 
            // bdTableTree
            // 
            this.bdTableTree.Location = new System.Drawing.Point(12, 12);
            this.bdTableTree.Name = "bdTableTree";
            this.bdTableTree.Size = new System.Drawing.Size(187, 379);
            this.bdTableTree.TabIndex = 4;
            this.bdTableTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.bdTableTree_BeforeSelect);
            // 
            // tCActions
            // 
            this.tCActions.Controls.Add(this.tPInsert);
            this.tCActions.Controls.Add(this.tPUpdate_Delete);
            this.tCActions.Controls.Add(this.tPAdditional);
            this.tCActions.Location = new System.Drawing.Point(12, 398);
            this.tCActions.Name = "tCActions";
            this.tCActions.SelectedIndex = 0;
            this.tCActions.Size = new System.Drawing.Size(945, 166);
            this.tCActions.TabIndex = 3;
            // 
            // tPInsert
            // 
            this.tPInsert.Controls.Add(this.dtPIns2);
            this.tPInsert.Controls.Add(this.dtPIns1);
            this.tPInsert.Controls.Add(this.lbIns1);
            this.tPInsert.Controls.Add(this.comboBox1);
            this.tPInsert.Controls.Add(this.nUDIns2);
            this.tPInsert.Controls.Add(this.lbIns6);
            this.tPInsert.Controls.Add(this.nUDIns1);
            this.tPInsert.Controls.Add(this.lbIns5);
            this.tPInsert.Controls.Add(this.textBox3);
            this.tPInsert.Controls.Add(this.lbIns4);
            this.tPInsert.Controls.Add(this.textBox2);
            this.tPInsert.Controls.Add(this.lbIns3);
            this.tPInsert.Controls.Add(this.textBox1);
            this.tPInsert.Controls.Add(this.lbIns2);
            this.tPInsert.Controls.Add(this.btnInsert);
            this.tPInsert.Location = new System.Drawing.Point(4, 25);
            this.tPInsert.Name = "tPInsert";
            this.tPInsert.Padding = new System.Windows.Forms.Padding(3);
            this.tPInsert.Size = new System.Drawing.Size(937, 137);
            this.tPInsert.TabIndex = 0;
            this.tPInsert.Text = "Добавление";
            this.tPInsert.UseVisualStyleBackColor = true;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(758, 90);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(173, 41);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Text = "Выполнить";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // tPUpdate_Delete
            // 
            this.tPUpdate_Delete.Controls.Add(this.btnUpdate);
            this.tPUpdate_Delete.Controls.Add(this.btnDelete);
            this.tPUpdate_Delete.Location = new System.Drawing.Point(4, 25);
            this.tPUpdate_Delete.Name = "tPUpdate_Delete";
            this.tPUpdate_Delete.Padding = new System.Windows.Forms.Padding(3);
            this.tPUpdate_Delete.Size = new System.Drawing.Size(937, 137);
            this.tPUpdate_Delete.TabIndex = 1;
            this.tPUpdate_Delete.Text = "Изменение";
            this.tPUpdate_Delete.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(758, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(173, 41);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tPAdditional
            // 
            this.tPAdditional.Location = new System.Drawing.Point(4, 25);
            this.tPAdditional.Name = "tPAdditional";
            this.tPAdditional.Size = new System.Drawing.Size(937, 137);
            this.tPAdditional.TabIndex = 2;
            this.tPAdditional.Text = "Выборка";
            this.tPAdditional.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(963, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 379);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(579, 90);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 41);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // nUDIns2
            // 
            this.nUDIns2.Location = new System.Drawing.Point(6, 78);
            this.nUDIns2.Name = "nUDIns2";
            this.nUDIns2.Size = new System.Drawing.Size(87, 22);
            this.nUDIns2.TabIndex = 21;
            // 
            // lbIns6
            // 
            this.lbIns6.AutoSize = true;
            this.lbIns6.Location = new System.Drawing.Point(3, 59);
            this.lbIns6.Name = "lbIns6";
            this.lbIns6.Size = new System.Drawing.Size(83, 16);
            this.lbIns6.TabIndex = 20;
            this.lbIns6.Text = "Кол-во книг";
            this.lbIns6.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns6.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns6.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // nUDIns1
            // 
            this.nUDIns1.Location = new System.Drawing.Point(659, 23);
            this.nUDIns1.Name = "nUDIns1";
            this.nUDIns1.Size = new System.Drawing.Size(87, 22);
            this.nUDIns1.TabIndex = 19;
            // 
            // lbIns5
            // 
            this.lbIns5.AutoSize = true;
            this.lbIns5.Location = new System.Drawing.Point(749, 3);
            this.lbIns5.Name = "lbIns5";
            this.lbIns5.Size = new System.Drawing.Size(48, 16);
            this.lbIns5.TabIndex = 18;
            this.lbIns5.Text = "Отдел";
            this.lbIns5.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns5.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns5.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(474, 23);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(179, 22);
            this.textBox3.TabIndex = 17;
            // 
            // lbIns4
            // 
            this.lbIns4.AutoSize = true;
            this.lbIns4.Location = new System.Drawing.Point(656, 3);
            this.lbIns4.Name = "lbIns4";
            this.lbIns4.Size = new System.Drawing.Size(51, 16);
            this.lbIns4.TabIndex = 16;
            this.lbIns4.Text = "Объем";
            this.lbIns4.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns4.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns4.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(242, 23);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(226, 22);
            this.textBox2.TabIndex = 15;
            // 
            // lbIns3
            // 
            this.lbIns3.AutoSize = true;
            this.lbIns3.Location = new System.Drawing.Point(471, 3);
            this.lbIns3.Name = "lbIns3";
            this.lbIns3.Size = new System.Drawing.Size(100, 16);
            this.lbIns3.TabIndex = 14;
            this.lbIns3.Text = "Автор/Авторы";
            this.lbIns3.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns3.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns3.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 24);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 22);
            this.textBox1.TabIndex = 13;
            // 
            // lbIns2
            // 
            this.lbIns2.AutoSize = true;
            this.lbIns2.Location = new System.Drawing.Point(239, 3);
            this.lbIns2.Name = "lbIns2";
            this.lbIns2.Size = new System.Drawing.Size(65, 16);
            this.lbIns2.TabIndex = 12;
            this.lbIns2.Text = "Издание";
            this.lbIns2.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns2.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns2.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(752, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 24);
            this.comboBox1.TabIndex = 22;
            // 
            // lbIns1
            // 
            this.lbIns1.AutoSize = true;
            this.lbIns1.Location = new System.Drawing.Point(3, 3);
            this.lbIns1.Name = "lbIns1";
            this.lbIns1.Size = new System.Drawing.Size(73, 16);
            this.lbIns1.TabIndex = 23;
            this.lbIns1.Text = "Название";
            this.lbIns1.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns1.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns1.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // dtPIns1
            // 
            this.dtPIns1.Location = new System.Drawing.Point(659, 23);
            this.dtPIns1.Name = "dtPIns1";
            this.dtPIns1.Size = new System.Drawing.Size(200, 22);
            this.dtPIns1.TabIndex = 24;
            this.dtPIns1.Visible = false;
            // 
            // dtPIns2
            // 
            this.dtPIns2.Location = new System.Drawing.Point(6, 78);
            this.dtPIns2.Name = "dtPIns2";
            this.dtPIns2.Size = new System.Drawing.Size(200, 22);
            this.dtPIns2.TabIndex = 25;
            this.dtPIns2.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 576);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DataBaseDGV);
            this.Controls.Add(this.bdTableTree);
            this.Controls.Add(this.tCActions);
            this.Name = "MainForm";
            this.Text = "База данных Библиотеки";
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseDGV)).EndInit();
            this.tCActions.ResumeLayout(false);
            this.tPInsert.ResumeLayout(false);
            this.tPInsert.PerformLayout();
            this.tPUpdate_Delete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataBaseDGV;
        private System.Windows.Forms.TreeView bdTableTree;
        private System.Windows.Forms.TabControl tCActions;
        private System.Windows.Forms.TabPage tPInsert;
        private System.Windows.Forms.TabPage tPUpdate_Delete;
        private System.Windows.Forms.TabPage tPAdditional;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NumericUpDown nUDIns2;
        private System.Windows.Forms.Label lbIns6;
        private System.Windows.Forms.NumericUpDown nUDIns1;
        private System.Windows.Forms.Label lbIns5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbIns4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lbIns3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbIns2;
        private System.Windows.Forms.Label lbIns1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dtPIns2;
        private System.Windows.Forms.DateTimePicker dtPIns1;
    }
}

