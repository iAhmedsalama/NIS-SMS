using Day2.Models;
using System.Collections.Generic;

namespace Day2.Services
{
    public interface IDepartmentRepository
    {
        int Create(Department department);
        int Delete(int id);
        List<Department> GetAll();
        Department GetById(int id);
        int Update(int id, Department department);
    }
}