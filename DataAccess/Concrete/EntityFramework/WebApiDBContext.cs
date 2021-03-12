using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class WebApiDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=phonebookdb;" + 
                "Integrated Security=true;Pooling=true;");
        }
        
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
