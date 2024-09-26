using MVC_Project.BLL.Interfacies;
using MVC_Project.BLL.Repositores;
using MVC_Project.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Hosting;
using MVC_Project.BLL.Interfacies;
using MVC_Project.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Project_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmnetRepository;  //Default Null ,//Call DepartmnentRepository 
        private readonly IWebHostEnvironment _env;

        public DepartmentController(IDepartmentRepository repository, IWebHostEnvironment env)
        {
            _departmnetRepository = repository;
            _env = env;
        }


        // BaseUrl/department/Index
        public IActionResult Index()
        {
            // GetAll()
            var departments = _departmnetRepository.GetAll();

            return View(departments);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                var Count = _departmnetRepository.Add(department);
                if (Count > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(department);
        }





        //Department/Details/ Id
        [HttpGet]
        public IActionResult Details(int? id, string viewName = "Details")  // (?) Nullable  =>  HAsValue check Value
        {
            if (!id.HasValue)
            {
                return BadRequest();
            }
            var department = _departmnetRepository.GetById(id.Value); // Chech Date
            if (department == null)
            {
                return NotFound();  //Error 404
            }
            return View(viewName, department);
        }


    //    var department = _departmentRepository.GetDepartmentById(id);
    //if (department == null)
    //{
    //    return NotFound();
    //}
    //return View(department);


    [HttpGet]
        public IActionResult Update(int? id)
        {
            var department = _departmnetRepository.GetById(id.Value);
            if (department == null)
            {
                return NotFound();
            }
            return View("Update", department);
            //--------------------------------------------
            //if (!id.HasValue)
            //{
            //    return BadRequest();
            //}
            //var department = _departmnetRepository.GetById(id.Value); // Chech Date
            //if (department == null)
            //{
            //    return NotFound();  //Error 404
            //}
            //return View(department);
        }

        [HttpPost]
        public IActionResult Update([FromRoute] int id, Department department)
        {
            if (ModelState.IsValid)
            {
                _departmnetRepository.Update(department);
                return RedirectToAction("Index");
            }
            return View("Update", department);
            //if (id != department.Id) //Check Id Url 
            //    return BadRequest();

            //if (!ModelState.IsValid)
            //    return View(department);

            //try
            //{
            //    _departmnetRepository.Update(department);
            //    return RedirectToAction(nameof(Index));
            //}
            //catch (Exception Ex)
            //{
            //    if (_env.IsDevelopment())
            //    {
            //        ModelState.AddModelError(string.Empty, Ex.Message);
            //    }
            //    else
            //    {
            //        ModelState.AddModelError(string.Empty, "An Error occured During Update Department ");
            //    }
            //    return View(department);
        }
        


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            return Details(id, "Delete");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Department department)
        {
            try
            {
                _departmnetRepository.Delete(department);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception Ex)
            {
                if (_env.IsDevelopment())
                {
                    ModelState.AddModelError(string.Empty, Ex.Message);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An Error occured During Update Department ");
                }
                return View(department);
            }
        }
    }
}