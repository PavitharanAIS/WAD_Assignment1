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
    public class MenuItemsRepository : Repository<MenuItems>, IMenuItemsRepository 
    {
        private ApplicationDbContext _db;
        public MenuItemsRepository(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(MenuItems obj)
        {
            _db.Menu.Update(obj);
        }
    }
}
