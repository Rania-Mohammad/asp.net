using Microsoft.EntityFrameworkCore;
using projectF.Models;

namespace projectF.Data
{
	public class ApplicationDBcontext: DbContext
	{
		public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options) { }
		public DbSet<Employee> Employees { get; set; }
		public DbSet<client> clients { get; set; }
		public DbSet<operations> operations { get; set; }
		public DbSet<finance> finances { get; set; }
		public DbSet<History> history { get; set; }
		public DbSet<to_do_list> to_do_list { get; set; }
		public DbSet<login> login { get; set; }
	}
}
