using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Assignment10.Models;

namespace Assignment10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase, IDisposable
    {
       
       private readonly IRepository<Department_Model> dept_repo;
        private readonly IRepository<Employees_Model> emp_repo;
        private readonly IEmpUnitOfWork unitOfWork1;

        public EmployeesController(IRepository<Department_Model> dept_repo,
            IRepository<Employees_Model> emp_repo, IEmpUnitOfWork unitOfWork1)
        {
            this.dept_repo = dept_repo;
            this.emp_repo = emp_repo;
            this.unitOfWork1 = unitOfWork1;
        }

        public void Dispose()
        {
            dept_repo.Dispose();
            emp_repo.Dispose();
        }

        // GET: EmployeesController
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employees_Model>>> Get()
        {
            var emp = await emp_repo.Get(includes: "department_Model");
            return Ok(emp);

        }

        // GET: EmployeesController/Details/5

        [HttpGet("{id}")]
        public async Task<ActionResult<Employees_Model>> Get(int id)
        {
            var emp = await emp_repo.Get(emp_id => emp_id.Employees_ModelId==id, "department_Model");
            if(emp.Count()==0)
            {
                return NotFound();
            }
            return Ok(emp.First());
        }

   

        // POST: EmployeesController/Create
        [HttpPost]
      
        public async Task<ActionResult> Post([FromBody] Employees_Model model)
        {
            var emp = emp_repo.Add(model);
            await emp_repo.Save();
            return CreatedAtAction("Get", new { id = emp.Employees_ModelId }, emp);
        }

       

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id,[FromBody] Employees_Model model1)
        {
            var emp = emp_repo.Update(model1);
            await emp_repo.Save();
            return Ok(emp);
           
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var emp = await emp_repo.Get(emp_id => emp_id.Employees_ModelId == id, "department_Model");
            if(emp.Count()==0)
            {
                return NotFound();
            }
            var e1 = emp_repo.Delete(emp.First());
            await emp_repo.Save();

            return NoContent();
        }

      
    }
}
