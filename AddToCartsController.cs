    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookWebAPI.Models;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddToCartsController : ControllerBase
    {
        private readonly BooksContext _context;

        public AddToCartsController(BooksContext context)
        {
            _context = context;
        }

        // GET: api/AddToCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddToCart>>> GetAddToCarts()
        {
            return await _context.AddToCarts.ToListAsync();
        }

        // GET: api/AddToCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AddToCart>> GetAddToCart(string id)
        {
            var addToCart = await _context.AddToCarts.FindAsync(id);

            if (addToCart == null)
            {
                return NotFound();
            }

            return addToCart;
        }

        // PUT: api/AddToCarts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAddToCart(string id, AddToCart addToCart)
        {
            if (id != addToCart.Name)
            {
                return BadRequest();
            }

            _context.Entry(addToCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AddToCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AddToCarts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AddToCart>> PostAddToCart(AddToCart addToCart)
        {
            _context.AddToCarts.Add(addToCart);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AddToCartExists(addToCart.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAddToCart", new { id = addToCart.Name }, addToCart);
        }

        // DELETE: api/AddToCarts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddToCart(string id)
        {
            var addToCart = await _context.AddToCarts.FindAsync(id);
            if (addToCart == null)
            {
                return NotFound();
            }

            _context.AddToCarts.Remove(addToCart);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AddToCartExists(string id)
        {
            return _context.AddToCarts.Any(e => e.Name == id);
        }
    }
}
