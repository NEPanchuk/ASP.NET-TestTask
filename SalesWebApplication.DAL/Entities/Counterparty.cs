using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.DAL.Entities
{
    public class Counterparty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public ICollection<Sale> Sales { get; set; }
    }
}
