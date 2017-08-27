using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Questionable.Data.Entities;
using Questionable.Data.Entities.QuizEntities;

namespace Questionable.Data.Context
{
	public class QuestionableDbContext : IdentityDbContext<User>
	{
		public DbSet<Quiz> Quizes { get; set; }

		public DbSet<Question> Questions { get; set; }

		public DbSet<Answer> Answers { get; set; }

		public QuestionableDbContext(DbContextOptions options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Answer>()
				.HasKey(ans => new { ans.Id, ans.QuestionId });
		}
	}
}
