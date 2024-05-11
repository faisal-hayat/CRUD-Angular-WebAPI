using BackendAPI.Models;
using BackendAPI.Services.IServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendAPI.Services
{
    public class SimpleClass: IPersonService
    {
        public string? firstName;
        private string? lastName;
        protected string? fullName;
        internal string? nickName;
        protected internal string? givenName;

        List<Employee> IPersonService.GetAllemployees()
        {
            throw new NotImplementedException();
        }

        // generic method
        public static bool CompareValues<T>(T a, T b)
        {
            try
            {
                int[] intArray = new int[10];
                ArrayList arrayList = new ArrayList();
                Hashtable hashtable = new Hashtable();
                hashtable.Add("a", "10");
                return a.Equals(b);
            }catch(Exception ex)
            {
                throw ex;
            }
            finally
            {

            }
        }

        // static method
        public static string? printName(string? name)
        {
            try
            {
                if (!string.IsNullOrEmpty(name))
                {
                    Console.WriteLine("name is : " + name.ToString());
                    return name;
                }
                else
                {
                    Console.WriteLine("Name not provided");
                    return null;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public void setName(string? name)
        {
            if (string.IsNullOrEmpty(name))
            {
                this.firstName = name;
            }            
        }

        Employee IPersonService.GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        Task IPersonService.AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        Task IPersonService.UpdateEmployee(Employee employee, int id)
        {
            throw new NotImplementedException();
        }

        Task IPersonService.DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
