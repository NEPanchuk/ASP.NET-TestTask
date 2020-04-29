using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SalesWebApplication.Models
{
    public class SaleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название продажи")]
        public string Name { get; set; }
        [Display(Name = "Клиент-организация")]
        public string CounterpartyName { get; set; }
        [Display(Name = "Контактное лицо от организации")]
        public string ContactOrganizationName { get; set; }
        [Display(Name = "Ответственный за продажу")]
        public string ContactSaleName { get; set; }
        [Display(Name = "Город клиента-организации")]
        public string CityName { get; set; }
    }
}