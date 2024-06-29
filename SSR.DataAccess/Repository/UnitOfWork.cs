using SSR.DataAccess.Data;
using SSR.DataAccess.Repository.IRepository;
using SSR.Models;
using SSR.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSR.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public IMenuItemsRepository MenuItems { get; private set; }
        public IDishRepository Dish { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }




        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            MenuItems = new MenuItemsRepository(_db);
            Dish = new DishRepository(_db);
            ShoppingCart = new ShoppingCartRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
            OrderHeader = new OrderHeaderRepository(_db);
            OrderDetail = new OrderDetailRepository(_db);


        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
