using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;

        public async Task<IActionResult> Index(int departmentId)
        {
            var department = await departmentService.GetById(departmentId);
            ViewBag.Title = $"Employee of {department.Name}";
            ViewBag.DepartmentId = departmentId;
            var employees =await employeeService.GeByDepartmentId(departmentId);
            return View(employees);
        }
        public IActionResult Add(int departmentId)
        {
            ViewBag.Title = "Add Employee";
            return View(new Employee { DepartmentId = departmentId });
        }
        [HttpPost]
        public async Task<IActionResult> Add(Employee employee)
        {
            if (ModelState.IsValid)
            {
                await employeeService.Add(employee);
            }
            return RedirectToAction(nameof(Index), new { departmentId = employee.DepartmentId });
        }

        public async Task<IActionResult> Fire(int employeeId)
        {
            var employee = await employeeService.Fire(employeeId);
            return RedirectToAction(nameof(Index), new { departmentId = employee.DepartmentId });
        }

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;

        }
    }
}