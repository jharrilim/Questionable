using Questionable.Data.Entities.QuizEntities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionable.ViewModels
{
	public class CreateQuizViewModel
    {
		[Required, Display(Name = "Quiz Name")]
		public string Name { get; set; }

		[Required, Display(Name= "Your Name")]
		public string Creator { get; set; }

		[MinLength(1)]
		public List<Question> Questions { get; set; }
    }
}
