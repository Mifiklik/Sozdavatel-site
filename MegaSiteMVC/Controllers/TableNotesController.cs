using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegaSiteMVC.Controllers
{
	public class TableNotesController : Controller
	{
		// GET: TableNotesController
		public ActionResult Index()
		{
			return View();
		}

		// GET: TableNotesController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: TableNotesController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: TableNotesController/Create
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

		// GET: TableNotesController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: TableNotesController/Edit/5
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

		// GET: TableNotesController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: TableNotesController/Delete/5
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
