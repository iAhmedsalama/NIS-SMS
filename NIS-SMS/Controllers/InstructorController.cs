using NIS.Models;
using NIS.Services;
using NIS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NIS.Controllers
{
    public class InstructorController : Controller
    {

        IInstructorRepository InstructorService;
        IDepartmentRepository DepartmentService;
        ICourseRepository CourseService;

        //Dependency injection
        public InstructorController(IInstructorRepository instructorRepo, IDepartmentRepository departmentRepo, ICourseRepository courseRepo)
        {
            InstructorService = instructorRepo;
            DepartmentService = departmentRepo;
            CourseService = courseRepo;
        }

        #region Remote Validation on Name Property
        public IActionResult NameExists(string Name, int id)
        {
            Instructor instructor = InstructorService.GetByName(Name);

            //Create
            if (id == 0)
            {
                return instructor == null ? Json(true) : Json(false);
            }
            //Edit
            return (instructor == null || instructor.ID == id) ? Json(true) : Json(false);

            #region code review

            //if (instructor == null)
            //    return Json(true);

            ////name exists
            //if (instructor.ID == id)
            //{
            //    return Json(true);

            //}
            //return Json(false);

            #endregion

        }
        #endregion


        //add new instructor
        public IActionResult AddInstructor()
        {
            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;

            List<Course> courses = CourseService.GetAll();
            ViewData["Course"] = courses;

            return View();
        }

        //save new instructor
        [HttpPost]
        public IActionResult saveAdd(Instructor instructor)
        {
            //validate data
            if (ModelState.IsValid == true)
            {
                InstructorService.Create(instructor);

                return RedirectToAction("GetAllInstructors");
            }
            //pass data from action to view
            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;

            List<Course> courses = CourseService.GetAll();
            ViewData["Course"] = courses;


            return View("AddInstructor");
        }



        //Edit Instructor
        public IActionResult EditInstructor(int id)
        {
            //pass data from action to view
            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;

            List<Course> courses = CourseService.GetAll();
            ViewData["Course"] = courses;

            Instructor instructor = InstructorService.GetById(id);
            return View("EditInstructor", instructor);
        }

        [HttpPost]
        //Save Student Edit
        public IActionResult SaveInstructor(int id, Instructor newInstructor)
        {
            Instructor instructor = InstructorService.GetById(id);

            InstructorService.Create(newInstructor);
            return RedirectToAction("GetAllInstructors");

        }

        //Display all instructors
        public IActionResult GetAllInstructors()
        {
            List<Instructor> instructorList = InstructorService.GetAll();
            return View("GetAllInstructors", instructorList);
        }

        //Get instructor Details
        public IActionResult InstructorDetails(int id)
        {
            Instructor instructor = InstructorService.GetById(id);

            return View("InstructorDetails", instructor);
        }

        public IActionResult GetInstructorByDeptId(int id)
        {
            Instructor instructor = InstructorService.GetInsByDeptartmentId(id);
            return PartialView("_Getinstructor", instructor);
        }

        //Delete instructor
        public IActionResult DeleteInstructor(int id)
        {
            try
            {
                InstructorService.Delete(id);

                return View("GetAllInstructors");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return View("GetAllStudents");
            }
        }
    }
}
