using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using Project.Services;

namespace Project.Controllers
{
    public class SupplierController : Controller
    {
        private readonly SupplierService supplierService;

        public SupplierController(SupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: SupplierController
        public ActionResult Index()
        {
            List<SupplierModel> suppliers = supplierService.GetAllSuppliers();

            foreach (SupplierModel supplier in suppliers)
            {
                if (supplier.EmailAddress == "")
                {
                    supplier.EmailAddress = "Niet bekend";
                }
            }

            return View(suppliers);
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(string id)
        {
            SupplierModel model = supplierService.GetOne(id);

            if(model.EmailAddress == "")
            {
                model.EmailAddress = "Niet bekend";
            }

            return View(model);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                SupplierModel newSupplier = new SupplierModel();

                newSupplier.Supplier = collection["Supplier"];
                newSupplier.Address = collection["Address"];
                newSupplier.Phonenumber = collection["Phonenumber"];
                newSupplier.EmailAddress = collection["EmailAddress"];

                supplierService.Create(newSupplier);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Edit/5
        public ActionResult Edit(string id)
        {
            return View(supplierService.GetOne(id));
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                SupplierModel newSupplier = supplierService.GetOne(id);

                newSupplier.Supplier = collection["Supplier"];
                newSupplier.Address = collection["Address"];
                newSupplier.Phonenumber = collection["Phonenumber"];
                newSupplier.EmailAddress = collection["EmailAddress"];

                supplierService.Update(id, newSupplier);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(string id)
        {
            supplierService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        // POST: SupplierController/Delete/5
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
