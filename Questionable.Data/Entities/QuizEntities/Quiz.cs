using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionable.Data.Entities.QuizEntities
{
	public class Quiz
    {
		[Key]
		public int Id { get; set; }

		public string Name { get; set; }

		public DateTime DateCreated { get; set; }

		public string Creator { get; set; }

		public List<Question> Questions { get; set; }
    }
}
