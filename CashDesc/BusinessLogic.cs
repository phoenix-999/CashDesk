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
        private static Product Product { get; }
        private static ProductType ProductType { get; }

        static BusinessLogic()
        {
            Product = new Product();
            ProductDs = new CashDescDataSet();
            ProductDs.InitProductsTable();

            ProductType = new ProductType();
            ProductTypesDs = new CashDescDataSet();
            ProductTypesDs.InitProductTypesTable();
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

        internal void UpdateProducts(bool forceUpdate = false)
        {
            ProductDs = Product.Update(ProductDs, forceUpdate);
        }
    }
}
