using Day2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Services
{
    //Services For Student Model
    public class StudentRepository:IStudentRepository
    {
        DbEntities context;
        public StudentRepository(DbEntities _context)
        {
            context = _context;
        }

        //Get All
        public List<Student> GetAll()
        {
            return context.Trainee.ToList();
        }

        //Get one ById
        public Student GetById(int id)
        {
            return context.Trainee.FirstOrDefault(s => s.ID == id);
        }

        //Get one ByName
        public Student GetByName(string name)
        {
            return context.Trainee.FirstOrDefault(n => n.Name == name);
        }


        //Create
        public int Create(Student student)
        {
            context.Trainee.Add(student);
            int row = context.SaveChanges();
            return row;
        }

        //Update
        public int Update(int id, Student _student)
        {
            Student student = context.Trainee.FirstOrDefault(s => s.ID == id);

            student.ID = _student.ID;
            student.Name = _student.Name;
            student.Address = _student.Address;
            student.Degree = _student.Degree;
            student.Image = _student.Image;
            student.Department = _student.Department;
            student.dept_id = _student.dept_id;

            int row = context.SaveChanges();
            return row;
        }
        //Delete
        public int Delete(int id)
        {
            Student student = context.Trainee.FirstOrDefault(s => s.ID == id);

            context.Trainee.Remove(student);
            int row = context.SaveChanges();
            return row;
        }

    }
}
