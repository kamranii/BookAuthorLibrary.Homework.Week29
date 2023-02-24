using System;
using BookEFHomeworkWeek29.Entities;

namespace BookEFHomeworkWeek29.Services.Interfaces
{
	public interface IAuthorService
	{
		Task<List<Author>> Get();
		Task<Author> Get(int id);
		Task<Author> Create(Author author);
		Task<bool> Update(int id, Author author);
		Task<bool> Remove(int id);
	}
}

