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
        List<Employee> IPersonService.GetAllemployees()
        {
            throw new NotImplementedException();
        }
    }
}
