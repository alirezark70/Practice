using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneCs
{
    public class Person
    {
        public List<string> PrintFullName(string firstName,string lastName,params string[] argum)
        {
            StringBuilder sb = new();
            sb.Append(firstName);
            sb.AppendLine(lastName);
            foreach(var arg in argum)
            {
                sb.AppendLine(arg);
            }
            return CleanString(sb);
        }
        private List<string> CleanString(StringBuilder sb)
        {
            List<string> result = new();
            result = sb.ToString().Split("\n").ToList();
            List<string> list = new();
            foreach(var item in result)
            {
                if( item.Contains("\r") && item.Length>0)
                {
                    
                    list.Add(string.Concat(item.Reverse().Skip(2).Reverse()));
                }
               
            }
            return list;
        }
        public int Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; init; }


    }
}
