using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    public class ProductController : Controller
    {

        private readonly ProductService productService;

        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }

        // GET: ProductController
        public ActionResult Index()
        {
            return View(productService.GetAllProducts());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            return View(productService.GetOne(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                ProductModel newProduct = new ProductModel();

                newProduct.Name = collection["Name"];
                newProduct.Brand = collection["Brand"];
                newProduct.Price = Decimal.Parse(collection["Price"]);
                newProduct.AmountInStock = collection["AmountInStock"];
                newProduct.AmountPerOrder = collection["AmountPerOrder"];
                newProduct.SupplierId = collection["Supplier"];

                productService.Create(newProduct);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(string id)
        {
            return View(productService.GetOne(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
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

        // GET: ProductController/Delete/5
        public ActionResult Delete(string id)
        {
            productService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
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
