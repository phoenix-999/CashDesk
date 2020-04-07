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
    public class Account
    {
        private AccountFilter _lastFilter = null;

        /// <summary>
        /// Выполняет запрос к БД (таблица Accounts) с учетом указанных фильтров
        /// </summary>
        /// <param name="filters">Параметры фильтра</param>
        /// <returns>DataSet из заполненной таблицей Accounts</returns>
        /// <exception cref="ErrorWorkingDb">Выбрасывается в случае ошибки при выполнении запроса к БД. Логируется.</exception>
        public CashDescDataSet GetAccounts(AccountFilter filter)
        {
            _lastFilter = filter;
            var ds = new CashDescDataSet();
            ds.InitActionsTable();

            using(var conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                SqlCommand accountCmd = new SqlCommand();
                accountCmd.Connection = conn;
                accountCmd.CommandType = CommandType.StoredProcedure;
                accountCmd.CommandText = "GetAccounts";

                accountCmd.Parameters.AddWithValue("@number", filter?.Number);
                accountCmd.Parameters.AddWithValue("@productName", filter?.ProductName);
                accountCmd.Parameters.AddWithValue("@accountDate", filter?.AccountDate);
                accountCmd.Parameters.AddWithValue("@sumFrom", filter?.SumFrom);
                accountCmd.Parameters.AddWithValue("@sumTo", filter?.SumTo);
                

                SqlDataAdapter accountAdapter = new SqlDataAdapter();
                accountAdapter.SelectCommand = accountCmd;

                try
                {
                    accountAdapter.Fill(ds, CashDescDataSet.ACCOUNTS);
                }
                catch (SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }

                DataRelation relation = ds.Relations.Add("AccountsActions",
                  ds.Tables[CashDescDataSet.ACCOUNTS].Columns["Number"],
                  ds.Tables[CashDescDataSet.ACTIONS].Columns["AccountNumber"]);
            }


            return ds;
        }
    

        public void GetActionsFromAccount(int accountNumber, DataTable resultTable)
        {
            if (resultTable == null) throw new ArgumentNullException();
            if (resultTable.TableName != CashDescDataSet.ACTIONS) throw new ArgumentException();

            resultTable.Clear();

            using (var conn = new SqlConnection(Config.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetActionsFromAccount";
                cmd.Parameters.AddWithValue("@accountNumber", accountNumber);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                try
                {
                    adapter.Fill(resultTable);
                }
                catch (SystemException ex)
                {
                    Config.Logger.Error(ex.ToString());
                    throw new ErrorWorkingDb(ex);
                }
            }
        }


        /// <summary>
        /// Обновляет таблицы Accounts и Actions в режиме транзакции
        /// </summary>
        /// <param name="ds">DataSet с таблицами Accounts и Actions</param>
        /// <returns>DataSet из заполненной таблицей Accounts</returns>
        /// <exception cref="ErrorWorkingDb">Выбрасывается в случае ошибки при выполнении запроса к БД. Логируется.</exception>
        /// <exception cref="ArgumentNullException">Отсутсвует одна или все таблицы в DataSet</exception>
        /// <exception cref="DBConcurrencyException"> Попытка выполнить инструкцию INSERT, UPDATE или DELETE привела к нулевому количеству
        ///     обработанных записей.  Не логируется.</exception>
        public CashDescDataSet Update(CashDescDataSet ds, bool forceUpdate=false)
        {
            if(ds == null || ds.Tables.Contains(CashDescDataSet.ACCOUNTS) == false || ds.Tables.Contains(CashDescDataSet.ACTIONS) == false)
            {
                throw new ArgumentNullException();
            }

            try
            {
                using (var scope = new TransactionScope())
                {
                    using (var conn = new SqlConnection(Config.ConnectionString))
                    {
                        conn.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        string cmdText = "select Number, ActionTime from Accounts";
                        adapter.SelectCommand = new SqlCommand(cmdText, conn);
                        var cmdBuilder = new SqlCommandBuilder(adapter);

                        adapter.ContinueUpdateOnError = forceUpdate;

                        try
                        {
                            adapter.Update(ds, CashDescDataSet.ACCOUNTS);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Config.Logger.Error(ex.ToString());
                            throw new ErrorWorkingDb(ex);
                        }
                        catch (DBConcurrencyException ex)
                        {
                            throw ex;
                        }

                        cmdText = "select Id, AccountNumber, ProductId, Discount from Actions";
                        adapter.SelectCommand = new SqlCommand(cmdText, conn);
                        cmdBuilder.RefreshSchema();

                        try
                        {
                            adapter.Update(ds, CashDescDataSet.ACTIONS);
                        }
                        catch (InvalidOperationException ex)
                        {
                            Config.Logger.Error(ex.ToString());
                            throw new ErrorWorkingDb(ex);
                        }
                        catch (DBConcurrencyException ex)
                        {
                            throw ex;
                        }

                        ds.AcceptChanges();
                        scope.Complete();
                    }
                }
            }
            catch (TransactionAbortedException ex)
            {
                Config.Logger.Error(ex.GetBaseException().ToString());
                throw new ErrorWorkingDb(ex);
            }

            return GetAccounts(_lastFilter);
        }
    }
}
