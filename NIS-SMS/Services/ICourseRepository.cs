using NIS.Models;
using System.Collections.Generic;

namespace NIS.Services
{
    public interface ICourseRepository
    {
        int Create(Course course);
        int Delete(int id);
        List<Course> GetAll();
        Course GetById(int id);
        int Update(int id, Course course);
    }
}