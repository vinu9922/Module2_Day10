using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models
{
    public interface IEmpUnitOfWork : IDisposable
    {
        IRepository<Department_Model> Dept_Repo { get; }
        
        IRepository<Employees_Model> Emp_Repo { get; }
        Task<int> SaveAsync();
    }
    
}
