using SalesWebApplication.DAL.EF;
using SalesWebApplication.DAL.Entities;
using SalesWebApplication.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesWebApplication.DAL.Repositories
{
    public class CityRepository : IRepository<City>
    {
        private SaleContext db;

        public CityRepository(SaleContext context)
        {
            this.db = context;
        }

        public IEnumerable<City> GetAll()
        {
            return db.Cities;
        }

        public City Get(int id)
        {
            return db.Cities.Find(id);
        }

        public void Create(City city)
        {
            db.Cities.Add(city);
        }

        public void Update(City city)
        {
            db.Entry(city).State = EntityState.Modified;
        }

        public IEnumerable<City> Find(Func<City, Boolean> predicate)
        {
            return db.Cities.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            City city = db.Cities.Find(id);
            if (city != null)
                db.Cities.Remove(city);
        }
    }
}
