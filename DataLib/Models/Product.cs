using DataLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib.Models
{
    public class Product
    {

        public const string PRODUCTS = "Products";
        public const string PRODUCT_TYPES = "ProductTypes";


        /// <summary>
        /// Выполняет запрос к БД (таблица Products) с учетом указанных фильтров
        /// </summary>
        /// <param name="filters">Параметры фильтра</param>
        /// <returns>DataSet из заполненной таблицей Products</returns>
        /// <exception cref="ErrorWorkingDb">Выбрасывается в случае ошибки при выполнении запроса к БД. Логируется.</exception>
        public CashDescDataSet GetProducts(ProductFilter filters)
        {
            var ds = new CashDescDataSet();

            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProducts";

                cmd.Parameters.AddWithValue("@name", filters?.Name);
                cmd.Parameters.AddWithValue("@type", filters?.Type);
                cmd.Parameters.AddWithValue("@priceFrom", filters?.PriceFrom);
                cmd.Parameters.AddWithValue("@priceTo", filters?.PriceTo);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                try
                {
                    adapter.Fill(ds, PRODUCTS);
                }
                catch (SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }
            }
            
            return ds;
        }
    
        

    
    }
}
