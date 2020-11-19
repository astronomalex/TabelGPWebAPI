using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TabelGPWebAPI.Controllers
{
    [ApiController]
    [Route("[Norms]")]
    public class NormsController : Controller
    {
        // GET: NormsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: NormsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NormsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NormsController/Create
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

        // GET: NormsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NormsController/Edit/5
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

        // GET: NormsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NormsController/Delete/5
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
