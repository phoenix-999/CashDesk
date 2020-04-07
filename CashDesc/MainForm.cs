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

            //var id = new DataGridViewColumn();
            //id.DataPropertyName = "Id";
            //id.Name = "Id";
            //id.CellTemplate = new DataGridViewTextBoxCell();
            //id.Visible = false;
            //dataGridViewProducts.Columns.Add(id);

            //var typeid = new DataGridViewColumn();
            //typeid.DataPropertyName = "TypeId";
            //typeid.CellTemplate = new DataGridViewTextBoxCell();
            //typeid.Visible = false;
            //dataGridViewProducts.Columns.Add(typeid);

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

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            var newRow = BusinessLogic.ProductDs.Tables[CashDescDataSet.PRODUCTS].NewRow();
            BusinessLogic.ProductDs.Tables[CashDescDataSet.PRODUCTS].Rows.Add(newRow);
            var result = new ProductForm(newRow, businessLogic.GetProductTypeList()).ShowDialog();
            if (result != DialogResult.Cancel)
            {
                UpdateProducts();
                RefreshProductsView(BusinessLogic.ProductDs);
            }
            else
            {
                BusinessLogic.ProductDs.Tables[CashDescDataSet.PRODUCTS].Rows.Remove(newRow);
            }
        }

        void UpdateProducts()
        {
            try
            {
                businessLogic.UpdateProducts();
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
            var result = new ProductForm(dataRow, businessLogic.GetProductTypeList()).ShowDialog();
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
            UpdateProducts();
            RefreshProductsView(BusinessLogic.ProductDs);
        }
    }
}
