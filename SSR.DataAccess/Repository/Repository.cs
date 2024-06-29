using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SSR.DataAccess.Repository.IRepository;
using System.Linq.Expressions;
using SSR.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SSR.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;

        internal DbSet<T> dbSet;
        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>(); //this is same as _db.Menu == dbSet

            _db.Dishes.Include(u => u.MenuItems).Include(u => u.MenuId); //can include multiple properties using .Include
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeDishes = null, bool tracked = false)

        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;            
            }
            else
            {
                query = dbSet.AsNoTracking(); //using AsNoTracking method will make sure that EFCore does not track attribute values and update automatically. We want to update any changes to attributes manually. Used in updating ShoppingCart table in HomeController. 
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeDishes))
            {
                foreach (var includeDish in includeDishes   //splitting it because I will be receiving them as comma separated values.
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeDish);
                }
            }
            return query.FirstOrDefault(); //Get method should always return a value.
        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeDishes = null) //includes MenuItems and Id  along with dbSet

        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter); 
            }
            if (!string.IsNullOrEmpty(includeDishes))
            {
                foreach (var includeDish in includeDishes  //splitting it because I will be receiving them as comma separated values.
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeDish);                    
                } 
            }
            return query.ToList(); //Get method should always return a value.
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
    }
}
