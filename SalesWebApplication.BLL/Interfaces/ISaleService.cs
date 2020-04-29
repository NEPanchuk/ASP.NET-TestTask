using SalesWebApplication.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.BLL.Interfaces
{
    public interface ISaleService
    {
        IEnumerable<SaleInfoDTO> GetSales();
        void Dispose();
        void AddSale(SaleInfoDTO saleInfo);
        void DeleteSale(int id);
        void UpdateSale(SaleInfoDTO saleInfo);
    }
}
