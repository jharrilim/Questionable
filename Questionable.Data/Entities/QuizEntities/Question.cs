using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionable.Data.Entities.QuizEntities
{
	public class Question
    {
		[Key]
		public int Id { get; set; }

		public string Text { get; set; }

		public List<Answer> Answers { get; set; }
	}
}
