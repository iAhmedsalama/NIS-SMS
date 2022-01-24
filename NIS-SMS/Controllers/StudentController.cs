using NIS.Models;
using NIS.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System;
using NIS.Services;

namespace NIS.Controllers
{
    public class StudentController : Controller
    {

        IStudentRepository StudentService;
        IDepartmentRepository DepartmentService;
        ICrsResultRepository CrsResultService;

        public StudentController(IStudentRepository studentRepo, IDepartmentRepository departmentRepo, ICrsResultRepository crsResultRepo)
        {
            StudentService = studentRepo;
            DepartmentService = departmentRepo;
            CrsResultService = crsResultRepo;
        }




        #region Remote Validation on Name Property
        public IActionResult NameExists(string Name, int id)
        {
          
            //when create new student
            if (id == 0) //if not exists create new one
            {
                //create instance from student
                Student student = StudentService.GetByName(Name);

                if (student == null)
                    return Json(true); //name not exist
                else
                    return Json(false); //name exist
            }
            else //else student exists then edit based on student ID
            {
                //create instance from student
                Student student = StudentService.GetByName(Name);

                if (student == null)
                    return Json(true);//update name with new value not exist before
                else
                {
                    if (student.ID == id)//name not change
                        return Json(true);
                    else
                        return Json(false);//chaged in name with value already found

                }
                   
            }

        }

        #endregion

        #region AutoMapper
        //Create AutoMapper Interface Property
        /*
        private readonly IMapper _mapper;
        //Create Ctor
        public StudentController(IMapper mapper)
        {
            this._mapper = mapper;
        }
        */
        #endregion

        #region View Model GetStudentResult function
        /*
        public IActionResult GetStudentResult(int id)
        {

            CrsResult crsResult = context.CrsResult.Include(t => t.Trainee).Include(t => t.Course).FirstOrDefault(t => t.Trainee_ID == id);

            viewModel mapping
            var StudentVm = new StudentWithCrsResult()
            {
                StudentName = crsResult.Trainee.Name,
                CourseName = crsResult.Course.Name,
                StudentDegree = crsResult.Degree

            };

            #region Add logic to view based on data returned from DB
            if (StudentVm.StudentDegree <= 49)
            {
                StudentVm.Color = "Red";
            }
            else
            {
                StudentVm.Color = "green";
            }

            #endregion


            #region Use AutoMapper
            //var StdVm = _mapper.Map<StudentWithCrsResult>(trainee);

            #endregion

            return View(StudentVm);
        }
        */

        #endregion

        //add student action
        public IActionResult AddStudent()
        {
            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;
            return View();
        }


        //save student action
        [HttpPost]
        public IActionResult SaveAdd(Student student)
        {

            //validate the data passed from view
            if (ModelState.IsValid == true )
            {
                StudentService.Create(student);

                //retrun to getallstudents view
                return RedirectToAction("GetAllStudents");
            }

            //pass data from action to view
            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;


            //if data not valid return the same view and the data inserted
            return View("AddStudent", student);
        }


        //Edit Student action
        public IActionResult EditStudent(int id)
        {
            //pass data from action to view
            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;

            Student student = StudentService.GetById(id);

            return View("EditStudent", student);
        }

        [HttpPost]
        //Save Student Edit
        public IActionResult SaveStudent([FromRoute]int id, Student newstudent)
        {
            if(ModelState.IsValid == true)
            {
                StudentService.Update(id, newstudent);

            }

            List<Department> departments = DepartmentService.GetAll();
            ViewData["Department"] = departments;

            return RedirectToAction("GetAllStudents");
           
        }



        public IActionResult GetAllStudents()
        {
            List<Student> StudentList = StudentService.GetAll();
            return View("GetAllStudents", StudentList);
        }

        //student details
        public IActionResult StudentDetails(int id)
        {
            Student student = StudentService.GetById(id);
            return View("StudentDetails", student);
        }

        //delete student
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                StudentService.Delete(id);
                return View("GetAllStudents");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Exception", ex.InnerException.Message);
                return View("GetAllStudents");
            }
        }



        #region Testing Ajax
        public IActionResult TestAjax()
        {
            return View("~/Views/Ajax/TestAjax.cshtml");
        }
        #endregion
    }
}
