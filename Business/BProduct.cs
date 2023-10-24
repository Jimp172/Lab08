using System;
using System.Collections.Generic;
using Entity1;
using Data;

namespace Business
{
    public class BProduct
    {
        private DProduct data;

        public BProduct()
        {
            data = new DProduct();
        }

        public List<Product> GetAllProducts()
        {
            // Llama al método Get del componente de acceso a datos para obtener la lista completa de productos.
            return data.Get();
        }

        public List<Product> GetByName(string Name)
        {
            List<Product> result = new List<Product>();

            var products = data.Get();

            foreach (var product in products) 
            {
                if(product.Name == Name)
                {
                    result.Add(product);
                }
            }
            return result;
        }
        public void CreateProduct(Product product)
        {

            data.Create(product);
        }

        public void UpdateProduct(Product product)
        {
            data.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            data.Delete(product);
        }

        public void ActiveProduct(Product product) 
        { 
            data.Active(product);
        }
    }
}
