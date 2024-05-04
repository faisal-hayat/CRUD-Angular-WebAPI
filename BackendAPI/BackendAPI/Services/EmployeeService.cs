using BackendAPI.Database;
using BackendAPI.Models;
using BackendAPI.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace BackendAPI.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Get Methods

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                List<Employee> employeesList =  await _dbContext.Employees.ToListAsync();
                return employeesList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }

        public async Task<Employee?> GetEmployeeById(int id)
        {
            try
            {
                Employee employee = await _dbContext.Employees.FindAsync(id);
                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            // throw new NotImplementedException();
        }
        #endregion

        #region post methods
        public async Task AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }
        #endregion

        #region delete methods
        public async Task DeleteEmployeeById(int id)
        {
            try
            {
                Employee employee = await _dbContext.Employees.FindAsync(id);
                if(employee != null)
                {
                    _dbContext.Employees.Remove(employee);
                    await _dbContext.SaveChangesAsync();
                }
            }catch(Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }
        #endregion
    }
}
