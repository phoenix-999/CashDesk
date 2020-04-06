using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Models
{
    public class CashDescDataSet : DataSet
    {
        public const string ACCOUNTS = "Accounts";
        public const string ACTIONS = "Actions";
        public const string PRODUCTS = "Products";
        public const string PRODUCT_TYPES = "ProductTypes";

        public DataTable Actions { get; set; }
        public DataTable Accounts { get; set; }

        public void InitActionsTable()
        {
            Actions = new DataTable(ACTIONS);

            DataColumn id = new DataColumn("Id");
            Actions.Columns.Add(id);

            DataColumn accountNumber = new DataColumn("AccountNumber");
            Actions.Columns.Add(accountNumber);

            DataColumn productId = new DataColumn("ProductId");
            Actions.Columns.Add(productId);

            DataColumn amount = new DataColumn("Amount");
            Actions.Columns.Add(amount);

            this.Tables.Add(Actions);
        }

    }
}
