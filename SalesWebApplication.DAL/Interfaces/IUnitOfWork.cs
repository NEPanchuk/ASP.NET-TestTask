using SalesWebApplication.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<City> Cities { get; }
        IRepository<ContactOrganization> ContactOrganizations { get; }
        IRepository<ContactSale> ContactSales { get; }
        IRepository<Counterparty> Counterparties { get; }
        IRepository<Sale> Sales { get; }

        void Save();
    }
}
