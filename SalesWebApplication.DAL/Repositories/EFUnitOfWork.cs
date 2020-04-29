using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SalesWebApplication.DAL.Interfaces;
using SalesWebApplication.DAL.EF;
using SalesWebApplication.DAL.Entities;

namespace SalesWebApplication.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private SaleContext db;
        private CityRepository cityRepository;
        private ContactOrganizationRepository contactOrganizationRepository;
        private ContactSaleRepository contactSaleRepository;
        private CounterpartyRepository counterpartyRepository;
        private SaleRepository saleRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new SaleContext(connectionString);
        }

        public IRepository<City> Cities
        {
            get
            {
                if (cityRepository == null)
                    cityRepository = new CityRepository(db);
                return cityRepository;
            }
        }

        public IRepository<ContactOrganization> ContactOrganizations
        {
            get
            {
                if (contactOrganizationRepository == null)
                    contactOrganizationRepository = new ContactOrganizationRepository(db);
                return contactOrganizationRepository;
            }
        }

        public IRepository<ContactSale> ContactSales
        {
            get
            {
                if (contactSaleRepository == null)
                    contactSaleRepository = new ContactSaleRepository(db);
                return contactSaleRepository;
            }
        }

        public IRepository<Counterparty> Counterparties
        {
            get
            {
                if (counterpartyRepository == null)
                    counterpartyRepository = new CounterpartyRepository(db);
                return counterpartyRepository;
            }
        }

        public IRepository<Sale> Sales
        {
            get
            {
                if (saleRepository == null)
                    saleRepository = new SaleRepository(db);
                return saleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
