using Data;
using Entity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ProductBusiness
    {
        public List<Product> Get()
        {
            ProductData data = new ProductData();

            var products = data.Get();
            return products;
        }

        public List<Product> GetProductsByName(string name)
        {
            ProductData data = new ProductData();

            var products = data.Get().Where(p => p.Name.ToLower().Contains(name.ToLower())).ToList();
            return products;
        }

        public IEnumerable GetProductsByName()
        {
            throw new NotImplementedException();
        }
    }
}
