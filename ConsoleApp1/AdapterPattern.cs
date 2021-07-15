using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp11
{

    public class Client
    {
        private readonly ITarget _employees;
        public Client(ITarget employees)
        {
            _employees = employees;
        }
        public void DisplayEmployees()
        {
            foreach(var emp in _employees.GetEmployees())
            {
                Console.WriteLine($"Name of employee is {emp}");
            }
        }
    }


    public interface ITarget
    {
        List<string> GetEmployees();
    }

    public class EmployeeAdapter : SAP, ITarget
    {
        public List<string> GetEmployees()
        {
            return FetchEmployees();
        }
    }
    public class SAP
    {
        public List<string> FetchEmployees()
        {
            return new List<string> { "aadesh", "tom", "harry" };
        }
    }
    public class AdapterPattern
    {
        public static void Main2(string[] args)
        {
            //var l = new List<string> { "A", "B", "C" };
            //var r = Enumerable.Reverse(l);
            ITarget employeeTarget = new EmployeeAdapter();

            var clientEmployeeApp = new Client(employeeTarget);
            clientEmployeeApp.DisplayEmployees();
        }
    }
}
