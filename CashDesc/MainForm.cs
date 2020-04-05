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

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                var products = new Product().GetProducts(null);
                var tableProducts = products.Tables[Product.PRODUCTS];
                dataGridView1.DataSource = tableProducts;


                var filter = new AccountFilter { SumFrom = 200 };
                var accounts = new Account().GetAccounts(filter);
                var tableAccounts = accounts.Tables[Account.ACCOUNTS];
                dataGridView2.DataSource = tableAccounts;

                var productsFromAccount = new Account().GetProductsFromAccount("BBBBBBBBBBBBBBBBBBBBBBBBBBBBBBBB");
                dataGridView3.DataSource = productsFromAccount;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
