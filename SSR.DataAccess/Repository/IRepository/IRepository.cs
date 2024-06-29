using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SSR.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class //T means a Generic class. It can be any class name that is being called. It inherits the data object from that class.
    {
        //T - MenuItem
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeDishes = null); //Get All the data from the db. 
        T Get(Expression<Func<T, bool>> filter, string? includeDishes = null, bool tracked = false); // Filter and Get one single menu item from the db along with the included foreign key dieshes.
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity); // Delete multiple entities from a sinfle column. IEnumerable means collection of entities.
    }
}
