using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookEFHomeworkWeek29.Entities
{
	[Table("Authors")]
	public class Author
	{
		[Key]
		public int AthrId { get; set; }
		//[Required]
		[MaxLength(60,ErrorMessage = "Pleas shorten the name")]
		public string Name { get; set; }
		[Required(AllowEmptyStrings = true)]
		public string Surname { get; set; }
		[Column("BirthDate")]
		public DateTime Birth { get; set; }
		[NotMapped]
		public string? Nationality { get; set; }

		//nav props
		public virtual ICollection<Book>? Books { get; set; }
	}
}

