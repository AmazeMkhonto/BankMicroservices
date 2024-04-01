using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Bank.Service.Auth.Models;

namespace Bank.Service.Auth.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}

		public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

		}
	}
}
