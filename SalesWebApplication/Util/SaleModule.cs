using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using SalesWebApplication.BLL.Services;
using SalesWebApplication.BLL.Interfaces;

namespace SalesWebApplication.Util
{
    public class SaleModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ISaleService>().To<SaleService>();
        }
    }
}