using BackendAPI.Models;

namespace BackendAPI.Services.IServices
{
    public interface IEmployeeService
    {
        Task AddEmployee(Employee employee);

        Task<List<Employee>> GetAllEmployeesAsync();

        Task<Employee?> GetEmployeeById(int id);

        Task DeleteEmployeeById(int id);
    }
}


