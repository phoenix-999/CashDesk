namespace CashDesc
{
    partial class AccountForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddAction = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudAccountSum = new System.Windows.Forms.NumericUpDown();
            this.dtpAccountDate = new System.Windows.Forms.DateTimePicker();
            this.tbAccountNumber = new System.Windows.Forms.TextBox();
            this.lbSumma = new System.Windows.Forms.Label();
            this.lbAccountDate = new System.Windows.Forms.Label();
            this.lbAccountNumber = new System.Windows.Forms.Label();
            this.dataGridViewActions = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccountSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActions)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAddAction);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnApply);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(661, 132);
            this.panel1.TabIndex = 0;
            // 
            // btnAddAction
            // 
            this.btnAddAction.Location = new System.Drawing.Point(304, 95);
            this.btnAddAction.Name = "btnAddAction";
            this.btnAddAction.Size = new System.Drawing.Size(118, 23);
            this.btnAddAction.TabIndex = 3;
            this.btnAddAction.Text = "addActions";
            this.btnAddAction.UseVisualStyleBackColor = true;
            this.btnAddAction.Click += new System.EventHandler(this.btnAddAction_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(537, 51);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(537, 12);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(112, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudAccountSum);
            this.groupBox1.Controls.Add(this.dtpAccountDate);
            this.groupBox1.Controls.Add(this.tbAccountNumber);
            this.groupBox1.Controls.Add(this.lbSumma);
            this.groupBox1.Controls.Add(this.lbAccountDate);
            this.groupBox1.Controls.Add(this.lbAccountNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(286, 132);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // nudAccountSum
            // 
            this.nudAccountSum.DecimalPlaces = 2;
            this.nudAccountSum.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAccountSum.Location = new System.Drawing.Point(82, 87);
            this.nudAccountSum.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nudAccountSum.Name = "nudAccountSum";
            this.nudAccountSum.ReadOnly = true;
            this.nudAccountSum.Size = new System.Drawing.Size(120, 20);
            this.nudAccountSum.TabIndex = 5;
            // 
            // dtpAccountDate
            // 
            this.dtpAccountDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccountDate.Location = new System.Drawing.Point(82, 43);
            this.dtpAccountDate.Name = "dtpAccountDate";
            this.dtpAccountDate.Size = new System.Drawing.Size(187, 20);
            this.dtpAccountDate.TabIndex = 4;
            // 
            // tbAccountNumber
            // 
            this.tbAccountNumber.Location = new System.Drawing.Point(82, 12);
            this.tbAccountNumber.Name = "tbAccountNumber";
            this.tbAccountNumber.ReadOnly = true;
            this.tbAccountNumber.Size = new System.Drawing.Size(187, 20);
            this.tbAccountNumber.TabIndex = 3;
            // 
            // lbSumma
            // 
            this.lbSumma.AutoSize = true;
            this.lbSumma.Location = new System.Drawing.Point(13, 95);
            this.lbSumma.Name = "lbSumma";
            this.lbSumma.Size = new System.Drawing.Size(35, 13);
            this.lbSumma.TabIndex = 2;
            this.lbSumma.Text = "label1";
            // 
            // lbAccountDate
            // 
            this.lbAccountDate.AutoSize = true;
            this.lbAccountDate.Location = new System.Drawing.Point(13, 51);
            this.lbAccountDate.Name = "lbAccountDate";
            this.lbAccountDate.Size = new System.Drawing.Size(35, 13);
            this.lbAccountDate.TabIndex = 1;
            this.lbAccountDate.Text = "label1";
            // 
            // lbAccountNumber
            // 
            this.lbAccountNumber.AutoSize = true;
            this.lbAccountNumber.Location = new System.Drawing.Point(13, 20);
            this.lbAccountNumber.Name = "lbAccountNumber";
            this.lbAccountNumber.Size = new System.Drawing.Size(35, 13);
            this.lbAccountNumber.TabIndex = 0;
            this.lbAccountNumber.Text = "label1";
            // 
            // dataGridViewActions
            // 
            this.dataGridViewActions.AllowUserToAddRows = false;
            this.dataGridViewActions.AllowUserToOrderColumns = true;
            this.dataGridViewActions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewActions.Location = new System.Drawing.Point(0, 132);
            this.dataGridViewActions.Name = "dataGridViewActions";
            this.dataGridViewActions.Size = new System.Drawing.Size(661, 318);
            this.dataGridViewActions.TabIndex = 1;

            this.dataGridViewActions.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewActions_CellEndEdit);
            this.dataGridViewActions.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewActions_DataError);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(661, 450);
            this.Controls.Add(this.dataGridViewActions);
            this.Controls.Add(this.panel1);
            this.Name = "AccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AccountForm";
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAccountSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewActions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown nudAccountSum;
        private System.Windows.Forms.DateTimePicker dtpAccountDate;
        private System.Windows.Forms.TextBox tbAccountNumber;
        private System.Windows.Forms.Label lbSumma;
        private System.Windows.Forms.Label lbAccountDate;
        private System.Windows.Forms.Label lbAccountNumber;
        private System.Windows.Forms.Button btnAddAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView dataGridViewActions;
    }
}