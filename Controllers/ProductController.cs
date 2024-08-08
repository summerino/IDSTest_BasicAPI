using IDSTest_BasicAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace IDSTest_BasicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> Products = 
        [
            new Product {
                Id = 1,
                Name = "Bag",
                Price = 25000
            },
            new Product {
                Id = 2,
                Name = "Book",
                Price = 8000
            },
            new Product {
                Id = 3,
                Name = "Pencil",
                Price = 3500
            },
            new Product {
                Id = 4,
                Name = "Ballpoint",
                Price = 5000
            },
            new Product {
                Id = 5,
                Name = "Eraser",
                Price = 2500
            },

        ];

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        [HttpPost]
        public IEnumerable<Product> Insert(Product data)
        {
            Products.Add(data);
            return Products;
        }

        [HttpPut]
        public IEnumerable<Product> Update(Product data)
        {
            var dataIndex = Products.FindIndex(x => x.Id == data.Id);
            if (dataIndex != -1)
            {
                Products[dataIndex] = data;
            }
            return Products;
        }

        [HttpPut("{id}")]
        public IEnumerable<Product> Delete(int id)
        {
            var productData = Products.First(x => x.Id == id);
            Products.Remove(productData);
            return Products;
        }
    }
}
