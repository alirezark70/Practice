using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcurrencyInCSharp
{
    internal class LazyInitializationSample
    {
    }

    public class Product
    {
        private Lazy<List<ProductImage>> _productImages;

        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
            _productImages = new Lazy<List<ProductImage>>(LoadProductImagesAsync);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        private List<ProductImage> LoadProductImagesAsync()
        {
            Console.WriteLine($"در حال بارگذاری تصاویر برای محصول: {Name}");

            //شبیه سازی بارگزاری فایل
            System.Threading.Thread.Sleep(10000);

            return new List<ProductImage>
            {
                new ProductImage {
                    Id = Id,
                    Name="File1",
                    File=new byte[0]
                },
                new ProductImage {
                    Id = Id,
                    Name="File1",
                    File=new byte[0]
                }
            };
        }
        public List<ProductImage> GetImages()
        {
            // تصاویر تنها در این لحظه بارگذاری می‌شوند  
            return _productImages.Value;
        }

        public bool AreImagesLoaded => _productImages.IsValueCreated;

    }

    public class ProductImage
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public byte[]? File { get; set; }
    }
}
