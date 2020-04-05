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
    public class Account
    {
        public const string ACCOUNTS = "Accounts";
        

        /// <summary>
        /// Выполняет запрос к БД (таблица Accounts) с учетом указанных фильтров
        /// </summary>
        /// <param name="filters">Параметры фильтра</param>
        /// <returns>DataSet из заполненной таблицей Accounts</returns>
        /// <exception cref="ErrorWorkingDb">Выбрасывается в случае ошибки при выполнении запроса к БД. Логируется.</exception>
        public CashDescDataSet GetAccounts(AccountFilter filter)
        {
            var ds = new CashDescDataSet();

            using(var conn = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAccounts";

                cmd.Parameters.AddWithValue("@number", filter?.Number);
                cmd.Parameters.AddWithValue("@productName", filter?.ProductName);
                cmd.Parameters.AddWithValue("@accountDate", filter?.AccountDate);
                cmd.Parameters.AddWithValue("@sumFrom", filter?.SumFrom);
                cmd.Parameters.AddWithValue("@sumTo", filter?.SumTo);
                

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                try
                {
                    adapter.Fill(ds, ACCOUNTS);
                }
                catch (SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }
            }


            return ds;
        }
    
        public DataTable GetProductsFromAccount(string accountNumber)
        {
            DataTable productsTable = new DataTable();
            DataColumn productId = new DataColumn("Id");
            productsTable.Columns.Add(productId);
            DataColumn productName = new DataColumn("ProductName");
            productsTable.Columns.Add(productName);

            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetProductsFromAccount";

                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                try
                {
                    adapter.Fill(productsTable);
                }
                catch (SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }
            }

                return productsTable;
        }
    }
}
