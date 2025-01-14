using LMS_Backend.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace LMS_Backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
    }

    }
