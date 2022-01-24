using NIS.Models;
using System.Collections.Generic;
using System.Linq;

namespace NIS.Services
{
    public class InstructorRepository : IInstructorRepository
    {
        DbEntities context;
        public InstructorRepository(DbEntities _context)
        {
            context = _context;
        }

        //Get All
        public List<Instructor> GetAll()
        {
            return context.Instructor.ToList();
        }

        //Get ById
        public Instructor GetById(int id)
        {
            return context.Instructor.FirstOrDefault(i => i.ID == id);
        }

        //Get ByName
        public Instructor GetByName(string name)
        {
            return context.Instructor.FirstOrDefault(i => i.Name == name);
        }


        //Get By List<Instructor> DeptartmentId
        public List<Instructor> GetByDeptartmentId(int id)
        {
            return context.Instructor.Where(i => i.dept_id == id).ToList();
        }

        //Get By Instructor DeptartmentId
        public Instructor GetInsByDeptartmentId(int id)
        {
            return (Instructor)context.Instructor.Where(i => i.dept_id == id);
        }

        //Create
        public int Create(Instructor instructor)
        {
            context.Instructor.Add(instructor);
            int row = context.SaveChanges();
            return row;
        }

        //Update
        public int Update(int id, Instructor instructor)
        {
            Instructor _instructor = context.Instructor.FirstOrDefault(i => i.ID == id);

            _instructor.ID = instructor.ID;
            _instructor.Name = instructor.Name;
            _instructor.Address = instructor.Address;
            _instructor.Course = instructor.Course;
            _instructor.Salary = instructor.Salary;
            _instructor.CrsID = instructor.CrsID;
            _instructor.Department = instructor.Department;
            _instructor.dept_id = instructor.dept_id;

            int row = context.SaveChanges();
            return row;
        }
        //Delete
        public int Delete(int id)
        {
            Instructor instructor = context.Instructor.FirstOrDefault(s => s.ID == id);

            context.Instructor.Remove(instructor);
            int row = context.SaveChanges();
            return row;
        }
    }
}
