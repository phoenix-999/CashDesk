using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLib.Models;
using LanguageLib;

namespace CashDesc
{
    public partial class MainForm : Form
    {
        BusinessLogic businessLogic = new BusinessLogic();
        public MainForm()
        {
            InitializeComponent();
            Config.SetLanguage();

            this.Text = Config.Language[StrResourceKeys.CashDesc];

            InitControls();
            
        }

        void InitControls()
        {
            tabPageGoods.Text = Config.Language[StrResourceKeys.Goods];
            tabPageAccounts.Text = Config.Language[StrResourceKeys.Accounts];
            groupBoxGoodsFilter.Text = Config.Language[StrResourceKeys.Filter];
            lbProductName.Text = Config.Language[StrResourceKeys.ProductName];
            lbProductType.Text = Config.Language[StrResourceKeys.ProductType];
            lbPrice.Text = Config.Language[StrResourceKeys.Price];
            btnSearchProducts.Text = Config.Language[StrResourceKeys.Search];
            btnAddProduct.Text = Config.Language[StrResourceKeys.Add];

            InitProductTypeList(cbProductType);

            tabControlAccounts.Text = Config.Language[StrResourceKeys.Accounts];
            lbAccountNumber.Text = Config.Language[StrResourceKeys.AccountNumber];
            lbProductInAccount.Text = Config.Language[StrResourceKeys.Product];
            lbAccountSum.Text = Config.Language[StrResourceKeys.Amount];
            lbAccountDate.Text = Config.Language[StrResourceKeys.AccountDate];
            btnSearchAccounts.Text = Config.Language[StrResourceKeys.Search];
            btnAddAccount.Text = Config.Language[StrResourceKeys.Add];

            InitProductList(cbProductFilter);
        }

        internal static void InitProductTypeList(ComboBox comboBox, int? currentId=null)
        {
            var businessLogic = new BusinessLogic();
            try
            {
                businessLogic.LoadProductTypes();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            foreach (var pt in businessLogic.GetProductTypeList())
            {
                var index = comboBox.Items.Add(pt);
                if(currentId != null && pt.Id == currentId)
                    comboBox.SelectedIndex = index;


            }
        }

        internal static void InitProductList(ComboBox comboBox, int? currentId = null)
        {
            var businessLogic = new BusinessLogic();
            List<Product> productList;
            try
            {
                productList = businessLogic.GetProductList();
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

            foreach (var product in productList)
            {
                var index = comboBox.Items.Add(product);
                if (currentId != null && product.Id == currentId)
                    comboBox.SelectedIndex = index;
            }

        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            ProductFilter filter = new ProductFilter();
            filter.Name = string.IsNullOrEmpty(tbProductName.Text) ? null : tbProductName.Text;
            filter.Type = string.IsNullOrEmpty(cbProductType.Text) ? null : cbProductType.Text;
            filter.PriceFrom = nudPriceFrom.Value;
            filter.PriceTo = nudPriceTo.Value;

            CashDescDataSet productDs = null;
            try
            {
                businessLogic.LoadProducts(filter);
                productDs = BusinessLogic.ProductDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            RefreshProductsView(productDs);
        }

        private void RefreshProductsView(CashDescDataSet productDs)
        {
            dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewProducts.DataSource = productDs.Tables[CashDescDataSet.PRODUCTS];

            dataGridViewProducts.Columns.Clear();

            var productName = new DataGridViewColumn();
            productName.DataPropertyName = "ProductName";
            productName.Name = Config.Language[StrResourceKeys.ProductName];
            productName.CellTemplate = new DataGridViewTextBoxCell();
            productName.SortMode = DataGridViewColumnSortMode.Automatic;
            productName.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            productName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProducts.Columns.Add(productName);

            var productTypeName = new DataGridViewColumn();
            productTypeName.DataPropertyName = "TypeName";
            productTypeName.Name = Config.Language[StrResourceKeys.ProductType];
            productTypeName.CellTemplate = new DataGridViewTextBoxCell();
            productTypeName.SortMode = DataGridViewColumnSortMode.Automatic;
            productTypeName.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            productTypeName.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProducts.Columns.Add(productTypeName);

            var productPrice = new DataGridViewColumn();
            productPrice.DataPropertyName = "Price";
            productPrice.Name = Config.Language[StrResourceKeys.Price];
            productPrice.CellTemplate = new DataGridViewTextBoxCell();
            productPrice.SortMode = DataGridViewColumnSortMode.Automatic;
            productPrice.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            productPrice.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewProducts.Columns.Add(productPrice);

            var productDescription = new DataGridViewColumn();
            productDescription.DataPropertyName = "Description";
            productDescription.Name = Config.Language[StrResourceKeys.Description];
            productDescription.CellTemplate = new DataGridViewTextBoxCell();
            dataGridViewProducts.Columns.Add(productDescription);

            dataGridViewProducts.Refresh();
        }

        private void RefreshAccountsView(CashDescDataSet accountDs)
        {
            dataGridViewAccounts.AutoGenerateColumns = false;
            dataGridViewAccounts.DataSource = accountDs.Tables[CashDescDataSet.ACCOUNTS];

            dataGridViewAccounts.Columns.Clear();

            var accountNumber = new DataGridViewColumn();
            accountNumber.DataPropertyName = "Number";
            accountNumber.Name = Config.Language[StrResourceKeys.AccountNumber];
            accountNumber.CellTemplate = new DataGridViewTextBoxCell();
            accountNumber.SortMode = DataGridViewColumnSortMode.Automatic;
            accountNumber.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            accountNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewAccounts.Columns.Add(accountNumber);

            var date = new DataGridViewColumn();
            date.DataPropertyName = "ActionTime";
            date.Name = Config.Language[StrResourceKeys.AccountDate];
            date.CellTemplate = new DataGridViewTextBoxCell();
            date.SortMode = DataGridViewColumnSortMode.Automatic;
            date.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            date.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewAccounts.Columns.Add(date);

            var accountSum = new DataGridViewColumn();
            accountSum.DataPropertyName = "AccountSum";
            accountSum.Name = Config.Language[StrResourceKeys.Amount];
            accountSum.CellTemplate = new DataGridViewTextBoxCell();
            accountSum.SortMode = DataGridViewColumnSortMode.Automatic;
            accountSum.HeaderCell.Style.WrapMode = DataGridViewTriState.False;
            accountSum.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells | DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewAccounts.Columns.Add(accountSum);

            dataGridViewAccounts.Refresh();
        }
        
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var newRow = BusinessLogic.ProductDs.Tables[CashDescDataSet.PRODUCTS].NewRow();
            BusinessLogic.ProductDs.Tables[CashDescDataSet.PRODUCTS].Rows.Add(newRow);
            var result = new ProductForm(newRow).ShowDialog();
            if (result != DialogResult.Cancel)
            {
                bool updateResult = UpdateProducts();
                if(updateResult)
                    RefreshProductsView(BusinessLogic.ProductDs);
            }
            else
            {
                BusinessLogic.ProductDs.Tables[CashDescDataSet.PRODUCTS].Rows.Remove(newRow);
            }
        }

        bool UpdateProducts()
        {
            try
            {
                businessLogic.UpdateProducts();
                return true;
            }
            catch(DBConcurrencyException)
            {
                string msg = Config.Language[StrResourceKeys.ConcurencyException] + "\n" + Config.Language[StrResourceKeys.ConcurencyExceptionQuestion];
                var ansver = MessageBox.Show(
                    msg,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                    );
                if(ansver == DialogResult.OK)
                {
                    try
                    {
                        businessLogic.UpdateProducts(true);
                        return true;
                    }
                    catch (Exception nextEx)
                    {
                        MessageBox.Show(
                            nextEx.Message,
                            Config.Language[StrResourceKeys.Error],
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return false;
        }

        bool UpdateAccounts()
        {
            try
            {
                businessLogic.UpdateAccounts();
                return true;
            }
            catch (DBConcurrencyException)
            {
                string msg = Config.Language[StrResourceKeys.ConcurencyException] + "\n" + Config.Language[StrResourceKeys.ConcurencyExceptionQuestion];
                var ansver = MessageBox.Show(
                    msg,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error
                    );
                if (ansver == DialogResult.OK)
                {
                    try
                    {
                        businessLogic.UpdateAccounts(true);
                        return true;
                    }
                    catch (Exception nextEx)
                    {
                        MessageBox.Show(
                            nextEx.Message,
                            Config.Language[StrResourceKeys.Error],
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            return false;
        }

        private void dataGridViewProducts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow gridRow;
            try
            {
                gridRow = dataGridViewProducts.Rows[e.RowIndex];
            }
            catch (ArgumentOutOfRangeException)//Возможен клик по заголовку
            {
                return;
            }

            var dataRow = ((DataRowView)gridRow.DataBoundItem).Row;
            var result = new ProductForm(dataRow).ShowDialog();
            if (result != DialogResult.Cancel)
            {
                UpdateProducts();
                RefreshProductsView(BusinessLogic.ProductDs);
            }
        }


        private void dataGridViewProducts_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            var answer = MessageBox.Show(
                Config.Language[StrResourceKeys.DeleteQuestion],
                Config.Language[StrResourceKeys.DeleteConfirmed],
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
            if (answer == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void dataGridViewProducts_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            bool updateResult = UpdateProducts();
            if(updateResult)
                RefreshProductsView(BusinessLogic.ProductDs);
        }

        private void btnSearchAccounts_Click(object sender, EventArgs e)
        {
            string numberStr = string.IsNullOrEmpty(tbAccountNumber.Text) ? null : tbAccountNumber.Text;
            int? number = null;
            if(numberStr != null)
            {
                int parsingNumber;
                bool parseResult = int.TryParse(numberStr, out parsingNumber);
                if (parseResult)
                    number = parsingNumber;
            }
            AccountFilter filter = new AccountFilter
            {
                Number = number,
                AccountDate = dtpAccountDate.Value,
                ProductName = string.IsNullOrEmpty(cbProductFilter.Text) ? null : cbProductFilter.Text,
                SumFrom = nudSummaFrom.Value,
                SumTo = nudSummaTo.Value
            };

            CashDescDataSet accountDs = null;
            try
            {
                businessLogic.LoadAccounts(filter);
                accountDs = BusinessLogic.AccountDs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            RefreshAccountsView(accountDs);
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            int idNewRow;
            try
            {
                idNewRow = businessLogic.CreateAccount();
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                   ex.Message,
                   Config.Language[StrResourceKeys.Error],
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                return;
            }

            var newRow = BusinessLogic.AccountDs.Tables[CashDescDataSet.ACCOUNTS].NewRow();
            newRow["Number"] = idNewRow;
            BusinessLogic.AccountDs.Tables[CashDescDataSet.ACCOUNTS].Rows.Add(newRow);
            BusinessLogic.AccountDs.Tables[CashDescDataSet.ACCOUNTS].AcceptChanges();
            var result = new AccountForm(newRow,
                BusinessLogic.AccountDs.Tables[CashDescDataSet.ACTIONS]
                ).ShowDialog();
            if (result != DialogResult.Cancel)
            {
                bool updateResult = UpdateAccounts();
                if (updateResult)
                    RefreshAccountsView(BusinessLogic.AccountDs);
            }
            else
            {
                BusinessLogic.AccountDs.Tables[CashDescDataSet.ACCOUNTS].Rows.Remove(newRow);
            }
        }

        private void dataGridViewAccounts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow gridRow;
            try
            {
                gridRow = dataGridViewAccounts.Rows[e.RowIndex];
            }
            catch (ArgumentOutOfRangeException)//Возможен клик по заголовку
            {
                return;
            }

            var dataRow = ((DataRowView)gridRow.DataBoundItem).Row;
            try
            {
                businessLogic.LoadActionsFromAccount((int)dataRow["Number"]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    Config.Language[StrResourceKeys.Error],
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            var result = new AccountForm(dataRow, BusinessLogic.AccountDs.Tables[CashDescDataSet.ACTIONS]).ShowDialog();
            if (result != DialogResult.Cancel)
            {
                UpdateProducts();
                RefreshProductsView(BusinessLogic.ProductDs);
            }
        }
    }
}
