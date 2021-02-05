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
 
        // GET: CustomersController
        public ActionResult Index()
        {
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
                int LastTryIdNumber;
                if(Singleton.Instance.CustomersList.Count == 0)
                {
                    LastTryIdNumber = 0;
                }
                else
                {
                    LastTryIdNumber = Singleton.Instance.CustomersList.Count;
                }
                var newCustomers = new Models.Customers
                {
                    Id = LastTryIdNumber,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Telephone = Convert.ToInt32(collection["Telephone"]),
                    Description = collection["Description"]
                };
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
                    Id=id,
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                    Telephone = Convert.ToInt32(collection["Telephone"]),
                    Description = collection["Description"]
                };

                Singleton.Instance.CustomersList.Insert(id, UpdateCustomers);
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

                //for(int i =id; i<Singleton.Instance.CustomersList.Count-1; i++)
                //{
                //    int IdDelete = id;
                //    string NameTryDelete = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == id+1).Name);
                //    string LastNameDelete= Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == id+1).LastName);
                //    int TelephoneTryDelete = Convert.ToInt32(Singleton.Instance.CustomersList.Find(x => x.Id == id+1).Telephone);
                //    string DescriptionTryDelete = Convert.ToString(Singleton.Instance.CustomersList.Find(x => x.Id == id+1).Description);

                //    var UpdateCustomers = new Models.Customers
                //    {
                //        Id = id,
                //        Name = NameTryDelete,
                //        LastName = LastNameDelete,
                //        Telephone = TelephoneTryDelete,
                //        Description = DescriptionTryDelete
                //    };

                //    var GDeleteCustomers = Singleton.Instance.CustomersList.Find(x => x.Id == id);
                //    Singleton.Instance.CustomersList.Remove(GDeleteCustomers);
                //    Singleton.Instance.CustomersList.Insert(id, UpdateCustomers);

                //    id++;
                //}

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Sort()
        {
            Order.TryNeed(1);
            return RedirectToAction(nameof(Index));
        }

        public ActionResult SortLastName()
        {
            Order.TryNeed(2);
            return RedirectToAction(nameof(Index));
        }
    }
}
