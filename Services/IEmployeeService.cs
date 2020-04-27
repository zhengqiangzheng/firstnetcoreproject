﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IEmployeeService
    {
        Task Add(Employee employee);
        Task<Employee> GetEmployeeById(int employeeId);
        Task<Employee> Fire(int id);
        Task<IEnumerable<Employee>> GeByDepartmentId(int departmentId);

    }
}
