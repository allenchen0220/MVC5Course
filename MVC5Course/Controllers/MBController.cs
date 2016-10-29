using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models.ViewModels;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        // GET: MB
        public ActionResult Index()
        {
            ViewData["Temp1"] = "暫存資料1";

            var b = new ClientLoginViewModel()
            {
                FirstName = "Allen",
                LastName = "Chen"
            };

            ViewData["Temp2"] = b;
            ViewBag.Temp3 = b;

            return View();
        }

        public ActionResult MyForm()
         {
             return View();
         }
        [HttpPost]
         public ActionResult MyForm(ClientLoginViewModel c)
         {
             if (ModelState.IsValid)
             {
                 TempData["MyFormData"] = c;
                 return RedirectToAction("MyFormResult");
             }
             return View();
         }
 
         public ActionResult MyFormResult()
         {
             return View();
         }

        public ActionResult ProductList()        
        {
            var data = db.Product.OrderBy(p => p.ProductId).Take(10);
            return View(data);
        }

        public ActionResult BatchUpdate(ProductBatchUpdateViewModel[] items)
        {
            if(ModelState.IsValid)
            {
                foreach(var item in items)
                {
                    var product = db.Product.Find(item.ProductId);
                    product.ProductName = item.ProductName;
                    product.Price = item.Price;
                    product.Stock = item.Stock;
                    product.Active = item.Active;

                }

                db.SaveChanges();

                return RedirectToAction("ProductList");
            }            
            return View();
        }

    }
}