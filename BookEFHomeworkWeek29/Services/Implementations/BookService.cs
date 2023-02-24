using System;
using BookEFHomeworkWeek29.Entities;
using BookEFHomeworkWeek29.MyContext;
using BookEFHomeworkWeek29.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookEFHomeworkWeek29.Services.Implementations
{
	public class BookService: IBookService
	{
        private readonly ApplicationDbContext _dB;
		public BookService(ApplicationDbContext dB)
		{
            _dB = dB;
		}

        public async Task<List<Book>> Get()
        {
            var books = await _dB.Books.ToListAsync();
            return books;
        }

        public async Task<Book> Get(int id)
        {
            var book = await _dB.Books.FirstOrDefaultAsync(b => b.Id == id);
            return book;
        }
    }
}

