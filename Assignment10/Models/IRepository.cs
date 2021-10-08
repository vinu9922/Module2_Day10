using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Assignment10.Models
{
    public interface IRepository <T> :IDisposable where T:class
    {
        T Add(T item);
        T Update(T item);
        T Delete(T item);

        Task<int> Save();
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> condition = null, string includes = null);
    }
}
