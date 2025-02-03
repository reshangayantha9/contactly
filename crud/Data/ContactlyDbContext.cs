using System.Security.Cryptography.X509Certificates;
using crud.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace crud.Data
{
    public class ContactlyDbContext : DbContext
    {
        public ContactlyDbContext(DbContextOptions options) : base(options)
        {
        
        }
        public DbSet<Contact>contacts { get; set; }
    }
}
