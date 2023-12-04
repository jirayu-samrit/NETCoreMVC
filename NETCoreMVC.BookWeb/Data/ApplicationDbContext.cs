using Microsoft.EntityFrameworkCore;
using NETCoreMVC.BookWeb.Models;

namespace NETCoreMVC.BookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { get; set; }
    }
}
