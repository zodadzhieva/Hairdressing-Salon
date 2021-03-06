using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hairdressingSalon.Data;
using hairdressingSalon.Models;

namespace hairdressingSalon.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HairdresserContext _context;

        public ProductsController(HairdresserContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            List<Product> productsList = await _context.Products.ToListAsync();
            return View(productsList);            
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ProductVM model = new ProductVM
            {
               
                Name=product.Name,
                IdCategory = product.IdCategory,
                Manufacture = product.Manufacture,
                Description = product.Description,
                Price = product.Price,
                DateOfEntryy = product.DateOfEntryy
            };

            return View(model);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ProductVM model = new ProductVM();
            return View(model); 
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, [Bind("Id,Name,IdCategory,Manufacture,Description,Price,Data")] ProductVM product)
        {
            if (ModelState.IsValid)
            {
                Product modelToDB = new Product(); 
                                                  
                modelToDB.Name = product.Name;
                modelToDB.IdCategory = product.IdCategory;
                modelToDB.Manufacture = product.Manufacture;
                modelToDB.Description = product.Description;
                modelToDB.Price = product.Price;
                modelToDB.DateOfEntryy = DateTime.Now; 

                _context.Add(modelToDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ProductVM model = new ProductVM();
            model.Categories = _context.Categories.Select(cat => new SelectListItem
            {
                Value = cat.Id.ToString(),
                Text = cat.Name,
                Selected = cat.Id == model.IdCategory
            }).ToList();
            return View(model);
        }
        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            ProductVM model = new ProductVM
            {
                Id = product.Id,
                Name = product.Name,
                IdCategory = product.IdCategory,
                Manufacture = product.Manufacture,
                Description = product.Description,
                Price = product.Price,
                DateOfEntryy = product.DateOfEntryy
            }; 
            return View(model);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IdCategory,Manufactute,Description,Price,DateOfEntryy")] ProductVM product)
        {
            Product modelToDB = await _context.Products.FindAsync(id);
            if (modelToDB == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {        
                return View(product);
            }

            modelToDB.Id = product.Id;
            modelToDB.Name = product.Name;
            modelToDB.IdCategory = product.IdCategory;
            modelToDB.Manufacture = product.Manufacture;
            modelToDB.Description = product.Description;
            modelToDB.Price = product.Price;
            modelToDB.DateOfEntryy = product.DateOfEntryy;

            try
            {
                _context.Update(modelToDB);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(modelToDB.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction("Details", new { id = id });
        }

        // GET: Hairdressers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        // GET: Products/Delete/5

        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
            .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
