using SSR.DataAccess.Data;
using SSR.DataAccess.Repository.IRepository;
using SSR.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSR.DataAccess.Repository
{
    public class DishRepository : Repository<Dish>, IDishRepository 
    {
        private ApplicationDbContext _db;
        public DishRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Dish obj)
        {
            var objFromDb = _db.Dishes.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            { 
                objFromDb.Name = obj.Name;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.MenuId = obj.MenuId;
                
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
            }
            
        }
    }
}
