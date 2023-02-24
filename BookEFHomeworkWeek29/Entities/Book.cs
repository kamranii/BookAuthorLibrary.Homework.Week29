using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace BookEFHomeworkWeek29.Entities
{
	[Table("Books")]
	public class Book
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[MaxLength(100, ErrorMessage ="Book name cannot be longer than one hundred characters")]
		public string Name { get; set; }
		//[MinLength(5, ErrorMessage = "Category name cannot be less than 5 symbols long")]
		public string? Category { get; set; }
		[Column("UnitPrice")]
		public float Price { get; set; }
        [ForeignKey("FK_Books_Authors_AuthorId")]
        public int AuthorId { get; set; }

        //navigation properties
        public virtual Author Author { get; set; }
		public virtual Library Library { get; set; }
	}
}

