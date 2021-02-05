using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab0_KASRMAGZ.Models.Data;
using Lab0_KASRMAGZ.Models;



namespace Lab0_KASRMAGZ.Controllers
{
    public class CustomersController : Controller
    {
        int idNumber=-1;
        // GET: CustomersController
        public ActionResult Index()
        {
            //Order.TryNeed();
            return View(Singleton.Instance.CustomersList);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var ViewCustomers = Singleton.Instance.CustomersList.Find(x => x.Id == id);
            return View(ViewCustomers);
        }

        // GET: CustomersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newCustomers = new Models.Customers
                {
                    Id = idNumber + 1,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Telephone = Convert.ToInt32(collection["Telephone"]),
                    Description = collection["Description"]
                };
                idNumber = idNumber + 1;
                Singleton.Instance.CustomersList.Add(newCustomers);
                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            var EditCustomers = Singleton.Instance.CustomersList.Find(x => x.Id == id);
            return View(EditCustomers);
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var DeleteCustomers = Singleton.Instance.CustomersList.Find(x => x.Id == id);
                Singleton.Instance.CustomersList.Remove(DeleteCustomers);

                var UpdateCustomers = new Models.Customers
                {
                    Id = Convert.ToInt32(collection["Id"]),
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Telephone = Convert.ToInt32(collection["Telephone"]),
                    Description = collection["Description"]
                };

                Singleton.Instance.CustomersList.Add(UpdateCustomers);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomersController/Delete/5
        public ActionResult Delete(int id)
        {
            var DeleteCustomers = Singleton.Instance.CustomersList.Find(x => x.Id == id);
            Singleton.Instance.CustomersList.Remove(DeleteCustomers);
            return View(DeleteCustomers);
        }

        // POST: CustomersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var DeleteCustomers = Singleton.Instance.CustomersList.Find(x => x.Id == id);
                Singleton.Instance.CustomersList.Remove(DeleteCustomers);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Sort()
        {
            Order.TryNeed();
            return RedirectToAction(nameof(Index));
        }
    }
}
