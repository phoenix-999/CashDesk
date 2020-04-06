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

namespace CashDesc
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        CashDescDataSet productDs;
        CashDescDataSet accountDs;

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var products = new Product().GetProducts(null);
                productDs = products;
                var tableProducts = products.Tables[CashDescDataSet.PRODUCTS];
                dataGridView1.DataSource = tableProducts;


                var filter = new AccountFilter { SumFrom = 200 };
                var accounts = new Account().GetAccounts(filter);
                accountDs = accounts;
                var tableAccounts = accounts.Tables[CashDescDataSet.ACCOUNTS];
                dataGridView2.DataSource = tableAccounts;

                var productTypes = new ProductType().GetProductTypes();
                dataGridView4.DataSource = productTypes.Tables[ProductType.PRODUCT_TYPES];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            productDs = new Product().Update(this.productDs);
            dataGridView1.DataSource = productDs.Tables[CashDescDataSet.PRODUCTS];
            dataGridView1.Refresh();

            accountDs = new Account().Update(accountDs);
            dataGridView2.DataSource = accountDs.Tables[CashDescDataSet.ACCOUNTS];
            dataGridView2.Refresh();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var grid = (DataGridView)sender;
            var row = grid.Rows[e.RowIndex];
            var source = (DataRowView)row.DataBoundItem;
            string accountNumber = (string)source["Number"];

            new Account().GetActionsFromAccount(accountNumber, accountDs.Tables[CashDescDataSet.ACTIONS]);

            dataGridView_actions.DataSource = accountDs.Tables[CashDescDataSet.ACTIONS];
            dataGridView_actions.Refresh();
        }
    }
}
