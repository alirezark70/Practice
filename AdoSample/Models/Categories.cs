using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoSample.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
    }
    public class Categories: BaseModel
    {
        public string CategoryName { get; set; }
    }

    public class Products: BaseModel
    {
        public int MyProperty { get; set; }

        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Price { get; set; }
    }

    public class Orders:BaseModel
    {
        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }
    }
}
