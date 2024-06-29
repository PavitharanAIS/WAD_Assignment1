using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSR.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMenuItemsRepository MenuItems { get; }
        IDishRepository Dish { get; }
        IShoppingCartRepository ShoppingCart { get; }
        IApplicationUserRepository ApplicationUser { get; }
        IOrderDetailRepository OrderDetail { get; }
        IOrderHeaderRepository OrderHeader { get; }



        void Save();
    }
}
