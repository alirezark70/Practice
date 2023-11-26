using QueryGenereateProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QueryGenereateProject.Helper
{
    public class DataGenerator
    {
        private StringBuilder _query;
        private string _whereCondition;

        public DataGenerator(string whereCondition = null)
        {
            _whereCondition = whereCondition;
            _query = new StringBuilder("SELECT ");
        }

        public string FromModel { get; set; }
        public string FromModelAlias => FromModel.ToLower();
        public List<SelectItem> SelectItems { get; set; } = new List<SelectItem>();
        public List<JoinModel> InnerJoins { get; set; } = new List<JoinModel>();
        public List<JoinModel> LeftJoins { get; set; } = new List<JoinModel>();

        public string Generate()
        {
            int index = 0;

            foreach (var item in SelectItems)
            {
                int countList = SelectItems.Count-1;
                
                string line="";
                if (countList!=index)
                {
                   line = $"{item.ModelName.ToLower()}.{item.Field} AS {item.Alias} ,";
                }
                else
                {
                    line = $"{item.ModelName.ToLower()}.{item.Field} AS {item.Alias} ";
                }
                index++;

                _query.Append(line);
            }

            _query.Append($" FROM {FromModel} AS {FromModelAlias} ");

            foreach (var item in InnerJoins)
            {
                _query.Append($"INNER JOIN {item.MainModel} AS {item.MainAlias} ON {item.LeftCondition} = {item.RightCondition} ");
            }

            foreach (var item in LeftJoins)
            {
                _query.Append($"LEFT JOIN {item.MainModel} AS {item.MainAlias} ON {item.LeftCondition} = {item.RightCondition} ");
            }

            if (!string.IsNullOrEmpty(_whereCondition))
                _query.Append(_whereCondition);

            

            return _query.ToString();
        }

    }

    public class SelectItem
    {
        public SelectItem(string modelName,string field,string alias)
        {
            ModelName=modelName;
            Field = field;
            Alias = alias;
        }

        public string Field { get; set; }
        public string Alias { get; set; }
        public string ModelName { get; set; }
    }

    public class JoinModel
    {
        public JoinModel(string mainModel,string subModel)
        {
            MainModel = mainModel;
            SubModel = subModel;
        }

        public string  MainModel { get; set; }
        public string  SubModel { get; set; }
        public string MainAlias =>MainModel.ToLower();
        public string SubAlias => SubModel.ToLower();
        public string LeftCondition => $"{MainAlias}.{SubModel}" + "Id";
        public string RightCondition => $"{SubAlias}." + "Id";
    }
}


