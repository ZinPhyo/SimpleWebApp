using Microsoft.AspNetCore.Mvc;
using SimpleWebApp.Data;
using SimpleWebApp.Models;

namespace SimpleWebApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _repo;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductRepository repo, ILogger<ProductsController> logger)
        {
            _repo = repo;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _repo.GetAllAsync();
            return View(products);
        }

        // GET: /Products/Create
        public IActionResult Create()
        {
            return View(new Product());
        }

        // POST: /Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            await _repo.AddAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /Products/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product product)
        {
            if (!ModelState.IsValid) return View(product);

            await _repo.UpdateAsync(product);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Products/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _repo.GetByIdAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // POST: /Products/DeleteConfirmed/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _repo.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
