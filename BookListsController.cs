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
    public class BookListsController : ControllerBase
    {
        private readonly BooksContext _context;

        public BookListsController(BooksContext context)
        {
            _context = context;
        }

        // GET: api/BookLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookList>>> GetBookLists()
        {
            return await _context.BookLists.ToListAsync();
        }

        // GET: api/BookLists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookList>> GetBookList(string id)
        {
            var bookList = await _context.BookLists.FindAsync(id);

            if (bookList == null)
            {
                return NotFound();
            }

            return bookList;
        }

        //get: api/BookList/category/one
        [HttpGet("Category/{categoryName}")]
        public async  Task<ActionResult<IEnumerable<BookList>>> GetBookByCategory(string categoryName)
        {
            var bookList = await _context.BookLists.Where(p => p.Category == categoryName).ToListAsync();

            if(bookList == null)
            {
                return NotFound();
            }
            
            return bookList;
        }

        // PUT: api/BookLists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookList(string id, BookList bookList)
        {
            if (id != bookList.Name)
            {
                return BadRequest();
            }

            _context.Entry(bookList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookListExists(id))
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

        // POST: api/BookLists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BookList>> PostBookList(BookList bookList)
        {
            _context.BookLists.Add(bookList);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookListExists(bookList.Name))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetBookList", new { id = bookList.Name }, bookList);
        }

        // DELETE: api/BookLists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookList(string id)
        {
            var bookList = await _context.BookLists.FindAsync(id);
            if (bookList == null)
            {
                return NotFound();
            }

            _context.BookLists.Remove(bookList);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookListExists(string id)
        {
            return _context.BookLists.Any(e => e.Name == id);
        }
    }
}
