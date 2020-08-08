using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Models.Repositry
{
    public interface IEmployeeRepositry
    {
        List<Employee> GetAllEmployee();
        Employee Create(Employee employee);
        Employee Details(int ID);
        Employee Edit(Employee employee);
        Employee Delete(int ID);

    }

}
