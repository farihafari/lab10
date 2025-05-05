using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MainController : ApiController
    {
        Employee[] employees = new Employee[]
        {
            new Employee { Id = 1, Name = "Ali", Department = "HR", JoiningDate = DateTime.Parse(DateTime.Today.ToString()) },
            new Employee { Id = 2, Name = "Kinza", Department = "IT", JoiningDate = DateTime.Parse(DateTime.Today.ToString())},
            new Employee { Id = 3, Name = "Aqsa", Department = "Finance", JoiningDate = DateTime.Parse(DateTime.Today.ToString()) }
        };
        public IEnumerable<Employee> GetAllEmployees()
        {
            return employees;
        }
    }
}
