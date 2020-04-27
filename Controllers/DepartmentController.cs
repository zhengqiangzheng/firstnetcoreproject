using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly IEmployeeService employeeService;


        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var departments = await departmentService.GetAll();
           // var model = departments.Select(x => new { ID = x.Id, Name = x.Name });
            return View(departments);
        }
        public IActionResult Add()
        {
            ViewBag.Title = "add department";
            return View(new Department());
        }
        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if (ModelState.IsValid)
            {
                await departmentService.Add(department);
            }
            return RedirectToAction(nameof(Index));
        }
        public DepartmentController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            this.departmentService = departmentService;
            this.employeeService = employeeService;
        }
    }
}