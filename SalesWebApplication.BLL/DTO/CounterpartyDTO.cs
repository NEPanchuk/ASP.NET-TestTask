using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.BLL.DTO
{
    public class CounterpartyDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CityId { get; set; }
    }
}
