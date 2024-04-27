using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Services.IServices;

namespace BackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEmployeeService _employeeService;
        public EmployeesController(ApplicationDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        #region Get methods
        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            // return await _context.Employees.ToListAsync();
            List<Employee> employeesList = await _employeeService.GetAllEmployeesAsync();
            if(employeesList != null && employeesList.Count > 0)
            {
                return employeesList;
            }
            else
            {
                return NotFound();
            }
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            // var employee = await _context.Employees.FindAsync(id);
            Employee employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }
        #endregion

        #region post methods
        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            try
            {
                //_context.Employees.Add(employee);
                //await _context.SaveChangesAsync();
                if (ModelState.IsValid)
                {
                    await _employeeService.AddEmployee(employee);
                    return Ok(new { message = "Employee added successfull", status = true });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }


            return CreatedAtAction("GetEmployee", new { id = employee.Id }, employee);
        }
        #endregion

        #region delete methods
        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeService.DeleteEmployeeById(id);
            // _context.Employees.Remove(employee);
            // await _context.SaveChangesAsync();

            return NoContent();
        }
        #endregion

        #region helper methods
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        #endregion
    }
}
