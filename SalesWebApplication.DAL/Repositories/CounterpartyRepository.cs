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
    public class CounterpartyRepository : IRepository<Counterparty>
    {
        private SaleContext db;

        public CounterpartyRepository(SaleContext context)
        {
            this.db = context;
        }

        public IEnumerable<Counterparty> GetAll()
        {
            return db.Counterparties.Include(o => o.City);
        }

        public Counterparty Get(int id)
        {
            return db.Counterparties.Find(id);
        }

        public void Create(Counterparty counterparty)
        {
            db.Counterparties.Add(counterparty);
        }

        public void Update(Counterparty counterparty)
        {
            db.Entry(counterparty).State = EntityState.Modified;
        }
        public IEnumerable<Counterparty> Find(Func<Counterparty, Boolean> predicate)
        {
            return db.Counterparties.Include(o => o.City).Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Counterparty counterparty = db.Counterparties.Find(id);
            if (counterparty != null)
                db.Counterparties.Remove(counterparty);
        }
    }
}
