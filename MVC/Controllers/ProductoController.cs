using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Business;
using Entity1;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public ActionResult Index()
        {
            BProduct bproduct = new BProduct();

            List<Product> products = bproduct.GetAllProducts();

            List<ProductoModel> productsModel = products.Select(x => new ProductoModel
            {
                ProductId = x.ProductId,
                Name = x.Name,
                Price = x.Price,
                Stock = x.Stock,
                Active = x.Active,
            }).ToList();
            return View(productsModel);
        }

        // GET: ProductoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModel model)
        {
            try
            {
                BProduct bproduct = new BProduct();

                Product newProduct = new Product
                {
                    Name = model.Name,
                    Price = model.Price,
                    Stock = model.Stock
                };
                bproduct.CreateProduct(newProduct);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int ProductId)
        {
            BProduct bproduct = new BProduct();
            Product product = bproduct.GetProductById(ProductId);


            ProductoModel model = new ProductoModel
            {
                ProductId = product.ProductId,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,

            };
            return View(model);
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int ProductId, ProductoModel model)
        {
            try
            {
                BProduct bproduct = new BProduct();

                Product product = new Product
                {
                    ProductId = model.ProductId,
                    Name = model.Name,
                    Price = model.Price,
                    Stock = model.Stock,
                };
                bproduct.UpdateProduct(product);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
