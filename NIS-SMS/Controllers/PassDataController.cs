using Microsoft.AspNetCore.Mvc;
using Day2.Models;
using Day2.ViewModel;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace Day2.Controllers
{
    public class PassDataController : Controller
    {

        DbEntities context = new DbEntities();

        #region AutoMapper
        private readonly IMapper _mapper;
        public PassDataController(IMapper mapper)
        {
            _mapper = mapper;
        }
        #endregion

        public IActionResult Index()
        {
            //---------ViewData---------//
            //Extra info from action to view
            List<string> branches = new List<string>();
            branches.Add("smart");
            branches.Add("assuit");
            branches.Add("mansoura");
            branches.Add("alex");

            ViewData["branchlist"] = branches;

            ViewData["msg"] = "Hello from  ViewData";


            //-----------ViewBag-----------//

            ViewBag.msg = "Hello from ViewBag";
            ViewBag.date = DateTime.Now.ToString();

            List<Department> DeptsModel = context.Department.ToList();
            #region view overload
            /*
             * 
            ///name view not the same name of action &model null
            return View("showAll");

            ///name view not the same name of action &with model
            return View("showAll", deptsModel);

            ///view name the same name of action & model null
            return View();        //view:index &model null

            ///view name the same name of action & with model 
            return View("index", deptsModel);   //view index & model=deptsModel

            */
            #endregion
            return View(DeptsModel);

        }

        public IActionResult showStudents(int id)
        {
            Student stdModel = context.Trainee.Include(s => s.Department).FirstOrDefault(s => s.ID == id);

            #region view Model to select specific students
            /*
            ////viewModel mapping 
            var stdVm = new StudentNameWithDeptNameVM()
            {
                ////take copy from Model set in ViewModel
                DeptName = stdModel.Department.Name,
                StudentName = stdModel.Name,
                ID = stdModel.ID
            };
            */
            #endregion

            #region view Model to select specific students [AutoMapper]

            var result = _mapper.Map<StudentNameWithDeptNameVM>(stdModel);

            #endregion

            #region Add logic to view based on data returned from DB
            if(result.DeptName == "SD")
            {
                result.Color = "Green";
            }
            else
            {
                result.Color = "Blue";
            }

            #endregion

            //List<Trainee> stdModel = context.Trainee.Include(s => s.Department).ToList();
            #region return all student with all departments [AutoMapper]

            //var result2 = _mapper.Map<StudentNameWithDeptNameVM>(stdModel);

            #endregion

            #region return all student with all departments
            //return all student with all departments
            /*
             * 
            List<Trainee> stdModel = context.Trainee.ToList();
            List<Trainee> stdModel = context.Trainee.Include(s => s.Department).ToList();

            List<StudentNameWithDeptNameVM> stdVM = new List<StudentNameWithDeptNameVM>();
            foreach (var itemModel in stdModel)
            {
            }
            */
            #endregion

            return View(result);
        }


    }
}
