using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webApi.Models;
using webApi.Repositories;

namespace webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _context;
        public BooksController(RepositoryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            try
            {
                var books = await _context.Books.ToListAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Veritabanı hatası: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneBook(int id)
        {
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book == null)
                {
                    return NotFound($"ID'si {id} olan kitap bulunamadı.");
                }
                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Veritabanı hatası: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateOneBook([FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // Ensure Id is not set for new books
                book.Id = 0;

                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();
                return StatusCode(201, book);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, $"Veritabanı güncelleme hatası: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Beklenmeyen bir hata oluştu: {ex.Message}");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOneBook(int id, [FromBody] Book book)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var existingBook = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (existingBook == null)
                {
                    return NotFound($"ID'si {id} olan kitap bulunamadı.");
                }

                existingBook.Title = book.Title;
                existingBook.Price = book.Price;
                await _context.SaveChangesAsync();

                return Ok(existingBook);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Veritabanı hatası: {ex.Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOneBook(int id)
        {
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
                if (book == null)
                {
                    return NotFound($"ID'si {id} olan kitap bulunamadı.");
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Veritabanı hatası: {ex.Message}");
            }
        }
    }
}