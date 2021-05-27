using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HappyBellyApi.Controllers
{
    public class MvcControllerExample : Controller
    {
        // GET: MvcController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MvcController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MvcController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MvcController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MvcController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MvcController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MvcController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MvcController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
