using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.BLL.DTO
{
    public class SaleDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CounterpartyId { get; set; }
        public int? ContactOrganizationId { get; set; }
        public int? ContactSaleId { get; set; }
    }
}
