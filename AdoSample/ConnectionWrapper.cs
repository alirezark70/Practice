using AdoSample.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSample
{
    public class ConnectionWrapper
    {
        private readonly string connectionString="";
        SqlConnection connection;
        public ConnectionWrapper()
        {
            connectionString = MakeConnectionString();
            connection = new SqlConnection(connectionString);
        }

        public void Add<T>(T input)
        {
            
            Type type = typeof(T);
            string query=$"INSERT INTO {type.Name}";

            List<string> properties = new List<string>();
            foreach (var item in type.GetProperties())
            {
                properties.Add(item.Name);
            }
            int countProperties=properties.Count();
            string parameters = "(";
            for(int i = 0; i < countProperties; i++)
            {
                parameters += $"{properties[i]}";
                parameters += ",";
            }
            parameters += ")";

            Type typeValue = input.GetType();

        }


        public void WorkingWithDataReader<T>(string conditionWithoutWhere="", string orderByPropertyName="",bool isDesc=false)
        {
            Type type = typeof(T);
            string query = $"SELECT * FROM {type.Name}"+" ";

            


            List<string> properties = new List<string>();
            foreach(var item in type.GetProperties())
            {
                properties.Add(item.Name);
            }
            
            if(!string.IsNullOrEmpty(conditionWithoutWhere))
            {
                query += "WHERE " + conditionWithoutWhere;
            }

            if(!string.IsNullOrEmpty(orderByPropertyName))
            {
                foreach(var item in properties)
                {
                    if(orderByPropertyName.Equals(item))
                    {
                        query+=" ORDER BY "+orderByPropertyName;
                    }
                }
            }
            if(isDesc is true)
            {
                query += " DESC";
            }
            connection.Open();
            SqlCommand cmd = new SqlCommand
            {
                Connection=connection,
                CommandType = CommandType.Text,
            };
            cmd.CommandText = query;
            var reader=cmd.ExecuteReader();

            do
            {
                while(reader.Read())
                {
                    for(int i=0; i< reader.FieldCount; i++)
                    {
                        Console.Write(reader.GetName(i));
                        Console.Write(":");
                        Console.Write(reader.GetValue(i));
                        
                    }
                    Console.Write("\n");
                }
            }while(reader.NextResult());
            connection.Close();
        }



        public void OpenConnection()
        {
            connection.Open();
        }

        public void CloseConnection()
        {
            connection.Close();
        }
        public void ShowConnectionState()
        {
            Console.WriteLine(connection.State);
            Console.ReadLine();
        }


        public void TestCommand()
        {
            SqlCommand command = new SqlCommand();

            command.Connection = connection;
            command.CommandType=CommandType.Text;
            connection.Open();
            command.ExecuteNonQuery();//این کوئری هیچ جوابی بر نمیگردونه و فقط جزیئیات کوئری را نمایش میده فقط یک رکورد برمیگردونه فقط برای مشاهده
            connection.Close();

        }

        public void ExecuteQuery()
        {
            
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandType= CommandType.Text;
            cmd.CommandText = "SELECT * FROM Categories";
            connection.Open();
            var reader=cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine($"Id : {reader["Id"]}\t\t CategoryName : {reader["CategoryName"]}");
                
            }
            connection.Close();
            Console.ReadLine();
        }


         private string MakeConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "OnlineShopDb";
            builder.DataSource = "localhost";
            builder.Encrypt = false;
            builder.ConnectTimeout = 200;
            builder.UserID = "sa";
            builder.Password = "Str0ngPa$$w0rd";
            return builder.ConnectionString;
        }
    }



    public class ConnectionStringMaker
    {
        //ساخت 
        //ConnectionString
        //به صورت متد 
        public string MakeConnectionString()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.InitialCatalog = "OnlineShopDb";
            builder.DataSource = "localhost";
            builder.Encrypt = false;
            builder.ConnectTimeout = 200;
            builder.UserID = "sa";
            builder.Password = "Str0ngPa$$w0rd";
            return builder.ConnectionString;
        }
    }

     
}
