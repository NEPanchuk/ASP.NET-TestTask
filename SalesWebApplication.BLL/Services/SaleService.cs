using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SalesWebApplication.BLL.DTO;
using SalesWebApplication.BLL.Interfaces;
using SalesWebApplication.DAL.Entities;
using SalesWebApplication.DAL.Interfaces;

namespace SalesWebApplication.BLL.Services
{
    public class SaleService : ISaleService
    {
        IUnitOfWork Database { get; set; }

        public SaleService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public IEnumerable<SaleInfoDTO> GetSales()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Sale, SaleInfoDTO>()
            .ForMember("CityName", opt => opt.MapFrom(c => c.Counterparty.City.Name))).CreateMapper();
            return mapper.Map<IEnumerable<Sale>, List<SaleInfoDTO>>(Database.Sales.GetAll());
        }
        public void AddSale(SaleInfoDTO saleInfo)
        {
            City city = new City { Name = saleInfo.CityName };
            Database.Cities.Create(city);

            Counterparty counterparty = new Counterparty { Name = saleInfo.CounterpartyName, City = city };
            Database.Counterparties.Create(counterparty);

            ContactOrganization contactOrganization = new ContactOrganization { Name = saleInfo.ContactOrganizationName };
            Database.ContactOrganizations.Create(contactOrganization);

            ContactSale contactSale = new ContactSale { Name = saleInfo.ContactSaleName };
            Database.ContactSales.Create(contactSale);

            Sale sale = new Sale { Name = saleInfo.Name, Counterparty = counterparty, ContactOrganization = contactOrganization, ContactSale = contactSale};
            Database.Sales.Create(sale);

            Database.Save();
        }

        public void UpdateSale(SaleInfoDTO saleInfo)
        {
            var sale = Database.Sales.Get(saleInfo.Id);

            City city = new City { Name = saleInfo.CityName };
            Database.Cities.Create(city);

            Counterparty counterparty = new Counterparty { Name = saleInfo.CounterpartyName, City = city };
            Database.Counterparties.Create(counterparty);

            ContactOrganization contactOrganization = new ContactOrganization { Name = saleInfo.ContactOrganizationName };
            Database.ContactOrganizations.Create(contactOrganization);

            ContactSale contactSale = new ContactSale { Name = saleInfo.ContactSaleName };
            Database.ContactSales.Create(contactSale);

            sale.Name = saleInfo.Name;
            sale.Counterparty = counterparty;
            sale.ContactOrganization = contactOrganization;
            sale.ContactSale = contactSale;
            Database.Sales.Update(sale);

            Database.Save();
        }

        public void DeleteSale(int id)
        {
            Database.Sales.Delete(id);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
