using DataLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DataLib.Models
{
    public class Product
    {

        private ProductFilter _lastFilter = null;

        /// <summary>
        /// Выполняет запрос к БД (таблица Products) с учетом указанных фильтров
        /// </summary>
        /// <param name="filters">Параметры фильтра</param>
        /// <returns>DataSet из заполненной таблицей Products</returns>
        /// <exception cref="ErrorWorkingDb">Выбрасывается в случае ошибки при выполнении запроса к БД. Логируется.</exception>
        /// <exception cref="InputDataException">Выбрасывается в случае ошибки данных запроса. Логируется.</exception>
        /// <exception cref="DBConcurrencyException"> Попытка выполнить инструкцию INSERT, UPDATE или DELETE привела к нулевому количеству
        //     обработанных записей.  Не логируется.</exception>
        public CashDescDataSet GetProducts(ProductFilter filters)
        {
            _lastFilter = filters;
            var ds = new CashDescDataSet();

            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
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
                    adapter.Fill(ds, CashDescDataSet.PRODUCTS);
                }
                catch (SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }
            }
            
            return ds;
        }
    
        public CashDescDataSet Update(CashDescDataSet ds, bool forceUpdate=false)
        {
            using (SqlConnection conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();

                SqlDataAdapter adapter = new SqlDataAdapter();

                var cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.Transaction = transaction;
                cmd.CommandText = "select Id, ProductName, Price, Description, TypeId from Products";

                SqlCommand deleteCmd = new SqlCommand();
                deleteCmd.Connection = conn;
                deleteCmd.CommandType = CommandType.StoredProcedure;
                deleteCmd.Transaction = transaction;
                deleteCmd.CommandText = "DeleteProduct";
                deleteCmd.Parameters.Add(new SqlParameter("@id", SqlDbType.Int, 0, "Id"));

                adapter.SelectCommand = cmd;
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(adapter);
                adapter.DeleteCommand = deleteCmd;

                adapter.ContinueUpdateOnError = forceUpdate;

                try
                {
                    adapter.Update(ds, CashDescDataSet.PRODUCTS);
                    ds.AcceptChanges();
                    transaction.Commit();
                }
                catch (InvalidOperationException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    transaction.Rollback();
                    throw new ErrorWorkingDb(ex);
                }
                catch (SqlException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    transaction.Rollback();
                    throw new InputDataException(ex);
                }
                catch (DBConcurrencyException ex)
                {
                    transaction.Rollback();
                    throw ex;
                }
                    
            }
            return GetProducts(_lastFilter);
        }

    
    }
}
