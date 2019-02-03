using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoNow.Models;

namespace ToDoNow.Controllers
{
    public class HomeController : Controller
    {
        ToDoNowDb _db = new ToDoNowDb();

        public ActionResult Index()
        {
            var model = _db.Todos.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string Title, string Body)
        {
            var model = _db.Todos.Add(
                new Todo {Title = Title, Body = Body, Completed = false }
                );

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Edit(int id)
        {
            var model = _db.Todos.First(t => t.Id == id);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Todo todo)
        {
            var todoToUpdate = _db.Todos.First(t => t.Id == todo.Id);

            todoToUpdate.Title = todo.Title;
            todoToUpdate.Body = todo.Body;
            todoToUpdate.Completed = todo.Completed;

            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Delete(int id)
        {

            var todo = _db.Todos.First(t => t.Id == id);
            _db.Todos.Remove(todo);
            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}