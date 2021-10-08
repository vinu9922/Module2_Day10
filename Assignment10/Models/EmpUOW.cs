using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment10.Models
{
    public class EmpUOW : IEmpUnitOfWork
    {

        private readonly Assignment_10_Context context;
        private readonly IRepository<Employees_Model> emp_repository;
        private readonly IRepository<Department_Model> dept_repository;
        public EmpUOW(Assignment_10_Context context)
        {
            this.context = context;
            emp_repository = new GenericRepository<Employees_Model>(this.context);
            dept_repository = new GenericRepository<Department_Model>(this.context);
        }



        
        public IRepository<Department_Model> Dept_Repo { get { return dept_repository; } }

        public IRepository<Employees_Model> Emp_Repo { get { return emp_repository; } }

        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
