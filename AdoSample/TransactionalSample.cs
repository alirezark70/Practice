using AdoSample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AdoSample
{
    public class TransactionalSample
    {
        //تراکنسکشنال یعنی یا کل درخواست انجام شود و اگر یک درخواست انجام نشد کل کوئری و تغییرات رول بک بشه
        private readonly string connectionString = "";
        internal protected SqlConnection connection;
        internal protected SqlTransaction? transaction;
        public TransactionalSample()
        {
            connectionString =new  ConnectionStringMaker().MakeConnectionString();
            connection = new SqlConnection(connectionString);
            transaction = null;
        }

        public void SelectTransactionalCategoryMethod()
        {
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandType=System.Data.CommandType.Text,
                CommandText="SELECT * FROM Categories"
            };
            try
            {

                transaction= connection.BeginTransaction();
                var reader = ExecuteQuery(command);
                ReadQuery(reader);
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction.Rollback();
                Console.WriteLine("RollBack Query");
            }


        }


        public void SelectTransactionalProductsMethod()
        {
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM Products"
            };

            try
            {
                transaction = connection.BeginTransaction();
                var reader = ExecuteQuery(command);
                ReadQuery(reader);
                transaction.Commit();

            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                Console.WriteLine("RollBack Query");
            }
        }

        public void Add(BulkTable model)
        {
            SqlCommand command = new SqlCommand
            {
                Connection = connection,
                CommandType = System.Data.CommandType.Text,
                CommandText = $"INSERT INTO BulkTable(Name,Description) VALUES('{model.Name}','{model.Description}')"
            };
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void AddRange(List<BulkTable> bulkTables)
        {
            foreach(var item in bulkTables)
            {
                Add(item);
            }
        }



        public virtual void ReadQuery(SqlDataReader dataReader)
        {
            do
            {
                while (dataReader.Read())
                {
                    for (int i = 0; i < dataReader.FieldCount; i++)
                    {
                        Console.Write(dataReader.GetName(i));
                        Console.Write(":");
                        Console.Write(dataReader.GetValue(i));

                    }
                    Console.Write("\n");
                }
            } while (dataReader.NextResult());
        }

        public virtual  SqlDataReader ExecuteQuery(SqlCommand command)

        {
            if(connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }
            

            SqlDataReader reader =command.ExecuteReader();

            
            if(connection.State==ConnectionState.Open)
            {
                connection.Close();
            }
            return reader;
        }


        public void ExecuteSqlTransation()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand
                    {

                        Connection = connection,
                        CommandType = System.Data.CommandType.Text,
                        CommandText = "SELECT * FROM Categories"
                    };
                    SqlTransaction transaction;
                    transaction = connection.BeginTransaction();

                    command.Connection = connection;
                    command.Transaction = transaction;

                    command.ExecuteNonQuery();

                    transaction.Commit();
                    connection.Close();
                }
                catch (Exception ex)
                {

                    try
                    {
                        transaction?.Rollback();
                    }
                    catch (Exception ex2)
                    {

                        Console.WriteLine(ex2.Message);
                    }
                }

            }
        }
    }
}
