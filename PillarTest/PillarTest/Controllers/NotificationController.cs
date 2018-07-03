using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PillarTest.Models;

namespace PillarTest.Controllers
{
    public class NotificationController : Controller
    {
        private readonly NotificationContext _context;

        public NotificationController(NotificationContext context)
        {
            _context = context;
        }

        // GET: Notification
        public ActionResult Index()
        {
            var notifications = _context.Notifications
                .Include(n => n.Category)
                .ToList();

            return View(notifications);
        }

        // GET: Notification/Create
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();

            ViewBag.Categories = categories;

            return View();
        }

        // POST: Notification/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Notification notification)
        {
            try
            {
                _context.Notifications.Add(notification);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _context.Notifications
                .Include(n => n.Category)
                .FirstOrDefault(c => c.Id == id);

            var categories = _context.Categories.ToList();

            ViewBag.Categories = categories;

            return View(entity);
        }

        // POST: Notification/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Notification notification)
        {
            try
            {
                var entity = _context.Notifications
                    .Include(n => n.Category)
                    .FirstOrDefault(c => c.Id == id);

                entity.Text = notification.Text;
                entity.Created = notification.Created;
                entity.Expired = notification.Expired;
                entity.CategoryId = notification.CategoryId;

                _context.Notifications.Update(entity);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Notification/Delete/5
        public ActionResult Delete(int id)
        {
            var entity = _context.Notifications
                .Include(n => n.Category)
                .FirstOrDefault(c => c.Id == id);

            return View(entity);
        }

        // POST: Notification/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Notification collection)
        {
            try
            {
                var entity = _context.Notifications
                    .FirstOrDefault(c => c.Id == id);

                _context.Remove(entity);
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