using NIS.Models;
using System.Collections.Generic;
using System.Linq;

namespace NIS.Services
{
    public class CourseRepository : ICourseRepository
    {
        DbEntities context;
        public CourseRepository(DbEntities _context)
        {
            context = _context;
        }


        //Get All
        public List<Course> GetAll()
        {
            return context.Course.ToList();
        }

        //Get ById
        public Course GetById(int id)
        {
            return context.Course.SingleOrDefault(c => c.ID == id);
        }

        //Create
        public int Create(Course course)
        {
            context.Course.Add(course);
            int row = context.SaveChanges();
            return row;
        }

        //Update
        public int Update(int id, Course course)
        {
            Course _course = context.Course.FirstOrDefault(c => c.ID == id);
            _course.ID = course.ID;
            _course.Name = course.Name;
            _course.MinDegree = course.MinDegree;
            _course.Degree = course.Degree;
            _course.Department = course.Department;

            int row = context.SaveChanges();
            return row;
        }

        //Delete
        public int Delete(int id)
        {
            Course course = context.Course.FirstOrDefault(c => c.ID == id);

            context.Course.Remove(course);
            int row = context.SaveChanges();
            return row;
        }
    }
}
