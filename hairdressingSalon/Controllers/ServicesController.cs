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
    public class ServicesController : Controller
    {
        private readonly HairdresserContext _context;

        public ServicesController(HairdresserContext context)
        {
            _context = context;
        }

        // GET: Services
        public async Task<IActionResult> Index()
        {
            List<Service> servicesList = await _context.Services.ToListAsync();
            return View(servicesList);
        }

        // GET: Services/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
            if (service == null)
            {
                return NotFound();
            }
            ServiceVM model = new ServiceVM
            {
                Id = service.Id,
                Name = service.Name,
                IdCategory = service.IdCategory,
                Description = service.Description,
                Photo = service.Photo,
                Price = service.Price,
                DateOfEntry = service.DateOfEntry

            };
            return View(service);
        }

       // GET: Services/Create
        public IActionResult Create()
        {
                Service model = new Service();

                return View();
            }

        // POST: Services/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IdCategory,Description,Photo,Price,Data")] Service service)
        {
            if (ModelState.IsValid)
            {
                Service modelToDB = new Service();
                
                    modelToDB.Id = service.Id;
                    modelToDB.Name = service.Name;
                    modelToDB.IdCategory = service.IdCategory;
                    modelToDB.Description = service.Description;
                    modelToDB.Photo = service.Photo;
                    modelToDB.Price = service.Price;
                    modelToDB.DateOfEntry = service.DateOfEntry;

                _context.Add(modelToDB);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ServiceVM model = new ServiceVM();
            model.Categories = _context.Categories.Select(categ=>new SelectListItem
                {
                Value = categ.Id.ToString(),
                Text = categ.Name,
                Selected = categ.Id == model.IdCategory
            }).ToList();
            return View(model);
        }

    // GET: Services/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var service = await _context.Services.FindAsync(id);
        if (service == null)
        {
            return NotFound();
        }

            ServiceVM model = new ServiceVM
            {

                Id = service.Id,
                Name = service.Name,
                IdCategory = service.IdCategory,
                Description = service.Description,
                Photo = service.Photo,
                Price = service.Price,
                DateOfEntry = service.DateOfEntry
            };
            return View(service);
        }
       
        // POST: Services/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Description,Photo,Price,Data")] Service service)
        {
            Service modelToDB = await _context.Services.FindAsync(id);
            if (modelToDB == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(service);
            }

            modelToDB.Id = id;
            modelToDB.Name = service.Name;
            modelToDB.IdCategory = service.IdCategory;
            modelToDB.Description = service.Description;
            modelToDB.Photo = service.Photo;
            modelToDB.Price = service.Price;
            modelToDB.DateOfEntry = service.DateOfEntry;

            try
                {
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(modelToDB.Id))
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
          
        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services
                .FirstOrDefaultAsync(m => m.Id == id);
           
        if (service == null)
            {
                return NotFound();
            }

            return View(service);
        }

        // POST: Services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(int id)
        {
            return _context.Services.Any(e => e.Id == id);
        }
    }
}
