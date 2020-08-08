using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace myApp.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        private DB _db;
        private IHostingEnvironment _hostingEnvironment;
        public DepartmentController(DB db, IHostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {           
            return View(_db.Departments.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department,IFormFile Photo)
        {
            _db.Departments.Add(department);
            _db.SaveChanges();
            if(Photo!=null)
            {
                using(var file= new FileStream(_hostingEnvironment.WebRootPath + "/Uploads/" + department.ID + ".jpg", FileMode.Create))
                {
                    Photo.CopyTo(file);
                }
            }
            return View();
        }
        public ActionResult Edit(int? ID)
        {
            Department department = _db.Departments.SingleOrDefault(x => x.ID == (ID??0));
            if(department!=null)
            {
                return View(department);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public ActionResult Edit(Department department,IFormFile Photo)
        {
            _db.Entry(department).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            if(Photo!=null)
            {
                using(var file = new FileStream(_hostingEnvironment.WebRootPath + "/Uploads/" + department.ID + ".jpg", FileMode.Create))
                {
                    Photo.CopyTo(file);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public JsonResult Delete(int ID)
        {
            Department department = _db.Departments.SingleOrDefault(x => x.ID == ID);
            _db.Departments.Remove(department);
            _db.SaveChanges();
            System.IO.File.Delete(_hostingEnvironment.WebRootPath + "/Uploads/" + ID + ".jpg");
            return Json(ID);
        }

        public ActionResult Details(int? ID)
        {
            Department department = _db.Departments.SingleOrDefault(x => x.ID == (ID??0));
            if(department!=null)
            {
                return View(department);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
