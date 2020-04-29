using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.DAL.Entities
{
    public class Sale
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CounterpartyId { get; set; }
        public Counterparty Counterparty { get; set; }

        public int? ContactOrganizationId { get; set; }
        public ContactOrganization ContactOrganization { get; set; }

        public int? ContactSaleId { get; set; }
        public ContactSale ContactSale { get; set; }
    }
}
