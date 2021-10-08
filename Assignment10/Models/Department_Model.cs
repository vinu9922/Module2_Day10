using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Assignment10.Models
{
    public class Department_Model
    {
        //[Key]
        public int Department_ModelId { get; set; }
        public string Department_Name { get; set; }
        public int Total_Employees { get; set; }

         public string Employees_in_dept;

        public virtual ICollection<Employees_Model> employees_list { get; set; }
    }
}
