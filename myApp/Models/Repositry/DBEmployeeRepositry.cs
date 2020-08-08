using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.Repositry
{
    public class DBEmployeeRepositry : IEmployeeRepositry
    {
        private DB _db;
        public DBEmployeeRepositry(DB db)
        {
            _db = db;
        }
        public Employee Create(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
            return employee;
        }

        public Employee Delete(int ID)
        {
            Employee employee= _db.Employees.Find(ID);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return employee;
        }

        public Employee Details(int ID)
        {
            Employee employee = _db.Employees.Find(ID);
            return employee;
        }

        public Employee Edit(Employee newemployee)
        {
            _db.Entry(newemployee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return newemployee;
        }

        public List<Employee> GetAllEmployee()
        {
            return _db.Employees.ToList();
        }
    }
}
