using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Questionable.Data.Entities.QuizEntities
{
	public class Answer
    {
		[Key]
		public int Id { get; set; }

		public int QuestionId { get; set; }

		public string Text { get; set; }

		public bool IsCorrect { get; set; }
    }
}
