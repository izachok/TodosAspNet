
using Microsoft.EntityFrameworkCore;
using TodosWeb.Models;

namespace TodosWeb.Data
{
		public class ApplicationDbContext : DbContext
		{
				public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
				{

				}

				public DbSet<Todo> Todos { get; set; }
		}
}
