using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;


namespace WebApp.Controllers
{
    public class CategoryController : Controller
    {
        private NorthwindEntities db = new NorthwindEntities();

        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Insert()
        {
            if (Request.Form.Count > 0)
            {
                //接收表單傳過來的資料
                Categories _category = new Categories();
                _category.CategoryName = Request.Form["CategoryName"];
                _category.Description = Request.Form["Description"];

                db.Categories.Add(_category);
                db.SaveChanges();

                return RedirectToAction("Index");
            }


            return View();
        }

        [HttpGet]
        public ActionResult Edit(int id=1)
        {
            return View(db.Categories.Find(id));
        }

        [HttpPost]
        public ActionResult Edit()
        {
            //接收表單傳過來得資料
            Categories _category = db.Categories.Find(Convert.ToInt32(Request.Form["CategoryID"]));
            _category.CategoryName = Request.Form["CategoryName"];
            _category.Description = Request.Form["Description"];

            db.Entry(_category).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id = 0)
        {
           
            Categories _category = db.Categories.Find(id);
            db.Categories.Remove(_category);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

    }
}