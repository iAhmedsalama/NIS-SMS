using NIS.Models;
using System.Collections.Generic;

namespace NIS.Services
{
    public interface IInstructorRepository
    {
        int Create(Instructor instructor);
        int Delete(int id);
        List<Instructor> GetAll();
        List<Instructor> GetByDeptartmentId(int id);
        Instructor GetById(int id);
        Instructor GetByName(string name);
        Instructor GetInsByDeptartmentId(int id);
        int Update(int id, Instructor instructor);
    }
}