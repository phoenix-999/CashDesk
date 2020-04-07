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
    public class ProductType
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return TypeName;
        }
        /// <summary>
        /// Выполняет запрос к БД (таблица ProductTypes), выгружает данные по всем типам продуктов
        /// </summary>
        /// <returns>DataSet из заполненной таблицей ProductTypes</returns>
        /// <exception cref="ErrorWorkingDb">Выбрасывается в случае ошибки при выполнении запроса к БД. Логируется.</exception>
        public CashDescDataSet GetProductTypes()
        {
            CashDescDataSet ds = new CashDescDataSet();

            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProductTypes";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                try
                {
                    adapter.Fill(ds, CashDescDataSet.PRODUCT_TYPES);
                }
                catch(SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }
            }

            return ds;
        }
    }
}
