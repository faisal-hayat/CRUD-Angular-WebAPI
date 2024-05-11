using BackendAPI.Models;
using BackendAPI.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services
{
    public class PersonService : IPersonService
    {
        Task IPersonService.AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        Task IPersonService.DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        List<Employee> IPersonService.GetAllemployees()
        {
            string? name = SimpleClass.printName("Hello world");
            SimpleClass simpleClass = new SimpleClass();
            simpleClass.setName(name);
            throw new NotImplementedException();
        }

        Employee IPersonService.GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        Task IPersonService.UpdateEmployee(Employee employee, int id)
        {
            throw new NotImplementedException();
        }
    }
}
