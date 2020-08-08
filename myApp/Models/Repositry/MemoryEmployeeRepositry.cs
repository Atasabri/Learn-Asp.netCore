using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.Repositry
{
    public class MemoryEmployeeRepositry : IEmployeeRepositry
    {
        public List<Employee> List;
        public MemoryEmployeeRepositry()
        {
            List = new List<Employee>
            {
                new Employee{ID=1,Name="AtaSabri",Email="ata@gmail.com",Phone="01142229025",DateofBirth=DateTime.Now,Password="1234"},
                new Employee{ID=2,Name="Ata",Email="sabri@gmail.com",Phone="01142229025",DateofBirth=DateTime.Now,Password="1234"},
                new Employee{ID=3,Name="Ahmed",Email="ahmed@gmail.com",Phone="01142229025",DateofBirth=DateTime.Now,Password="1234"},
            };
        }
        public Employee Create(Employee employee)
        {
            employee.ID = List.Max(x => x.ID) + 1;
            List.Add(employee);
            return employee;
        }

        public Employee Delete(int ID)
        {
            Employee employee = List.SingleOrDefault(x=>x.ID==ID);
            List.Remove(employee);
            return employee;
        }

        public Employee Details(int ID)
        {
            Employee employee = List.SingleOrDefault(x => x.ID == ID);
            return employee;
        }

        public Employee Edit(Employee newemployee)
        {
            Employee employee = List.SingleOrDefault(x => x.ID == newemployee.ID);
            employee.Name = newemployee.Name;
            employee.Email = newemployee.Email;
            employee.Password = newemployee.Password;
            employee.Phone = newemployee.Phone;
            employee.DateofBirth = newemployee.DateofBirth;

            return newemployee;
        }

        public List<Employee> GetAllEmployee()
        {
            return List;
        }
    }
}
