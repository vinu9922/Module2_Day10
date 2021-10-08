using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Assignment10.Models
{
    public class GenericRepository<T> : IRepository<T> where T: class
    {
        private readonly Assignment_10_Context context;
        public GenericRepository(Assignment_10_Context context)
        {
            this.context = context;
        }
        public T Add(T item)
        {
            return context.Add(item).Entity;
        }

        public T Update(T item)
        {
            return context.Update(item).Entity;
        }

        public T Delete(T item)
        {
            return context.Remove(item).Entity;
        }

        public void Dispose()
        {
             context.Dispose();
        }

        public async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> condition = null, string includes = null)
        {
            var Set = context.Set<T>().AsQueryable();
            if(includes!=null)
            {
                var Navigation_properties = includes.Split(',');
                foreach(var navigation_properties in Navigation_properties)
                {
                    Set = Set.Include(navigation_properties);
                }

            }
            if(condition!=null)
            {
                Set = Set.Where(condition);
            }
            return await Set.ToListAsync();
        }

        public async Task<int> Save()
        {
            return await context.SaveChangesAsync();
        }

        
    }
}
