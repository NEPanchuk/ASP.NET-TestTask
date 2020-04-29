using SalesWebApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.DAL.EF
{
    public class SaleContext : DbContext
    {
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactOrganization> ContactOrganizations { get; set; }
        public DbSet<ContactSale> ContactSales { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }
        public DbSet<Sale> Sales { get; set; }
        
        static SaleContext()
        {
            Database.SetInitializer<SaleContext>(new SaleDbInitializer());
        }

        public SaleContext(string connectionString) 
            : base(connectionString)
        {
        }
    }

    public class SaleDbInitializer : DropCreateDatabaseIfModelChanges<SaleContext>
    {
        protected override void Seed(SaleContext db)
        {
            var city1 = new City { Name = "Orenburg" };
            db.Cities.Add(city1);
            var city2 = new City { Name = "Tver" };
            db.Cities.Add(city2);

            var counerparty1 = new Counterparty { Name = "Roga i kopita", City = city2 };
            db.Counterparties.Add(counerparty1);
            var counerparty2 = new Counterparty { Name = "Organization", City = city1 };
            db.Counterparties.Add(counerparty2);

            var contactOrganization1 = new ContactOrganization { Name = "Ivanov" };
            db.ContactOrganizations.Add(contactOrganization1);
            var contactOrganization2 = new ContactOrganization { Name = "Petrov" };
            db.ContactOrganizations.Add(contactOrganization2);

            var contactSale1 = new ContactSale { Name = "Sidorov" };
            db.ContactSales.Add(contactSale1);
            var contactSale2 = new ContactSale { Name = "Animov" };
            db.ContactSales.Add(contactSale2);

            var sale1 = new Sale { Name = "Sale1", Counterparty = counerparty1, ContactOrganization = contactOrganization1, ContactSale = contactSale2 };
            db.Sales.Add(sale1);
            var sale2 = new Sale { Name = "Sale2", Counterparty = counerparty1, ContactOrganization = contactOrganization2, ContactSale = contactSale1 };
            db.Sales.Add(sale2);
            var sale3 = new Sale { Name = "Sale3", Counterparty = counerparty2, ContactOrganization = contactOrganization1, ContactSale = contactSale1 };
            db.Sales.Add(sale3);

            

            

            

            db.SaveChanges();
        }
    }
}
