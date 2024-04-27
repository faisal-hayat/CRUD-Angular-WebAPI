using BackendAPI.Models;

namespace BackendAPI.Services.IServices
{
    public interface IEmployeeService
    {
        Task AddEmployee(Employee employee);
    }
}
