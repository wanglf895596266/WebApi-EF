using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webapi.Models;

namespace webapi.Controllers
{
    public class ProductController : ApiController
    {
        List<Product> products = new List<Product>()
       {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1.39M },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
       };
        /// <summary>
        /// 获取所有的产品信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Product> GetProductList()
        {
            return products;
        }

        /// <summary>
        /// 获取单个产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public Product GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product != null) return product;
            var resp = new HttpResponseMessage(HttpStatusCode.NotFound);
            throw new HttpResponseException(resp);
        }

        /// <summary>
        /// 添加新产品 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        public Guid AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新某个产品信息
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        [HttpPost]
        public void UpdateProduct(Guid productId, Product product)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 删除某个产品
        /// </summary>
        /// <param name="productId"></param>
        [HttpDelete]
        public void DeleteProduct(Guid productId)
        {
            throw new NotImplementedException();
        }

    }
}
