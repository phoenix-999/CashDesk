namespace CashDesc
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
            this.tabControlAccounts = new System.Windows.Forms.TabControl();
            this.tabPageGoods = new System.Windows.Forms.TabPage();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.groupBoxGoodsFilter = new System.Windows.Forms.GroupBox();
            this.btnSearchProducts = new System.Windows.Forms.Button();
            this.cbProductType = new System.Windows.Forms.ComboBox();
            this.nudPriceTo = new System.Windows.Forms.NumericUpDown();
            this.nudPriceFrom = new System.Windows.Forms.NumericUpDown();
            this.tbProductName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.lbProductType = new System.Windows.Forms.Label();
            this.lbProductName = new System.Windows.Forms.Label();
            this.tabPageAccounts = new System.Windows.Forms.TabPage();
            this.dataGridViewAccounts = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddAccount = new System.Windows.Forms.Button();
            this.btnSearchAccounts = new System.Windows.Forms.Button();
            this.dtpAccountDate = new System.Windows.Forms.DateTimePicker();
            this.lbAccountDate = new System.Windows.Forms.Label();
            this.nudSummaTo = new System.Windows.Forms.NumericUpDown();
            this.nudSummaFrom = new System.Windows.Forms.NumericUpDown();
            this.cbProductFilter = new System.Windows.Forms.ComboBox();
            this.tbAccountNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbAccountSum = new System.Windows.Forms.Label();
            this.lbProductInAccount = new System.Windows.Forms.Label();
            this.lbAccountNumber = new System.Windows.Forms.Label();
            this.tabControlAccounts.SuspendLayout();
            this.tabPageGoods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBoxGoodsFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).BeginInit();
            this.tabPageAccounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSummaTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSummaFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAccounts
            // 
            this.tabControlAccounts.Controls.Add(this.tabPageGoods);
            this.tabControlAccounts.Controls.Add(this.tabPageAccounts);
            this.tabControlAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlAccounts.Location = new System.Drawing.Point(0, 0);
            this.tabControlAccounts.Name = "tabControlAccounts";
            this.tabControlAccounts.SelectedIndex = 0;
            this.tabControlAccounts.Size = new System.Drawing.Size(800, 450);
            this.tabControlAccounts.TabIndex = 0;
            // 
            // tabPageGoods
            // 
            this.tabPageGoods.Controls.Add(this.dataGridViewProducts);
            this.tabPageGoods.Controls.Add(this.panel1);
            this.tabPageGoods.Location = new System.Drawing.Point(4, 22);
            this.tabPageGoods.Name = "tabPageGoods";
            this.tabPageGoods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGoods.Size = new System.Drawing.Size(792, 424);
            this.tabPageGoods.TabIndex = 0;
            this.tabPageGoods.Text = "TabPage1";
            this.tabPageGoods.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToOrderColumns = true;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProducts.Location = new System.Drawing.Point(3, 101);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            this.dataGridViewProducts.Size = new System.Drawing.Size(786, 320);
            this.dataGridViewProducts.TabIndex = 1;
            this.dataGridViewProducts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellDoubleClick);
            this.dataGridViewProducts.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridViewProducts_UserDeletedRow);
            this.dataGridViewProducts.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridViewProducts_UserDeletingRow);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnAddProduct);
            this.panel1.Controls.Add(this.groupBoxGoodsFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 98);
            this.panel1.TabIndex = 0;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(430, 61);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(75, 23);
            this.btnAddProduct.TabIndex = 1;
            this.btnAddProduct.Text = "button1";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // groupBoxGoodsFilter
            // 
            this.groupBoxGoodsFilter.Controls.Add(this.btnSearchProducts);
            this.groupBoxGoodsFilter.Controls.Add(this.cbProductType);
            this.groupBoxGoodsFilter.Controls.Add(this.nudPriceTo);
            this.groupBoxGoodsFilter.Controls.Add(this.nudPriceFrom);
            this.groupBoxGoodsFilter.Controls.Add(this.tbProductName);
            this.groupBoxGoodsFilter.Controls.Add(this.label1);
            this.groupBoxGoodsFilter.Controls.Add(this.lbPrice);
            this.groupBoxGoodsFilter.Controls.Add(this.lbProductType);
            this.groupBoxGoodsFilter.Controls.Add(this.lbProductName);
            this.groupBoxGoodsFilter.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBoxGoodsFilter.Location = new System.Drawing.Point(0, 0);
            this.groupBoxGoodsFilter.Name = "groupBoxGoodsFilter";
            this.groupBoxGoodsFilter.Size = new System.Drawing.Size(408, 96);
            this.groupBoxGoodsFilter.TabIndex = 0;
            this.groupBoxGoodsFilter.TabStop = false;
            this.groupBoxGoodsFilter.Text = "groupBox1";
            // 
            // btnSearchProducts
            // 
            this.btnSearchProducts.Location = new System.Drawing.Point(299, 61);
            this.btnSearchProducts.Name = "btnSearchProducts";
            this.btnSearchProducts.Size = new System.Drawing.Size(103, 23);
            this.btnSearchProducts.TabIndex = 8;
            this.btnSearchProducts.Text = "button1";
            this.btnSearchProducts.UseVisualStyleBackColor = true;
            this.btnSearchProducts.Click += new System.EventHandler(this.btnSearchProducts_Click);
            // 
            // cbProductType
            // 
            this.cbProductType.FormattingEnabled = true;
            this.cbProductType.Location = new System.Drawing.Point(150, 33);
            this.cbProductType.Name = "cbProductType";
            this.cbProductType.Size = new System.Drawing.Size(252, 21);
            this.cbProductType.TabIndex = 7;
            // 
            // nudPriceTo
            // 
            this.nudPriceTo.Location = new System.Drawing.Point(208, 65);
            this.nudPriceTo.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudPriceTo.Name = "nudPriceTo";
            this.nudPriceTo.Size = new System.Drawing.Size(75, 20);
            this.nudPriceTo.TabIndex = 6;
            this.nudPriceTo.Value = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            // 
            // nudPriceFrom
            // 
            this.nudPriceFrom.Location = new System.Drawing.Point(76, 65);
            this.nudPriceFrom.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudPriceFrom.Name = "nudPriceFrom";
            this.nudPriceFrom.Size = new System.Drawing.Size(75, 20);
            this.nudPriceFrom.TabIndex = 5;
            // 
            // tbProductName
            // 
            this.tbProductName.Location = new System.Drawing.Point(150, 12);
            this.tbProductName.Name = "tbProductName";
            this.tbProductName.Size = new System.Drawing.Size(252, 20);
            this.tbProductName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(176, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "-";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(7, 67);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(35, 13);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "label1";
            // 
            // lbProductType
            // 
            this.lbProductType.AutoSize = true;
            this.lbProductType.Location = new System.Drawing.Point(7, 42);
            this.lbProductType.Name = "lbProductType";
            this.lbProductType.Size = new System.Drawing.Size(35, 13);
            this.lbProductType.TabIndex = 1;
            this.lbProductType.Text = "label1";
            // 
            // lbProductName
            // 
            this.lbProductName.AutoSize = true;
            this.lbProductName.Location = new System.Drawing.Point(7, 20);
            this.lbProductName.Name = "lbProductName";
            this.lbProductName.Size = new System.Drawing.Size(35, 13);
            this.lbProductName.TabIndex = 0;
            this.lbProductName.Text = "label1";
            // 
            // tabPageAccounts
            // 
            this.tabPageAccounts.Controls.Add(this.dataGridViewAccounts);
            this.tabPageAccounts.Controls.Add(this.panel2);
            this.tabPageAccounts.Location = new System.Drawing.Point(4, 22);
            this.tabPageAccounts.Name = "tabPageAccounts";
            this.tabPageAccounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAccounts.Size = new System.Drawing.Size(792, 424);
            this.tabPageAccounts.TabIndex = 1;
            this.tabPageAccounts.Text = "tabPage2";
            this.tabPageAccounts.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAccounts
            // 
            this.dataGridViewAccounts.AllowUserToAddRows = false;
            this.dataGridViewAccounts.AllowUserToOrderColumns = true;
            this.dataGridViewAccounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAccounts.Location = new System.Drawing.Point(3, 110);
            this.dataGridViewAccounts.Name = "dataGridViewAccounts";
            this.dataGridViewAccounts.ReadOnly = true;
            this.dataGridViewAccounts.Size = new System.Drawing.Size(786, 311);
            this.dataGridViewAccounts.TabIndex = 1;
            this.dataGridViewAccounts.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAccounts_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 107);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddAccount);
            this.groupBox1.Controls.Add(this.btnSearchAccounts);
            this.groupBox1.Controls.Add(this.dtpAccountDate);
            this.groupBox1.Controls.Add(this.lbAccountDate);
            this.groupBox1.Controls.Add(this.nudSummaTo);
            this.groupBox1.Controls.Add(this.nudSummaFrom);
            this.groupBox1.Controls.Add(this.cbProductFilter);
            this.groupBox1.Controls.Add(this.tbAccountNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lbAccountSum);
            this.groupBox1.Controls.Add(this.lbProductInAccount);
            this.groupBox1.Controls.Add(this.lbAccountNumber);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(662, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnAddAccount
            // 
            this.btnAddAccount.Location = new System.Drawing.Point(497, 60);
            this.btnAddAccount.Name = "btnAddAccount";
            this.btnAddAccount.Size = new System.Drawing.Size(75, 23);
            this.btnAddAccount.TabIndex = 11;
            this.btnAddAccount.Text = "button1";
            this.btnAddAccount.UseVisualStyleBackColor = true;
            this.btnAddAccount.Click += new System.EventHandler(this.btnAddAccount_Click);
            // 
            // btnSearchAccounts
            // 
            this.btnSearchAccounts.Location = new System.Drawing.Point(393, 61);
            this.btnSearchAccounts.Name = "btnSearchAccounts";
            this.btnSearchAccounts.Size = new System.Drawing.Size(75, 23);
            this.btnSearchAccounts.TabIndex = 10;
            this.btnSearchAccounts.Text = "button1";
            this.btnSearchAccounts.UseVisualStyleBackColor = true;
            this.btnSearchAccounts.Click += new System.EventHandler(this.btnSearchAccounts_Click);
            // 
            // dtpAccountDate
            // 
            this.dtpAccountDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccountDate.Location = new System.Drawing.Point(497, 14);
            this.dtpAccountDate.Name = "dtpAccountDate";
            this.dtpAccountDate.Size = new System.Drawing.Size(148, 20);
            this.dtpAccountDate.TabIndex = 9;
            this.dtpAccountDate.Value = new System.DateTime(2020, 4, 8, 10, 8, 18, 0);
            // 
            // lbAccountDate
            // 
            this.lbAccountDate.AutoSize = true;
            this.lbAccountDate.Location = new System.Drawing.Point(390, 20);
            this.lbAccountDate.Name = "lbAccountDate";
            this.lbAccountDate.Size = new System.Drawing.Size(35, 13);
            this.lbAccountDate.TabIndex = 8;
            this.lbAccountDate.Text = "label2";
            // 
            // nudSummaTo
            // 
            this.nudSummaTo.Location = new System.Drawing.Point(260, 65);
            this.nudSummaTo.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudSummaTo.Name = "nudSummaTo";
            this.nudSummaTo.Size = new System.Drawing.Size(98, 20);
            this.nudSummaTo.TabIndex = 7;
            this.nudSummaTo.Value = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            // 
            // nudSummaFrom
            // 
            this.nudSummaFrom.Location = new System.Drawing.Point(111, 64);
            this.nudSummaFrom.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudSummaFrom.Name = "nudSummaFrom";
            this.nudSummaFrom.Size = new System.Drawing.Size(98, 20);
            this.nudSummaFrom.TabIndex = 6;
            // 
            // cbProductFilter
            // 
            this.cbProductFilter.FormattingEnabled = true;
            this.cbProductFilter.Location = new System.Drawing.Point(111, 35);
            this.cbProductFilter.Name = "cbProductFilter";
            this.cbProductFilter.Size = new System.Drawing.Size(247, 21);
            this.cbProductFilter.TabIndex = 5;
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.Location = new System.Drawing.Point(111, 12);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.Size = new System.Drawing.Size(247, 20);
            this.tbAccountNumber.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "-";
            // 
            // lbAccountSum
            // 
            this.lbAccountSum.AutoSize = true;
            this.lbAccountSum.Location = new System.Drawing.Point(7, 72);
            this.lbAccountSum.Name = "lbAccountSum";
            this.lbAccountSum.Size = new System.Drawing.Size(35, 13);
            this.lbAccountSum.TabIndex = 2;
            this.lbAccountSum.Text = "label2";
            // 
            // lbProductInAccount
            // 
            this.lbProductInAccount.AutoSize = true;
            this.lbProductInAccount.Location = new System.Drawing.Point(7, 44);
            this.lbProductInAccount.Name = "lbProductInAccount";
            this.lbProductInAccount.Size = new System.Drawing.Size(35, 13);
            this.lbProductInAccount.TabIndex = 1;
            this.lbProductInAccount.Text = "label2";
            // 
            // lbAccountNumber
            // 
            this.lbAccountNumber.AutoSize = true;
            this.lbAccountNumber.Location = new System.Drawing.Point(7, 20);
            this.lbAccountNumber.Name = "lbAccountNumber";
            this.lbAccountNumber.Size = new System.Drawing.Size(35, 13);
            this.lbAccountNumber.TabIndex = 0;
            this.lbAccountNumber.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControlAccounts);
            this.Name = "MainForm";
            this.Text = "CashDesc";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControlAccounts.ResumeLayout(false);
            this.tabPageGoods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.panel1.ResumeLayout(false);
            this.groupBoxGoodsFilter.ResumeLayout(false);
            this.groupBoxGoodsFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPriceFrom)).EndInit();
            this.tabPageAccounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAccounts)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSummaTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSummaFrom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlAccounts;
        private System.Windows.Forms.TabPage tabPageGoods;
        private System.Windows.Forms.TabPage tabPageAccounts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxGoodsFilter;
        private System.Windows.Forms.ComboBox cbProductType;
        private System.Windows.Forms.NumericUpDown nudPriceTo;
        private System.Windows.Forms.NumericUpDown nudPriceFrom;
        private System.Windows.Forms.TextBox tbProductName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Label lbProductType;
        private System.Windows.Forms.Label lbProductName;
        private System.Windows.Forms.Button btnSearchProducts;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudSummaTo;
        private System.Windows.Forms.NumericUpDown nudSummaFrom;
        private System.Windows.Forms.ComboBox cbProductFilter;
        private System.Windows.Forms.TextBox tbAccountNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbAccountSum;
        private System.Windows.Forms.Label lbProductInAccount;
        private System.Windows.Forms.Label lbAccountNumber;
        private System.Windows.Forms.Label lbAccountDate;
        private System.Windows.Forms.Button btnSearchAccounts;
        private System.Windows.Forms.DataGridView dataGridViewAccounts;
        private System.Windows.Forms.DateTimePicker dtpAccountDate;
        private System.Windows.Forms.Button btnAddAccount;
    }
}

