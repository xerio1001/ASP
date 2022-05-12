using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService productService;
        private readonly SupplierService supplierService;

        public ProductController(ProductService productService, SupplierService supplierService)
        {
            this.productService = productService;
            this.supplierService = supplierService;
        }

        // GET: ProductController
        public ActionResult Index(string id)
        {
            List<SupplierModel> supplierModel = new List<SupplierModel>();
            List<SupplierModel> suppliers = supplierService.GetAllSuppliers();

            foreach (SupplierModel supplier in suppliers)
            {
                supplierModel.Add(supplier);
            }

            ViewBag.displaySuppliers = supplierModel;

            if (id == "" || id == null)
            {
                return View(productService.GetAllProducts());
            }
            else
            {
                return View(productService.GetProductBySupplier(id));
            }
        }

        public ActionResult OrderOverview()
        {
            ViewBag.suppliersWithoutStock = supplierService.GetSupplierWithoutEnoughStock();

            return View();
        }

        public ActionResult Order(string id)
        {
            ViewBag.mailTo = supplierService.GetSupplierMail(id);
            return View(supplierService.GetItemOfPickedSupplier(id));
        }
        // POST: ProductController/Order
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(IFormCollection collection)
        {
            try
            {
                string ordered = collection["Besteld"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Details/5
        public ActionResult Details(string id)
        {
            List<string> supplierNames = productService.GetSupplierByName(id);
            ViewBag.displaySupplierName = supplierNames;

            return View(productService.GetOne(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            List<SupplierModel> suppliers = supplierService.GetAllSuppliers();
            MultiSelectList supplierList = new MultiSelectList(suppliers, "Id", "Supplier");
            ViewBag.suppliers = supplierList;

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
                newProduct.AmountInStock = int.Parse(collection["AmountInStock"]);
                newProduct.SupplierId = collection["SupplierId"];
                newProduct.Barcode = collection["Barcode"];
                newProduct.Ordered = collection["Ordered"].Contains("true");

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
            List<SupplierModel> suppliers = supplierService.GetAllSuppliers();
            MultiSelectList supplierList = new MultiSelectList(suppliers, "Id", "Supplier");
            ViewBag.suppliers = supplierList;

            return View(productService.GetOne(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                ProductModel newProduct = productService.GetOne(id);

                newProduct.Name = collection["Name"];
                newProduct.Brand = collection["Brand"];
                newProduct.AmountInStock = int.Parse(collection["AmountInStock"]);
                newProduct.SupplierId = collection["SupplierId"];
                newProduct.Barcode = collection["Barcode"];
                newProduct.Ordered = collection["Ordered"].Contains("true");
                //newProduct.Ordered = Convert.ToBoolean(collection["Ordered"].First()); //<- Werkt ook.

                productService.Update(id, newProduct);

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
