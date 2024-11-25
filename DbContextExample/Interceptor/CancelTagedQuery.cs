using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbContextExample.Interceptor
{
    public class CancelTagedQuery:DbCommandInterceptor
    {

        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            //با اینترسپتورها می توانیم
            //کوئری های که در حال انجام هستند و دارن اجرا می شوند رو فرایند هایی را روش انجام دهیم
            //یه کافنیگ هم سمت دبی کانتکس داره
            //OnConfigure
            var query = command.CommandText;

            return base.ReaderExecuting(command, eventData, result);
        }
    }
}
