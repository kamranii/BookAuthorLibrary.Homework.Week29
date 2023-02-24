using System;
using BookEFHomeworkWeek29.Entities;

namespace BookEFHomeworkWeek29.Services.Interfaces
{
	public interface IBookService
	{
		Task<List<Book>> Get();
		Task<Book> Get(int id);
	}
}

