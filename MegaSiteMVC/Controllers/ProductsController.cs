using MegaSiteMVC.Data;
using MegaSiteMVC.Data.Services;
using MegaSiteMVC.Data.Static;
using MegaSiteMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace MegaSiteMVC.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
	{
		private readonly IProductsService _service;

		public ProductsController(IProductsService service)
		{
            _service = service;
		}

        [AllowAnonymous]
        public async Task<IActionResult> Index()
		{
			var data = await _service.GetAllAsync();
			return View(data);
		}

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var products = await _service.GetAllAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filter = products.Where(n => n.Name!.ToLower().Contains(searchString.ToLower()) || n.Description!.ToLower().Contains(searchString.ToLower()));
                products = filter != null? await filter.ToAsyncEnumerable().ToListAsync() : products;
            }

            return View("Index", products);
        }

        public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("ImageURL,Name,Description,Price")]Product product)
		{
			if (!ModelState.IsValid)
			{
				return View(product);
			}
			await _service.AddAsync(product);
			return RedirectToAction(nameof(Index));
		}

        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
		{
			var product = await _service.GetProductByIdAsync(id);
			return product == null? View("NotFound") : View(product);
		}

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            return product == null ? View("NotFound") : View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ImageURL,Name,Description,Price")] Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(id, product);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.GetProductByIdAsync(id);
            return product == null ? View("NotFound") : View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
			var product = await _service.GetProductByIdAsync(id);
			if (product == null)
				return View("NotFound");
			await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
