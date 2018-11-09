using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.InMemory
{
    public class ProductCatagoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCatagory> productCatagories;

        public ProductCatagoryRepository()
        {
            productCatagories = cache["productCatagories"] as List<ProductCatagory>;
            if (productCatagories == null)
            {
                productCatagories = new List<ProductCatagory>();
            }
        }

        public void Commit()
        {
            cache["productCatagories"] = productCatagories;
        }

        public void Insert(ProductCatagory p)
        {
            productCatagories.Add(p);
        }

        public void Update(ProductCatagory productCatagory)
        {
            ProductCatagory productCatagoryToUpdate = productCatagories.Find(p => p.Id == productCatagory.Id);

            if (productCatagoryToUpdate != null)
            {
                productCatagoryToUpdate = productCatagory;
            }
            else
            {
                throw new Exception("ProductCatagory not found");
            }
        }

        public ProductCatagory Find(string Id)
        {
            ProductCatagory productCatagory = productCatagories.Find(p => p.Id == Id);
            if (productCatagory != null)
            {
                return productCatagory;
            }
            else
            {
                throw new Exception("ProductCatagory not found");
            }
        }

        public IQueryable<ProductCatagory> Collection()
        {
            return productCatagories.AsQueryable();
        }

        public void Delete(string Id)
        {
            ProductCatagory productCatagoryToDelete = productCatagories.Find(p => p.Id == Id);
            if (productCatagoryToDelete != null)
            {
                productCatagories.Remove(productCatagoryToDelete);
            }
            else
            {
                throw new Exception("ProductCatagory not found");
            }
        }
    }
}
