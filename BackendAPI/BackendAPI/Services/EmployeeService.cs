using BackendAPI.Data;
using BackendAPI.Models;
using BackendAPI.Services.IServices;

namespace BackendAPI.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region post methods
        public async Task AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
