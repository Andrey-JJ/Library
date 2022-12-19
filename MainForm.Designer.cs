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
            this.cBIns3 = new System.Windows.Forms.ComboBox();
            this.cBIns2 = new System.Windows.Forms.ComboBox();
            this.cBIns1 = new System.Windows.Forms.ComboBox();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dtPIns2 = new System.Windows.Forms.DateTimePicker();
            this.dtPIns1 = new System.Windows.Forms.DateTimePicker();
            this.lbIns1 = new System.Windows.Forms.Label();
            this.cBIns4 = new System.Windows.Forms.ComboBox();
            this.nUDIns2 = new System.Windows.Forms.NumericUpDown();
            this.lbIns6 = new System.Windows.Forms.Label();
            this.nUDIns1 = new System.Windows.Forms.NumericUpDown();
            this.lbIns5 = new System.Windows.Forms.Label();
            this.tBIns3 = new System.Windows.Forms.TextBox();
            this.lbIns4 = new System.Windows.Forms.Label();
            this.tBIns2 = new System.Windows.Forms.TextBox();
            this.lbIns3 = new System.Windows.Forms.Label();
            this.tBIns1 = new System.Windows.Forms.TextBox();
            this.lbIns2 = new System.Windows.Forms.Label();
            this.btnInsImg = new System.Windows.Forms.Button();
            this.tPUpdate_Delete = new System.Windows.Forms.TabPage();
            this.chBUp1 = new System.Windows.Forms.CheckBox();
            this.dtPUp2 = new System.Windows.Forms.DateTimePicker();
            this.dtPUp1 = new System.Windows.Forms.DateTimePicker();
            this.lbUp1 = new System.Windows.Forms.Label();
            this.cBUp1 = new System.Windows.Forms.ComboBox();
            this.nUDUp2 = new System.Windows.Forms.NumericUpDown();
            this.lbUp6 = new System.Windows.Forms.Label();
            this.nUDUp1 = new System.Windows.Forms.NumericUpDown();
            this.lbUp5 = new System.Windows.Forms.Label();
            this.tBUp3 = new System.Windows.Forms.TextBox();
            this.lbUp4 = new System.Windows.Forms.Label();
            this.tBUp2 = new System.Windows.Forms.TextBox();
            this.lbUp3 = new System.Windows.Forms.Label();
            this.tBUp1 = new System.Windows.Forms.TextBox();
            this.lbUp2 = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tPAdditional = new System.Windows.Forms.TabPage();
            this.btnLogs = new System.Windows.Forms.Button();
            this.cBDop1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBookInfo = new System.Windows.Forms.Button();
            this.btnSubInfo = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataBaseDGV)).BeginInit();
            this.tCActions.SuspendLayout();
            this.tPInsert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns1)).BeginInit();
            this.tPUpdate_Delete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDUp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDUp1)).BeginInit();
            this.tPAdditional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.tCActions.Size = new System.Drawing.Size(1080, 166);
            this.tCActions.TabIndex = 3;
            // 
            // tPInsert
            // 
            this.tPInsert.Controls.Add(this.cBIns3);
            this.tPInsert.Controls.Add(this.cBIns2);
            this.tPInsert.Controls.Add(this.cBIns1);
            this.tPInsert.Controls.Add(this.btnInsert);
            this.tPInsert.Controls.Add(this.dtPIns2);
            this.tPInsert.Controls.Add(this.dtPIns1);
            this.tPInsert.Controls.Add(this.lbIns1);
            this.tPInsert.Controls.Add(this.cBIns4);
            this.tPInsert.Controls.Add(this.nUDIns2);
            this.tPInsert.Controls.Add(this.lbIns6);
            this.tPInsert.Controls.Add(this.nUDIns1);
            this.tPInsert.Controls.Add(this.lbIns5);
            this.tPInsert.Controls.Add(this.tBIns3);
            this.tPInsert.Controls.Add(this.lbIns4);
            this.tPInsert.Controls.Add(this.tBIns2);
            this.tPInsert.Controls.Add(this.lbIns3);
            this.tPInsert.Controls.Add(this.tBIns1);
            this.tPInsert.Controls.Add(this.lbIns2);
            this.tPInsert.Controls.Add(this.btnInsImg);
            this.tPInsert.Location = new System.Drawing.Point(4, 25);
            this.tPInsert.Name = "tPInsert";
            this.tPInsert.Padding = new System.Windows.Forms.Padding(3);
            this.tPInsert.Size = new System.Drawing.Size(1072, 137);
            this.tPInsert.TabIndex = 0;
            this.tPInsert.Text = "Добавление";
            this.tPInsert.UseVisualStyleBackColor = true;
            // 
            // cBIns3
            // 
            this.cBIns3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBIns3.FormattingEnabled = true;
            this.cBIns3.Location = new System.Drawing.Point(474, 22);
            this.cBIns3.Name = "cBIns3";
            this.cBIns3.Size = new System.Drawing.Size(179, 24);
            this.cBIns3.TabIndex = 29;
            // 
            // cBIns2
            // 
            this.cBIns2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBIns2.FormattingEnabled = true;
            this.cBIns2.Location = new System.Drawing.Point(242, 22);
            this.cBIns2.Name = "cBIns2";
            this.cBIns2.Size = new System.Drawing.Size(226, 24);
            this.cBIns2.TabIndex = 28;
            // 
            // cBIns1
            // 
            this.cBIns1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBIns1.FormattingEnabled = true;
            this.cBIns1.Location = new System.Drawing.Point(6, 22);
            this.cBIns1.Name = "cBIns1";
            this.cBIns1.Size = new System.Drawing.Size(230, 24);
            this.cBIns1.TabIndex = 27;
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(893, 90);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(173, 41);
            this.btnInsert.TabIndex = 26;
            this.btnInsert.Text = "Добавить запись";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // dtPIns2
            // 
            this.dtPIns2.Location = new System.Drawing.Point(6, 78);
            this.dtPIns2.Name = "dtPIns2";
            this.dtPIns2.Size = new System.Drawing.Size(200, 22);
            this.dtPIns2.TabIndex = 25;
            this.dtPIns2.Visible = false;
            // 
            // dtPIns1
            // 
            this.dtPIns1.Location = new System.Drawing.Point(659, 22);
            this.dtPIns1.Name = "dtPIns1";
            this.dtPIns1.Size = new System.Drawing.Size(200, 22);
            this.dtPIns1.TabIndex = 24;
            this.dtPIns1.Visible = false;
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
            // cBIns4
            // 
            this.cBIns4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBIns4.FormattingEnabled = true;
            this.cBIns4.Location = new System.Drawing.Point(825, 21);
            this.cBIns4.Name = "cBIns4";
            this.cBIns4.Size = new System.Drawing.Size(156, 24);
            this.cBIns4.TabIndex = 22;
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
            this.nUDIns1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDIns1.Name = "nUDIns1";
            this.nUDIns1.Size = new System.Drawing.Size(160, 22);
            this.nUDIns1.TabIndex = 19;
            // 
            // lbIns5
            // 
            this.lbIns5.AutoSize = true;
            this.lbIns5.Location = new System.Drawing.Point(822, 3);
            this.lbIns5.Name = "lbIns5";
            this.lbIns5.Size = new System.Drawing.Size(48, 16);
            this.lbIns5.TabIndex = 18;
            this.lbIns5.Text = "Отдел";
            this.lbIns5.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbIns5.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbIns5.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tBIns3
            // 
            this.tBIns3.Location = new System.Drawing.Point(474, 23);
            this.tBIns3.Name = "tBIns3";
            this.tBIns3.Size = new System.Drawing.Size(179, 22);
            this.tBIns3.TabIndex = 17;
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
            // tBIns2
            // 
            this.tBIns2.Location = new System.Drawing.Point(242, 23);
            this.tBIns2.Name = "tBIns2";
            this.tBIns2.Size = new System.Drawing.Size(226, 22);
            this.tBIns2.TabIndex = 15;
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
            // tBIns1
            // 
            this.tBIns1.Location = new System.Drawing.Point(6, 23);
            this.tBIns1.Name = "tBIns1";
            this.tBIns1.Size = new System.Drawing.Size(230, 22);
            this.tBIns1.TabIndex = 13;
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
            // btnInsImg
            // 
            this.btnInsImg.Location = new System.Drawing.Point(693, 90);
            this.btnInsImg.Name = "btnInsImg";
            this.btnInsImg.Size = new System.Drawing.Size(194, 41);
            this.btnInsImg.TabIndex = 11;
            this.btnInsImg.Text = "Добавить изображение";
            this.btnInsImg.UseVisualStyleBackColor = true;
            this.btnInsImg.Click += new System.EventHandler(this.btnInsImg_Click);
            // 
            // tPUpdate_Delete
            // 
            this.tPUpdate_Delete.Controls.Add(this.chBUp1);
            this.tPUpdate_Delete.Controls.Add(this.dtPUp2);
            this.tPUpdate_Delete.Controls.Add(this.dtPUp1);
            this.tPUpdate_Delete.Controls.Add(this.lbUp1);
            this.tPUpdate_Delete.Controls.Add(this.cBUp1);
            this.tPUpdate_Delete.Controls.Add(this.nUDUp2);
            this.tPUpdate_Delete.Controls.Add(this.lbUp6);
            this.tPUpdate_Delete.Controls.Add(this.nUDUp1);
            this.tPUpdate_Delete.Controls.Add(this.lbUp5);
            this.tPUpdate_Delete.Controls.Add(this.tBUp3);
            this.tPUpdate_Delete.Controls.Add(this.lbUp4);
            this.tPUpdate_Delete.Controls.Add(this.tBUp2);
            this.tPUpdate_Delete.Controls.Add(this.lbUp3);
            this.tPUpdate_Delete.Controls.Add(this.tBUp1);
            this.tPUpdate_Delete.Controls.Add(this.lbUp2);
            this.tPUpdate_Delete.Controls.Add(this.btnUpdate);
            this.tPUpdate_Delete.Controls.Add(this.btnDelete);
            this.tPUpdate_Delete.Location = new System.Drawing.Point(4, 25);
            this.tPUpdate_Delete.Name = "tPUpdate_Delete";
            this.tPUpdate_Delete.Padding = new System.Windows.Forms.Padding(3);
            this.tPUpdate_Delete.Size = new System.Drawing.Size(1072, 137);
            this.tPUpdate_Delete.TabIndex = 1;
            this.tPUpdate_Delete.Text = "Изменение";
            this.tPUpdate_Delete.UseVisualStyleBackColor = true;
            // 
            // chBUp1
            // 
            this.chBUp1.AutoSize = true;
            this.chBUp1.Location = new System.Drawing.Point(31, 27);
            this.chBUp1.Name = "chBUp1";
            this.chBUp1.Size = new System.Drawing.Size(18, 17);
            this.chBUp1.TabIndex = 41;
            this.chBUp1.UseVisualStyleBackColor = true;
            // 
            // dtPUp2
            // 
            this.dtPUp2.Location = new System.Drawing.Point(7, 79);
            this.dtPUp2.Name = "dtPUp2";
            this.dtPUp2.Size = new System.Drawing.Size(200, 22);
            this.dtPUp2.TabIndex = 40;
            this.dtPUp2.Visible = false;
            // 
            // dtPUp1
            // 
            this.dtPUp1.Location = new System.Drawing.Point(660, 24);
            this.dtPUp1.Name = "dtPUp1";
            this.dtPUp1.Size = new System.Drawing.Size(200, 22);
            this.dtPUp1.TabIndex = 39;
            this.dtPUp1.Visible = false;
            // 
            // lbUp1
            // 
            this.lbUp1.AutoSize = true;
            this.lbUp1.Location = new System.Drawing.Point(4, 4);
            this.lbUp1.Name = "lbUp1";
            this.lbUp1.Size = new System.Drawing.Size(73, 16);
            this.lbUp1.TabIndex = 38;
            this.lbUp1.Text = "Название";
            this.lbUp1.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbUp1.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbUp1.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // cBUp1
            // 
            this.cBUp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBUp1.FormattingEnabled = true;
            this.cBUp1.Location = new System.Drawing.Point(830, 23);
            this.cBUp1.Name = "cBUp1";
            this.cBUp1.Size = new System.Drawing.Size(156, 24);
            this.cBUp1.TabIndex = 37;
            // 
            // nUDUp2
            // 
            this.nUDUp2.Location = new System.Drawing.Point(7, 79);
            this.nUDUp2.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDUp2.Name = "nUDUp2";
            this.nUDUp2.Size = new System.Drawing.Size(87, 22);
            this.nUDUp2.TabIndex = 36;
            // 
            // lbUp6
            // 
            this.lbUp6.AutoSize = true;
            this.lbUp6.Location = new System.Drawing.Point(4, 60);
            this.lbUp6.Name = "lbUp6";
            this.lbUp6.Size = new System.Drawing.Size(83, 16);
            this.lbUp6.TabIndex = 35;
            this.lbUp6.Text = "Кол-во книг";
            this.lbUp6.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbUp6.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbUp6.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // nUDUp1
            // 
            this.nUDUp1.Location = new System.Drawing.Point(660, 24);
            this.nUDUp1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nUDUp1.Name = "nUDUp1";
            this.nUDUp1.Size = new System.Drawing.Size(164, 22);
            this.nUDUp1.TabIndex = 34;
            // 
            // lbUp5
            // 
            this.lbUp5.AutoSize = true;
            this.lbUp5.Location = new System.Drawing.Point(827, 4);
            this.lbUp5.Name = "lbUp5";
            this.lbUp5.Size = new System.Drawing.Size(48, 16);
            this.lbUp5.TabIndex = 33;
            this.lbUp5.Text = "Отдел";
            this.lbUp5.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbUp5.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbUp5.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tBUp3
            // 
            this.tBUp3.Location = new System.Drawing.Point(475, 24);
            this.tBUp3.Name = "tBUp3";
            this.tBUp3.Size = new System.Drawing.Size(179, 22);
            this.tBUp3.TabIndex = 32;
            // 
            // lbUp4
            // 
            this.lbUp4.AutoSize = true;
            this.lbUp4.Location = new System.Drawing.Point(657, 4);
            this.lbUp4.Name = "lbUp4";
            this.lbUp4.Size = new System.Drawing.Size(51, 16);
            this.lbUp4.TabIndex = 31;
            this.lbUp4.Text = "Объем";
            this.lbUp4.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbUp4.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbUp4.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tBUp2
            // 
            this.tBUp2.Location = new System.Drawing.Point(243, 24);
            this.tBUp2.Name = "tBUp2";
            this.tBUp2.Size = new System.Drawing.Size(226, 22);
            this.tBUp2.TabIndex = 30;
            // 
            // lbUp3
            // 
            this.lbUp3.AutoSize = true;
            this.lbUp3.Location = new System.Drawing.Point(472, 4);
            this.lbUp3.Name = "lbUp3";
            this.lbUp3.Size = new System.Drawing.Size(100, 16);
            this.lbUp3.TabIndex = 29;
            this.lbUp3.Text = "Автор/Авторы";
            this.lbUp3.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbUp3.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbUp3.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // tBUp1
            // 
            this.tBUp1.Location = new System.Drawing.Point(7, 24);
            this.tBUp1.Name = "tBUp1";
            this.tBUp1.Size = new System.Drawing.Size(230, 22);
            this.tBUp1.TabIndex = 28;
            // 
            // lbUp2
            // 
            this.lbUp2.AutoSize = true;
            this.lbUp2.Location = new System.Drawing.Point(240, 4);
            this.lbUp2.Name = "lbUp2";
            this.lbUp2.Size = new System.Drawing.Size(65, 16);
            this.lbUp2.TabIndex = 27;
            this.lbUp2.Text = "Издание";
            this.lbUp2.MouseEnter += new System.EventHandler(this.OnMouseEnter);
            this.lbUp2.MouseLeave += new System.EventHandler(this.OnMouseLeave);
            this.lbUp2.MouseHover += new System.EventHandler(this.OnMouseHover);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(714, 90);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(173, 41);
            this.btnUpdate.TabIndex = 13;
            this.btnUpdate.Text = "Изменить запись";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(893, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(173, 41);
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "Удалить запись";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tPAdditional
            // 
            this.tPAdditional.Controls.Add(this.btnLogs);
            this.tPAdditional.Controls.Add(this.cBDop1);
            this.tPAdditional.Controls.Add(this.label1);
            this.tPAdditional.Controls.Add(this.btnBookInfo);
            this.tPAdditional.Controls.Add(this.btnSubInfo);
            this.tPAdditional.Location = new System.Drawing.Point(4, 25);
            this.tPAdditional.Name = "tPAdditional";
            this.tPAdditional.Size = new System.Drawing.Size(1072, 137);
            this.tPAdditional.TabIndex = 2;
            this.tPAdditional.Text = "Дополнительно";
            this.tPAdditional.UseVisualStyleBackColor = true;
            // 
            // btnLogs
            // 
            this.btnLogs.Location = new System.Drawing.Point(478, 64);
            this.btnLogs.Name = "btnLogs";
            this.btnLogs.Size = new System.Drawing.Size(230, 41);
            this.btnLogs.TabIndex = 41;
            this.btnLogs.Text = "Просмотреть журнал логов";
            this.btnLogs.UseVisualStyleBackColor = true;
            this.btnLogs.Click += new System.EventHandler(this.btnLogs_Click);
            // 
            // cBDop1
            // 
            this.cBDop1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cBDop1.FormattingEnabled = true;
            this.cBDop1.Location = new System.Drawing.Point(6, 22);
            this.cBDop1.Name = "cBDop1";
            this.cBDop1.Size = new System.Drawing.Size(230, 24);
            this.cBDop1.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Выберите читателя";
            // 
            // btnBookInfo
            // 
            this.btnBookInfo.Location = new System.Drawing.Point(242, 64);
            this.btnBookInfo.Name = "btnBookInfo";
            this.btnBookInfo.Size = new System.Drawing.Size(230, 41);
            this.btnBookInfo.TabIndex = 28;
            this.btnBookInfo.Text = "Сформировать формуляр книги";
            this.btnBookInfo.UseVisualStyleBackColor = true;
            // 
            // btnSubInfo
            // 
            this.btnSubInfo.Location = new System.Drawing.Point(6, 64);
            this.btnSubInfo.Name = "btnSubInfo";
            this.btnSubInfo.Size = new System.Drawing.Size(230, 41);
            this.btnSubInfo.TabIndex = 27;
            this.btnSubInfo.Text = "Сформировать формуляр читателя";
            this.btnSubInfo.UseVisualStyleBackColor = true;
            this.btnSubInfo.Click += new System.EventHandler(this.btnSubInfo_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(963, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 379);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // npgsqlDataAdapter1
            // 
            this.npgsqlDataAdapter1.DeleteCommand = null;
            this.npgsqlDataAdapter1.InsertCommand = null;
            this.npgsqlDataAdapter1.SelectCommand = null;
            this.npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(1098, 523);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 41);
            this.btnClose.TabIndex = 42;
            this.btnClose.Text = "Выход";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 576);
            this.Controls.Add(this.btnClose);
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
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDIns1)).EndInit();
            this.tPUpdate_Delete.ResumeLayout(false);
            this.tPUpdate_Delete.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUDUp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUDUp1)).EndInit();
            this.tPAdditional.ResumeLayout(false);
            this.tPAdditional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Button btnInsImg;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.NumericUpDown nUDIns2;
        private System.Windows.Forms.Label lbIns6;
        private System.Windows.Forms.NumericUpDown nUDIns1;
        private System.Windows.Forms.Label lbIns5;
        private System.Windows.Forms.TextBox tBIns3;
        private System.Windows.Forms.Label lbIns4;
        private System.Windows.Forms.TextBox tBIns2;
        private System.Windows.Forms.Label lbIns3;
        private System.Windows.Forms.TextBox tBIns1;
        private System.Windows.Forms.Label lbIns2;
        private System.Windows.Forms.Label lbIns1;
        private System.Windows.Forms.ComboBox cBIns4;
        private System.Windows.Forms.DateTimePicker dtPIns2;
        private System.Windows.Forms.DateTimePicker dtPIns1;
        private System.Windows.Forms.DateTimePicker dtPUp2;
        private System.Windows.Forms.DateTimePicker dtPUp1;
        private System.Windows.Forms.Label lbUp1;
        private System.Windows.Forms.ComboBox cBUp1;
        private System.Windows.Forms.NumericUpDown nUDUp2;
        private System.Windows.Forms.Label lbUp6;
        private System.Windows.Forms.NumericUpDown nUDUp1;
        private System.Windows.Forms.Label lbUp5;
        private System.Windows.Forms.TextBox tBUp3;
        private System.Windows.Forms.Label lbUp4;
        private System.Windows.Forms.TextBox tBUp2;
        private System.Windows.Forms.Label lbUp3;
        private System.Windows.Forms.TextBox tBUp1;
        private System.Windows.Forms.Label lbUp2;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnBookInfo;
        private System.Windows.Forms.Button btnSubInfo;
        private System.Windows.Forms.ComboBox cBDop1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogs;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cBIns3;
        private System.Windows.Forms.ComboBox cBIns2;
        private System.Windows.Forms.ComboBox cBIns1;
        private System.Windows.Forms.CheckBox chBUp1;
    }
}

