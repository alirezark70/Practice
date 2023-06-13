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
    public class SqlBulkSample: TransactionalSample
    {
        
        private DataTable CreateDataTable(List<string> listCoulmn)
        {
            DataTable dt=new DataTable();
            foreach(var item in listCoulmn)
            {
                dt.Columns.Add(new DataColumn(item));
            }
            return dt;
        }


        public void AddBulk()
        {
            //با این کلاس می توانیم مقدار را به صورت بالک وارد دیتابیس کنیم که سرعت ذخیره اطلاعات بشدت بالا می باشد
            SqlBulkCopy sqlBulk = new SqlBulkCopy(connection:this.connection);

            sqlBulk.DestinationTableName = nameof(BulkTable);

            var makeTable =new List<string>(){ "Name","Description"};
            //ساخت دیتا تیبل برای اینکه بتوانیم به صورت بالک اطلاعات را وارد کنیم
            var createDataTAble = CreateDataTable(makeTable);

            for(int i = 0; i < 10000; i++)
            {
                createDataTAble.Rows.Add(new object[] {$"Name{i}" , $"Description{i}" });
            }
            connection.Open();
            sqlBulk.WriteToServer(createDataTAble);
            connection.Close();
        }


    }
}
