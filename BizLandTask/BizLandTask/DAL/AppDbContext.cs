using BizLandTask.Models;
using Microsoft.EntityFrameworkCore;

namespace BizLandTask.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Employee> Employees { get; set; }
    }
}
