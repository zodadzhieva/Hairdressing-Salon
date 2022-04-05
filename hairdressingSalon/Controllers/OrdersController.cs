using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using hairdressingSalon.Data;
using Microsoft.AspNetCore.Identity;
using hairdressingSalon.Models;
using Microsoft.AspNetCore.Authorization;

namespace hairdressingSalon.Controllers
{
    public class OrdersController : Controller
    {
        private readonly HairdresserContext _context;
        private readonly UserManager<Client> _userManager;


        public OrdersController(HairdresserContext context, UserManager<Client> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var HairdresserContext = _context.Orders
               .Include(o => o.Product)
               .Include(u => u.Client);

            return View(await HairdresserContext.ToListAsync());
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
        [Authorize(Roles = "User,Admin")]
        public IActionResult Create()
        {
            OrderVM model = new OrderVM();
            model.IdClient = _userManager.GetUserId(User);
            model.Product = _context.Products.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = x.Id == model.IdProduct
            }).ToList();


            //ViewData["IdClient"] = new SelectList(_context.Users, "Id", "Name");
            //ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "FullName");
            return View(model);
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("Id,IdClient,IdProduct,Quantity")] Order order)
        {
            if (ModelState.IsValid)
            {
                order.IdClient = _userManager.GetUserId(User);
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            OrderVM model = new OrderVM();
            model.Product = _context.Products.Select(pr => new SelectListItem
            {
                Value = pr.Id.ToString(),
                Text = pr.Name,
                Selected = pr.Id == model.IdProduct
            }).ToList();

            //ViewData["IdClient"] = new SelectList(_context.Users, "Id", "Id", order.IdClient);
            //ViewData["IdProduct"] = new SelectList(_context.Products, "Id", "Id", order.IdProduct);
            return View(model);
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
            model.IdClient = order.IdClient;
            model.IdProduct = order.IdProduct;
            model.Quantity = order.Quantity;

            model.Product = _context.Products.Select(pr => new SelectListItem
            {
                Value = pr.Id.ToString(),
                Text = pr.Name,
                Selected = pr.Id == model.IdProduct
            }).ToList();

            return View(model);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdClient,IdProduct,Quantity")] OrderVM order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            Order modelToDB = await _context.Orders.FindAsync(id);
            if (modelToDB == null)
            {
                return NotFound();
            }
            modelToDB.Id = order.Id;
            // modelToDB.IdClient = order.IdClient;
            modelToDB.IdProduct = order.IdProduct;
            modelToDB.Quantity = order.Quantity;
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
