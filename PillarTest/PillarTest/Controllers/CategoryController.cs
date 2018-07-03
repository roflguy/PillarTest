using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PillarTest.Models;

namespace PillarTest.Controllers
{
    public class CategoryController : Controller
    {
        private readonly NotificationContext _context;

        public CategoryController(NotificationContext context)
        {
            _context = context;
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _context.Categories.FirstOrDefault(c => c.Id == id);

            return View(entity);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            try
            {
                var entity = _context.Categories.FirstOrDefault(c => c.Id == id);
                entity.Name = category.Name;

                _context.Update(entity);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _context.Categories.FirstOrDefault(c => c.Id == id);

            return View(entity);
        }

        // POST: Category/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                var entity = _context.Categories.FirstOrDefault(c => c.Id == id);

                _context.Categories.Remove(entity);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}