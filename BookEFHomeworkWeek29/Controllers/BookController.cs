using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookEFHomeworkWeek29.Entities;
using BookEFHomeworkWeek29.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookEFHomeworkWeek29.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
            var books = await _bookService.Get();
            if (books == null)
                return NotFound("No book was found");
            return Ok(books);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            var book = await _bookService.Get(id);
            if (book == null)
                return NotFound("Book doesn't exist");
            return Ok(book);
        }
    }
}

