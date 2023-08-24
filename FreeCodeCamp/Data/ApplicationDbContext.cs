using FreeCodeCamp.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FreeCodeCamp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {


        }
        public DbSet<Catagory> Catagories { get; set; } 
    }
}
