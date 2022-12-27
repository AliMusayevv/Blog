using Blog.Models.EntityFrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        LoginPageEntities2 DB=new LoginPageEntities2(); 
        public ActionResult Index()
        {
           
          return View();    
        }
        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Experience()
        {
            return View();
        }
        
        public ActionResult ToDoList()
        {
            var model = DB.ToDoLists.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult AddNew()
        {
            return View();
        }
      
        
        [HttpPost]
        public ActionResult AddNew(ToDoList ls)
        {
            if (ls.ID == 0) // Insert ucun
            {
                DB.ToDoLists.Add(ls);
                DB.SaveChanges();
            }
            else
            {
                var updateData = DB.ToDoLists.Find(ls.ID);
                if (updateData == null)
                {
                    return HttpNotFound();
                }
                updateData.MONTH = ls.MONTH;
                updateData.DAY = ls.DAY;
                updateData.AFTER_WAKE_UP = ls.AFTER_WAKE_UP;
                updateData.AT_UNIVERSITY = ls.AT_UNIVERSITY;
                updateData.AFTER_LESSON_END = ls.AFTER_LESSON_END;
                updateData.AT_NIGHT = ls.AT_NIGHT;
                updateData.NOT_IN_PLAN = ls.NOT_IN_PLAN;

            DB.SaveChanges();
            }
            return RedirectToAction("ToDoList", "Home");
        }

        public ActionResult Update(int id)
        {
            var model = DB.ToDoLists.Find(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View("AddNew", model);
        }

        public ActionResult Delete(int id)
        {
            var delete = DB.ToDoLists.Find(id);
            if (delete == null)
            {

                return HttpNotFound();
            }
            DB.ToDoLists.Remove(delete);
            DB.SaveChanges();
            return RedirectToAction("ToDoList", "Home");
        }
    }
}