using Day2.Models;
using Day2.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Controllers
{
    public class DepartmentController : Controller
    {

        IInstructorRepository InstructorService;
        IDepartmentRepository DepartmentService;
        public DepartmentController(IInstructorRepository instructorRepo, IDepartmentRepository departmentRepo)
        {
            InstructorService = instructorRepo;
            DepartmentService = departmentRepo;
        }
        
        //GetAll  Instructors
        public IActionResult Index()
        {
            List<Department> DepartmentModel = DepartmentService.GetAll();
            return View("Index", DepartmentModel);
        }

        #region Get instructor By Dept_id

        public IActionResult GetByDeptartmentId(int id)
        {
            List<Instructor> InstructorModel = InstructorService.GetByDeptartmentId(id);
            return PartialView("GetByDeptartmentId", InstructorModel);
        }

        #endregion

        //public IActionResult GetById(int id)
        //{
        //    Instructor instructor = InstructorService.GetById(id);
        //    return PartialView("_instructor", instructor);
        //}

        //Add new Department
        public IActionResult AddDept()
        {
            //create new department instance
            Department department = new Department();
            return View(department);
        }

        //Save added Department
        public IActionResult SaveAdd( [Bind(include:"name, managername")] Department newdept)
        {
            if(newdept.Name !=null && newdept.ManagerName != null)
            {
                //save to DB
                DepartmentService.Create(newdept);

                //display index ation to call index view
                //return View("index");//Exception
                return RedirectToAction("Index");
            }

            //redirect to add view
            return View("AddDept",newdept);
        }
    }
}
