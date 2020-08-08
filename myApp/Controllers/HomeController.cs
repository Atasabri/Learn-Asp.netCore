using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myApp.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using myApp.Models.Repositry;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace myApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepositry _employeeRepositroy;
        private readonly IStringLocalizer<HomeController> localizer;

        public HomeController(IEmployeeRepositry employeeRepositry, IStringLocalizer<HomeController> localizer)
        {
            _employeeRepositroy = employeeRepositry;
            this.localizer = localizer;
        }


        public string TestLocalization()
        {

            return localizer["ata"].Value;
        }
        public IActionResult SetLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            return RedirectToAction(nameof(TestLocalization));
        }
        [Authorize(Policy = "testCustom")]
        public ActionResult index()
        {                       
            return View(_employeeRepositroy.GetAllEmployee());
        }

        public ActionResult Create()
        {
            // throw new Exception("asasa");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if(ModelState.IsValid)
            {
                Employee newemployee = _employeeRepositroy.Create(employee);
                return RedirectToAction(nameof(index));
            }
            return View();
        }
        public ActionResult Edit(int? ID)
        {
            Employee employee = _employeeRepositroy.GetAllEmployee().SingleOrDefault(x => x.ID == (ID??0));
            if(employee!=null)
            {
                return View(employee);
            }
            return RedirectToAction(nameof(index));
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
           
            _employeeRepositroy.Edit(employee);
            return RedirectToAction(nameof(index));
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            _employeeRepositroy.Delete(ID);
            return Json(ID);
        }

        public ActionResult Details(int? ID)
        {
            Employee employee = _employeeRepositroy.GetAllEmployee().SingleOrDefault(x => x.ID == (ID??0));
            if(employee!=null)
            {
                return View(employee);
            }
            return RedirectToAction(nameof(index));
        }



        //ERROR PAGE
        [Route("error/{statuscode}")]
        public ActionResult error(int statuscode)
        {
            return View(statuscode);
        }

        public ActionResult ExceptionGlobal()
        {
            var excption = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Message = excption.Error.Message;
            return View();
        }
    }
}
