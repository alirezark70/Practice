using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheCleanCode
{

    //G31: Hidden Temporal Couplings
    //وابستگی زمانی اجرا
    public class HiddenTemporalCouplings
    {
        private string _connectionString;
        private bool _connected;

        public void SetConnectionString(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Connect()
        {
            if (_connectionString == null)
                throw new InvalidOperationException("Connection string not set!");
            // شبیه‌سازی اتصال...
            _connected = true;
        }

        public void ExecuteQuery(string sql)
        {
            if (!_connected)
                throw new InvalidOperationException("Not connected!");
            Console.WriteLine($"Execute: {sql}");
        }
    }


    
    public class HiddenTemporalCouplingsRefactor
    {
        private HiddenTemporalCouplingsRefactor() { }


        public static HiddenTemporalCouplingsRefactor TryToConnect(string connectionString)
        {
            if (connectionString == null) throw new InvalidOperationException();

            if(IsConnected(connectionString))
                return new HiddenTemporalCouplingsRefactor();

            return new HiddenTemporalCouplingsRefactor();
        }

        public static bool IsConnected(string connectionString)
        {
            if (connectionString == null) throw new InvalidOperationException();

            return true;
        }



    }

}
