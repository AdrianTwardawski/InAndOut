using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ExpenseTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ExpenseType> objList = _db.ExpensesTypes;     
            return View(objList);
        }

        [HttpGet]
        public IActionResult Create(ExpenseType expenseType)
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePost(ExpenseType expenseType)
        {
            if (ModelState.IsValid)
            {
                _db.Add(expenseType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(expenseType);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == 0 || id == null)
            {
                return NoContent();
            }
            var obj = _db.ExpensesTypes.Find(id);
            if(obj == null)
            {
                return NotFound();
            }       
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {           
            var obj = _db.ExpensesTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.ExpensesTypes.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == 0 || id == null)
            {
                return NoContent();
            }
            var obj = _db.ExpensesTypes.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePost(ExpenseType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ExpensesTypes.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}

