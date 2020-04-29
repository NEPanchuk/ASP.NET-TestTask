using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesWebApplication.DAL.EF;
using SalesWebApplication.DAL.Entities;
using SalesWebApplication.DAL.Interfaces;
using System.Data.Entity;

namespace SalesWebApplication.DAL.Repositories
{
    public class ContactSaleRepository : IRepository<ContactSale>
    {
        private SaleContext db;

        public ContactSaleRepository(SaleContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContactSale> GetAll()
        {
            return db.ContactSales;
        }

        public ContactSale Get(int id)
        {
            return db.ContactSales.Find(id);
        }

        public void Create(ContactSale contactSale)
        {
            db.ContactSales.Add(contactSale);
        }

        public void Update(ContactSale contactSale)
        {
            db.Entry(contactSale).State = EntityState.Modified;
        }

        public IEnumerable<ContactSale> Find(Func<ContactSale, Boolean> predicate)
        {
            return db.ContactSales.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ContactSale contactSale = db.ContactSales.Find(id);
            if (contactSale != null)
                db.ContactSales.Remove(contactSale);
        }
    }
}
