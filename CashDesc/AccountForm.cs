using DataLib.Models;
using LanguageLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashDesc
{
    public partial class AccountForm : Form
    {
        public AccountForm(DataRow accountRow, DataTable actionsTable)
        {
            InitializeComponent();
            this.Text = Config.Language[StrResourceKeys.AccountNumber] + " " + accountRow["Number"];
            _accountRow = accountRow;
            _actionsTable = actionsTable;
            InitControls();
        }

        DataRow _accountRow;
        DataTable _actionsTable;
        List<Product> _productList;

        void InitControls()
        {
            lbAccountDate.Text = Config.Language[StrResourceKeys.AccountDate];
            lbAccountNumber.Text = Config.Language[StrResourceKeys.AccountNumber];
            lbSumma.Text = Config.Language[StrResourceKeys.Amount];
            btnApply.Text = Config.Language[StrResourceKeys.Apply];
            btnApply.DialogResult = DialogResult.OK;
            btnCancel.Text = Config.Language[StrResourceKeys.Cancel];
            btnAddAction.Text = Config.Language[StrResourceKeys.Add];

            if(_accountRow["Number"] != null)
                tbAccountNumber.Text = _accountRow["Number"].ToString();
            bool parseResult = DateTime.TryParse(_accountRow["ActionTime"].ToString(), out DateTime dateTime);
            if(parseResult)
                dtpAccountDate.Value = dateTime;
            parseResult = decimal.TryParse(_accountRow["ActionTime"].ToString(), out decimal sum);
            if (parseResult)
                nudAccountSum.Value = sum;

            RefreshActionsView();
        }

        private void InitProductList(DataGridViewComboBoxColumn comboBoxColumn)
        {
            var businessLogic = new BusinessLogic();
            try
            {
                _productList = businessLogic.GetProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }


            foreach (var product in _productList)
            {
                comboBoxColumn.Items.Add(product);
            }

        }

        void RefreshActionsView()
        {
            dataGridViewActions.AutoGenerateColumns = false;
            dataGridViewActions.DataSource = _actionsTable;
            dataGridViewActions.Columns.Clear();

            var productId = new DataGridViewColumn();
            productId.DataPropertyName = "ProductId";
            productId.CellTemplate = new DataGridViewTextBoxCell();
            productId.Name = Config.Language[StrResourceKeys.Product];
            productId.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            productId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            productId.Visible = false;
            dataGridViewActions.Columns.Add(productId);

            var productName = new DataGridViewComboBoxColumn();
            InitProductList(productName);
            productName.DataPropertyName = "ProductName";//Привязка работает с ошибками. Выпадает https://www.cyberforum.ru/windows-forms/thread2242184.html. Решение по ссылке не подходит.
            productName.ValueMember = "Id";
            productName.ValueType = typeof(int);
            productId.CellTemplate = new DataGridViewComboBoxCell();
            productId.CellTemplate.ValueType = typeof(int);
            productName.DisplayMember = "ProductName";
            productName.Name = Config.Language[StrResourceKeys.ProductName];
            productName.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            productName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewActions.Columns.Add(productName);

            var price = new DataGridViewColumn();
            price.DataPropertyName = "Price";
            price.Name = Config.Language[StrResourceKeys.Price];
            price.CellTemplate = new DataGridViewTextBoxCell();
            price.SortMode = DataGridViewColumnSortMode.Automatic;
            price.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            price.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewActions.Columns.Add(price);

            var discount = new DataGridViewColumn();
            discount.DataPropertyName = "Discount";
            discount.Name = Config.Language[StrResourceKeys.Discount];
            discount.CellTemplate = new DataGridViewTextBoxCell();
            discount.SortMode = DataGridViewColumnSortMode.Automatic;
            discount.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            discount.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewActions.Columns.Add(discount);

            var amount = new DataGridViewColumn();
            amount.DataPropertyName = "Amount";
            amount.Name = Config.Language[StrResourceKeys.Amount];
            amount.CellTemplate = new DataGridViewTextBoxCell();
            amount.SortMode = DataGridViewColumnSortMode.Automatic;
            amount.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewActions.Columns.Add(amount);
            dataGridViewActions.Columns[amount.Name].ReadOnly = true;

            dataGridViewActions.Refresh();

            foreach (DataGridViewRow row in dataGridViewActions.Rows)
            {
                var cell = dataGridViewActions.Rows[row.Index].Cells[Config.Language[StrResourceKeys.ProductName]] as DataGridViewComboBoxCell;
                var cellProductId = dataGridViewActions.Rows[row.Index].Cells[Config.Language[StrResourceKeys.Product]] as DataGridViewTextBoxCell;
                int currentProductId = int.Parse(cellProductId.Value.ToString());
                var cellValue = _productList.First(c => c.Id == currentProductId);
                cell.Value = currentProductId;
            }

        }

        private void btnAddAction_Click(object sender, EventArgs e)
        {
            var newRow = _actionsTable.NewRow();
            _actionsTable.Rows.Add(newRow);
        }

        private void dataGridViewActions_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.GetType() == typeof(ArgumentException))
            {
                e.ThrowException = false;
                throw e.Exception;
            };
            
        }

        private void dataGridViewActions_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var row = dataGridViewActions.Rows[e.RowIndex];
            var priceCell = row.Cells[Config.Language[StrResourceKeys.Price]];

            var productNameColumnIndex = dataGridViewActions.Columns[Config.Language[StrResourceKeys.ProductName]].Index;
            if (e.ColumnIndex == productNameColumnIndex)
            {
                var cellValue = row.Cells[Config.Language[StrResourceKeys.ProductName]].Value;
                row.Cells[Config.Language[StrResourceKeys.Product]].Value = cellValue;//Установка Id товара
                var product = _productList.Where(p => p.Id == int.Parse(cellValue.ToString())).First();
                priceCell.Value = product.Price;
                
            }

            var discoutnCell = row.Cells[Config.Language[StrResourceKeys.Discount]];
            var amountCell = row.Cells[Config.Language[StrResourceKeys.Amount]];

            decimal.TryParse(priceCell.Value.ToString(), out decimal price);
            decimal.TryParse(discoutnCell.Value.ToString(), out decimal discount);

            amountCell.Value = price - discount;
            nudAccountSum.Value = GetAccountSum();
        }

        decimal GetAccountSum()
        {
            decimal result = 0;
            foreach(DataGridViewRow row in dataGridViewActions.Rows)
            {
                var amountCell = row.Cells[Config.Language[StrResourceKeys.Amount]];
                decimal.TryParse(amountCell.Value.ToString(), out decimal amount);
                result += amount;
            }
            return result;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            foreach(DataRow row in _actionsTable.Rows)
            {
                row["AccountNumber"] = _accountRow["Number"];
            }
        }
    }
}
