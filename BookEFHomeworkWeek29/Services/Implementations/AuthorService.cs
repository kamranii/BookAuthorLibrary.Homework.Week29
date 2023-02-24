using System;
using BookEFHomeworkWeek29.Entities;
using BookEFHomeworkWeek29.MyContext;
using BookEFHomeworkWeek29.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookEFHomeworkWeek29.Services.Implementations
{
	public class AuthorService: IAuthorService
	{
        private readonly ApplicationDbContext _dB;
        public AuthorService(ApplicationDbContext dB)
		{
            _dB = dB;
        }

        public async Task<List<Author>> Get()
        {
            var authors = await _dB.Authors.ToListAsync();
            return authors;
        }

        public async Task<Author> Get(int id)
        {
            var author = await _dB.Authors.FirstOrDefaultAsync(a => a.AthrId == id);
            return author;
        }
    }
}

