using AutoMapper;
using SalesWebApplication.BLL.DTO;
using SalesWebApplication.BLL.Interfaces;
using SalesWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SalesWebApplication.Controllers
{
    public class HomeController : Controller
    {
        ISaleService saleService;
        public HomeController(ISaleService serv)
        {
            saleService = serv;
        }
        public ActionResult Index()
        {
            IEnumerable<SaleInfoDTO> saleDtos = saleService.GetSales();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SaleInfoDTO, SaleViewModel>()).CreateMapper();
            var sales = mapper.Map<IEnumerable<SaleInfoDTO>, List<SaleViewModel>>(saleDtos);
            return View(sales);
        }

        public ActionResult AddNewRow()
        {
            return PartialView("_newRowPartial", new SaleViewModel());
        }


        public JsonResult Create(SaleViewModel model)
        {
            var message = "Требуется ввести название продажи";
            if (!string.IsNullOrEmpty(model.Name))
            {
                SaleViewModel saleDtos = model;
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SaleViewModel, SaleInfoDTO>()).CreateMapper();
                var sales = mapper.Map<SaleViewModel, SaleInfoDTO>(saleDtos);
                saleService.AddSale(sales);

                message = "Успешное добавление";
            }
            return Json(message);
        }

        public JsonResult Update(SaleViewModel model)
        {
            var message = "Требуется ввести название продажи";
            if (!string.IsNullOrEmpty(model.Name))
            {
                SaleViewModel saleDtos = model;
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SaleViewModel, SaleInfoDTO>()).CreateMapper();
                var sales = mapper.Map<SaleViewModel, SaleInfoDTO>(saleDtos);
                saleService.UpdateSale(sales);

                message = "Успешное обновление";
            }
            return Json(message);
        }

        public void Delete(int id)
        {
            saleService.DeleteSale(id);
        }

        protected override void Dispose(bool disposing)
        {
            saleService.Dispose();
            base.Dispose(disposing);
        }
    }
}