using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.BLL.DTO
{
    public class SaleInfoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string CounterpartyName { get; set; }
        public string ContactOrganizationName { get; set; }
        public string ContactSaleName { get; set; }

        public string CityName { get; set; }
    }
}
