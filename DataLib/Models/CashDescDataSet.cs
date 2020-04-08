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
        public DataTable Products { get; set; }
        public DataTable ProductTypes { get; set; }

        public void InitActionsTable()
        {
            Actions = new DataTable(ACTIONS);

            DataColumn id = new DataColumn("Id");
            Actions.Columns.Add(id);

            DataColumn accountNumber = new DataColumn("AccountNumber");
            //Если не указать явно - ругается при Relation в DataSet
            //"Среди родительских столбцов и дочерних столбцов отсутствуют столбцы совпадающих типов"
            //Выше указанное может быть связано с признаком IDENTITY одного из столбцов
            accountNumber.DataType = typeof(int);
            Actions.Columns.Add(accountNumber);

            DataColumn productId = new DataColumn("ProductId");
            Actions.Columns.Add(productId);

            DataColumn price = new DataColumn("Price");
            Actions.Columns.Add(price);

            DataColumn discount = new DataColumn("Discount");
            Actions.Columns.Add(discount);

            DataColumn amount = new DataColumn("Amount");
            Actions.Columns.Add(amount);

            this.Tables.Add(Actions);
        }

        public void InitAccountsTable()
        {
            Accounts = new DataTable(ACCOUNTS);

            DataColumn accountNumber = new DataColumn("Number");
            Accounts.Columns.Add(accountNumber);

            DataColumn actionTime = new DataColumn("ActionTime");
            Accounts.Columns.Add(actionTime);

            DataColumn accountSum = new DataColumn("AccountSum");
            Accounts.Columns.Add(accountSum);

            this.Tables.Add(Accounts);
        }

        public void InitProductsTable()
        {
            Products = new DataTable(PRODUCTS);

            DataColumn id = new DataColumn("Id");
            Products.Columns.Add(id);

            DataColumn productName = new DataColumn("ProductName");
            Products.Columns.Add(productName);

            DataColumn description = new DataColumn("Description");
            Products.Columns.Add(description);

            DataColumn price = new DataColumn("Price");
            Products.Columns.Add(price);

            DataColumn typeId = new DataColumn("TypeId");
            Products.Columns.Add(typeId);

            DataColumn typeName = new DataColumn("TypeName");
            Products.Columns.Add(typeName);

            this.Tables.Add(Products);
        }

        public void InitProductTypesTable()
        {
            ProductTypes = new DataTable(PRODUCT_TYPES);

            DataColumn id = new DataColumn("Id");
            ProductTypes.Columns.Add(id);

            DataColumn typeName = new DataColumn("TypeName");
            ProductTypes.Columns.Add(typeName);

            DataColumn description = new DataColumn("Description");
            ProductTypes.Columns.Add(description);

            this.Tables.Add(ProductTypes);
        }

    }
}
