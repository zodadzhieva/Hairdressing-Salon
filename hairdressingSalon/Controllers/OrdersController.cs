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
    public class OrdersController : Controller
    {
        private readonly HairdresserContext _context;

        public OrdersController(HairdresserContext context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var hairdresserContext = _context.Orders.Include(o => o.Client).Include(o => o.Product);
            return View(await hairdresserContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdClient,IdProduct,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", order.IdClient);
            ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", order.IdProduct);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            OrderVM model = new OrderVM();
            model.Id = order.Id;
            model.IdProduct = order.IdProduct;
            model.IdClient = order.IdClient;
            model.Quantity = order.Quantity;

            model.Product = _context.Products.Select(pr => new SelectListItem
            {
                Value = pr.Id.ToString(),
                Text = pr.Name,
                Selected = pr.Id == model.IdProduct }).ToList();
        
            //model.Client = _context.Clients.Select(client => new SelectListItem
            //{
            //    Value = client.Id.ToString(),
            //    Text = client.Name,
            //    Selected = client.Id == model.IdClient }).ToList();

           return View(model);  
            //ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", order.IdClient);
            //ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", order.IdProduct);
           
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdClient,IdProduct,Quantity")] OrderVM order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }
            Order modelToDB = await _context.Orders.FindAsync(id);
            if (modelToDB == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return View(modelToDB);
             }

            modelToDB.Id = order.Id;  
            modelToDB.IdProduct = order.IdProduct;
            modelToDB.IdClient = order.IdClient;
            modelToDB.Quantity= order.Quantity;

            try
                {
                    _context.Update(modelToDB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(modelToDB.Id))
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

            //ViewData["IdClient"] = new SelectList(_context.Clients, "Id", "Id", order.IdClient);
            //ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", order.IdProduct);
            //return View(order);
        

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Client)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
