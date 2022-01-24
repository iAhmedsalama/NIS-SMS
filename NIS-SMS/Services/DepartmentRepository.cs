using NIS.Models;
using System.Collections.Generic;
using System.Linq;

namespace NIS.Services
{
    public class DepartmentRepository : IDepartmentRepository
    {
        DbEntities context;
        public DepartmentRepository(DbEntities _context)
        {
            context = _context;
        }
        //GetAll
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }

        //Get one ByID 
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d => d.ID == id);
        }

        //Create
        public int Create(Department department)
        {
            context.Add(department);
            int row = context.SaveChanges();
            return row;
        }

        //update
        public int Update(int id, Department department)
        {
            Department _Department = context.Department.FirstOrDefault(d => d.ID == id);
            _Department.ID = department.ID;
            _Department.Name = department.Name;
            _Department.ManagerName = department.ManagerName;

            int row = context.SaveChanges();
            return row;
        }

        //Delete
        public int Delete(int id)
        {
            Department department = context.Department.FirstOrDefault(d => d.ID == id);
            context.Remove(department);
            int row = context.SaveChanges();
            return row;
        }
    }
}
