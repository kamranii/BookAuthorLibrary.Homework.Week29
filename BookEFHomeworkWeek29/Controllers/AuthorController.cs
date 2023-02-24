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
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> Get()
        {
            var authors = await _authorService.Get();
            if (authors == null)
                return NotFound("No author was found");
            return Ok(authors);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            var author = await _authorService.Get(id);
            if (author == null)
                return NotFound("Author doesn't exist");
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<Author>> Post(Author author)
        {
            await _authorService.Create(author);
            return CreatedAtAction(nameof(Get), new { id = author.AthrId }, author);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author author)
        {
            var success = await _authorService.Update(id, author);
            if (!success)
                return BadRequest("Something went wrong");
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _authorService.Remove(id);
            if (!success)
                return BadRequest("Something went wrong");
            return NoContent();

        }
    }
}

