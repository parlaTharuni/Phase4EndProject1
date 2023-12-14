using Phase4EndProject1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Phase4EndProject1.Controllers
{
    public class SelectionController : Controller
    {
        static List<Pizza> modelList = new List<Pizza>();
        // GET: Selection
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Insertpizza()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Insertpizza(Pizza obj)
        {
            modelList.Add(obj);

            //return Content("Received Data ");

            return RedirectToAction("ShowListOfpizzas");
            
        }

        public ActionResult ShowListOfpizzas()
        {
            //if (modelList.Count <=0)
            //{
            //    string s = "There are no customers to show now!!!";
            //    //Pass the data(string) Controller(ShowListOfCustomers) Action to the view(ShowListOfCustomers)

            //    ViewBag.message = s;

            //}
            int noOfRows = modelList.Count;
            ViewBag.rowCount = noOfRows;


            return View(modelList);



        }

        public ActionResult Edit(int id)
        {
            Pizza customer = modelList.Find(c => c.Id == id);
            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(int id, Pizza editeddata)
        {
            Pizza customer = modelList.Find(c => c.Id == id);
            customer.PizzaType = editeddata.PizzaType;
            customer.size = editeddata.size;
            customer.Qty = editeddata.Qty;
            return RedirectToAction("ShowListOfpizzas");
        }

        public ActionResult Details(int id)
        {
            Pizza customer = modelList.Find(c => c.Id == id);
            return View(customer);

        }

        public ActionResult Delete(int id)
        {
            Pizza customer = modelList.Find(c => c.Id == id);
            modelList.Remove(customer);
            return RedirectToAction("ShowListOfpizzas");
        }
    }
}