using System;
using BookEFHomeworkWeek29.Entities;
using BookEFHomeworkWeek29.MyContext;
using BookEFHomeworkWeek29.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
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
            _dB.Entry(author).State = EntityState.Detached;
            return author;
        }

        public async Task<Author> Create(Author author)
        {
            await _dB.Authors.AddAsync(author);
            await _dB.SaveChangesAsync();
            return author;
        }
        public async Task<bool> Update(int id, Author author)
        {
            if (id != author.AthrId)
                return false;
            _dB.Entry(author).State = EntityState.Modified;
            try
            {
                await _dB.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                    return false;
                else
                    throw;
            }
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            if (_dB.Authors == null)
                return false;
            var author = await _dB.Authors.FindAsync(id);
            if (author == null)
                return false;
            _dB.Authors.Remove(author);
            await _dB.SaveChangesAsync();
            return true;
        }

        private bool AuthorExists(int id)
        {
            return (_dB.Authors?.Any(a => a.AthrId == id)).GetValueOrDefault();
        }

    }
}

