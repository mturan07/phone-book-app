using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class WebApiDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // TODO: ConnectionString dosyadan getirilecek

            optionsBuilder.UseNpgsql(
                "User ID=postgres;Password=123456;Server=localhost;Port=5432;Database=phonebookdb;" + 
                "Integrated Security=true;Pooling=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Migration sırasında dummy verileri ekliyoruz
            #region ContactData
                System.Guid Guid1 = System.Guid.NewGuid();
                System.Guid Guid2 = System.Guid.NewGuid();
                System.Guid Guid3 = System.Guid.NewGuid();
                System.Guid Guid4 = System.Guid.NewGuid();
                System.Guid Guid5 = System.Guid.NewGuid();

                modelBuilder.Entity<Contact>().HasData(
                    new Contact
                    {
                        ContactId = Guid1, // System.Guid.Parse("ef3271aa-3fd4-4ed1-9109-70ef677f7f89"),
                        FirstName = "Mehmet",
                        LastName = "Sağlam",
                        Company = "Turkcell"                      
                    },
                    new Contact
                    {
                        ContactId = Guid2, // System.Guid.Parse("fbff9a16-520c-4a62-aef3-9411aaadfe64"),
                        FirstName = "Ahmet",
                        LastName = "Atay",
                        Company = "Vodafone"
                    },                    
                    new Contact
                    {
                        ContactId = Guid3, // System.Guid.Parse("752cf042-5ddf-4d58-856c-44cf0cd1a04d"),
                        FirstName = "Hande",
                        LastName = "Güneş",
                        Company = "Turkcell"
                    },
                    new Contact
                    {
                        ContactId = Guid4, // System.Guid.Parse("6a951458-cd4d-449d-aa41-bd41890fa9d7"),
                        FirstName = "Leyla",
                        LastName = "Güzel",
                        Company = "TurkTelekom"
                    },
                    new Contact
                    {
                        ContactId = Guid5, // System.Guid.Parse("846794ec-23c8-49cb-85fb-6a41dcf9fd6c"),
                        FirstName = "Arif",
                        LastName = "Dertsiz",
                        Company = "Turkcell"
                    }
                );
            #endregion

            #region ContactInfoData
            modelBuilder.Entity<ContactInfo>().HasData(
                    // Mehmet Sağlam
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid1,
                        InfoType = "Location",
                        Description = "İstanbul"
                    },
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid1,
                        InfoType = "Phone",
                        Description = "090555445566"
                    },
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid1,
                        InfoType = "Email",
                        Description = "mehmet.saglam@turkcell.com"
                    },
                    // Ahmet Atay
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid2,
                        InfoType = "Location",
                        Description = "Ankara"
                    },
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid2,
                        InfoType = "Phone",
                        Description = "905449998877"
                    },
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid2,
                        InfoType = "Email",
                        Description = "ahmet.atay@vodafone.com"
                    },
                    // Hande Güneş
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid3,
                        InfoType = "Location",
                        Description = "Ankara"
                    },
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid3,
                        InfoType = "Phone",
                        Description = "905438789977"
                    },
                    // Leyla Güzel
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid4,
                        InfoType = "Location",
                        Description = "İzmir"
                    },
                    // Arif Dertsiz
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid5,
                        InfoType = "Email",
                        Description = "arif.dertsiz@turkcell.com"
                    },
                    new ContactInfo
                    {
                        Id = System.Guid.NewGuid(),
                        ContactId = Guid5,
                        InfoType = "Location",
                        Description = "İzmir"
                    }
                );
            #endregion
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Report> Reports { get; set; }

        public DbSet<ReportDetail> ReportDetails { get; set; }
    }
}
