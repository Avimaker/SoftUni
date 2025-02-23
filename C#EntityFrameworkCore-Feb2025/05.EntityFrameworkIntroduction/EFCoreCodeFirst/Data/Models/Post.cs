using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCodeFirst.Data.Models
{

	[Comment("Articles posted on my blog")]

	public class Post
	{
		[Key]
		[Comment("Record indetifier")]

		public int Id { get; set; }

		[Required]
		[MaxLength(100)]
		[Comment("Article title")]

		public string Title { get; set; } = null!;

		[Required]
		[Comment("Article content")]

		public string Content { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        [Comment("Article author")]

        public string Author { get; set; } = null!;
    }
}

