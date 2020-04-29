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
    public class SaleRepository : IRepository<Sale>
    {
        private SaleContext db;

        public SaleRepository(SaleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Sale> GetAll()
        {
            return db.Sales.Include(o => o.Counterparty)
                .Include(o => o.ContactOrganization)
                .Include(o => o.ContactSale)
                .Include("Counterparty.City");
        }

        public Sale Get(int id)
        {
            return db.Sales.Find(id);
        }

        public void Create(Sale sale)
        {
            db.Sales.Add(sale);
        }

        public void Update(Sale sale)
        {
            db.Entry(sale).State = EntityState.Modified;
        }
        public IEnumerable<Sale> Find(Func<Sale, Boolean> predicate)
        {
            return db.Sales
                .Include(o => o.Counterparty)
                .Include(o => o.ContactOrganization)
                .Include(o => o.ContactSale)
                .Include("Counterparty.City")
                .Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Sale sale = db.Sales.Find(id);
            if (sale != null)
                db.Sales.Remove(sale);
        }
    }
}
