using Microsoft.EntityFrameworkCore;
using MT_Data.Entities;

namespace MT_Data.Context;
public sealed class ApplicationDbContext : DbContext
{
   public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
   {

   }
   public DbSet<Employee> employees { get; set; }
}
