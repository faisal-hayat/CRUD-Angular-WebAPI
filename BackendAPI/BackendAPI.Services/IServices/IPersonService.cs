using BackendAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services.IServices
{
    public interface IPersonService
    {
        List<Employee> GetAllemployees();
        Employee GetEmployee(int id);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(Employee employee, int id);
        Task DeleteEmployee(int id);
    }
}
