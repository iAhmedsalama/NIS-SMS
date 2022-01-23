using Day2.Models;
using System.Collections.Generic;

namespace Day2.Services
{
    public interface IStudentRepository
    {
        int Create(Student student);
        int Delete(int id);
        List<Student> GetAll();
        Student GetById(int id);
        Student GetByName(string name);
        int Update(int id, Student student);
    }
}