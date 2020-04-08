using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashDesc
{
    class BusinessLogic
    {
        internal static CashDescDataSet ProductDs;
        internal static CashDescDataSet ProductTypesDs;
        internal static CashDescDataSet AccountDs;
        private static Product Product { get; }
        private static ProductType ProductType { get; }
        private static Account Account { get; }

        static BusinessLogic()
        {
            Product = new Product();
            ProductDs = new CashDescDataSet();
            ProductDs.InitProductsTable();

            ProductType = new ProductType();
            ProductTypesDs = new CashDescDataSet();
            ProductTypesDs.InitProductTypesTable();

            Account = new Account();
            AccountDs = new CashDescDataSet();
            AccountDs.InitActionsTable();
            AccountDs.InitAccountsTable();
        }
        

        internal void LoadProductTypes()
        {
            ProductTypesDs = ProductType.GetProductTypes();
        }

        internal void LoadProducts(ProductFilter filter)
        {
            ProductDs = Product.GetProducts(filter);
        }
    
        internal List<ProductType> GetProductTypeList()
        {
            if(ProductTypesDs.Tables[CashDescDataSet.PRODUCT_TYPES]?.Rows == null)
                LoadProductTypes();

            var result = new List<ProductType>();
            foreach (DataRow row in ProductTypesDs.Tables[CashDescDataSet.PRODUCT_TYPES].Rows)
            {
                var pt = new ProductType {
                    Id = (int)row["Id"],
                    TypeName = (string)row["TypeName"],
                    Description = (string)row["Description"]
                };
                result.Add(pt);
            }

            return result;
        }

        internal List<Product> GetProductList()
        {
            if (ProductTypesDs.Tables[CashDescDataSet.PRODUCTS]?.Rows == null)
                LoadProducts(null);

            var result = new List<Product>();
            foreach (DataRow row in ProductDs.Tables[CashDescDataSet.PRODUCTS].Rows)
            {
                var product = new Product
                {
                    Id = (int)row["Id"],
                    ProductName = (string)row["ProductName"],
                    Description = row["Description"] as string,//Допускается DBNull
                    Price = (decimal)row["Price"],
                    TypeId = (int)row["TypeId"]
                };
                result.Add(product);
            }

            return result;
        }

        internal void UpdateProducts(bool forceUpdate = false)
        {
            ProductDs = Product.Update(ProductDs, forceUpdate);
        }

        internal void LoadAccounts(AccountFilter filter)
        {
            AccountDs = Account.GetAccounts(filter);
        }
    
        internal void LoadActionsFromAccount(int accountId)
        {
            Account.GetActionsFromAccount(accountId, AccountDs.Tables[CashDescDataSet.ACTIONS]);
        }

        internal void UpdateAccounts(bool forceUpdate = false)
        {
            AccountDs = Account.Update(AccountDs, forceUpdate);
        }
    
        internal int CreateAccount()
        {
            return Account.CreateAccount();
        }
    }
}
