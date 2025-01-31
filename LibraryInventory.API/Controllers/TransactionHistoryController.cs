using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryInventory.API.Controllers
{
    public class TransactionHistoryController : Controller
    {
        // GET: TransactionHistoryController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TransactionHistoryController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TransactionHistoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TransactionHistoryController/Create
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

        // GET: TransactionHistoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TransactionHistoryController/Edit/5
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

        // GET: TransactionHistoryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TransactionHistoryController/Delete/5
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
