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
    public class ContactOrganizationRepository : IRepository <ContactOrganization>
    {
        private SaleContext db;

        public ContactOrganizationRepository(SaleContext context)
        {
            this.db = context;
        }

        public IEnumerable<ContactOrganization> GetAll()
        {
            return db.ContactOrganizations;
        }

        public ContactOrganization Get(int id)
        {
            return db.ContactOrganizations.Find(id);
        }

        public void Create(ContactOrganization contactOrganization)
        {
            db.ContactOrganizations.Add(contactOrganization);
        }

        public void Update(ContactOrganization contactOrganization)
        {
            db.Entry(contactOrganization).State = EntityState.Modified;
        }

        public IEnumerable<ContactOrganization> Find(Func<ContactOrganization, Boolean> predicate)
        {
            return db.ContactOrganizations.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            ContactOrganization contactOrganization = db.ContactOrganizations.Find(id);
            if (contactOrganization != null)
                db.ContactOrganizations.Remove(contactOrganization);
        }
    }
}
