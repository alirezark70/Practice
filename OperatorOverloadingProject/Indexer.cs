using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorOverloadingProject
{
    
    public class Wallet
    {
        private readonly List<MoneyIndexer> _wallets=new List<MoneyIndexer>();

        public MoneyIndexer this [int index]{ 
            get 
            {
                return _wallets[index];
            }
            set
            {
                if (_wallets.Count > index)
                    _wallets[index] = value;
                else 
                    _wallets.Add(value);
            }
        
        }
    }
    public class MoneyIndexer
    {
        public int Value { get; set; }
    }

    public class Indexer
    {
        //می توانیم با قابلیت ایندکسر با کلاس آبجکت مثل آرایه ایندکس گذاری کنیم 
    }
}
