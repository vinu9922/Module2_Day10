using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models
{
    public class Assignment_10_Context : DbContext
    {
        public Assignment_10_Context(DbContextOptions options): base(options)
        {

        }
        public virtual DbSet<Department_Model> Depts { get; set; }
        public virtual DbSet<Employees_Model> Emps { get; set; }
    }
}
