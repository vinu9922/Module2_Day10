using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models
{
    public class Employees_Model
    {
        public int Employees_ModelId { get; set; }
        public string Employee_name { get; set; }
        public string Employee_Email { get; set; }
        public int Emp_Dep_Id { get; set; }

        public string Department_Name_emp;

        public virtual Department_Model department_Model { get; set; }
       
    }
}
