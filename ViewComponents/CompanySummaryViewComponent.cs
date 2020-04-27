using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.ViewComponents
{
    public class CompanySummaryViewComponent : ViewComponent
    {
        private readonly IDepartmentService departmentService;

        public CompanySummaryViewComponent(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string title)
        {
            ViewBag.Title = title;
            var summary = await departmentService.GetCompanySummary();
            return View(summary);
        }
    }
}
