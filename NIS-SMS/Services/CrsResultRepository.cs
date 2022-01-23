using Day2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Day2.Services
{
    public class CrsResultRepository : ICrsResultRepository
    {
        DbEntities context;
        public CrsResultRepository(DbEntities _context)
        {
            context = _context;
        }

        //Get All
        public List<CrsResult> GetAll()
        {
            return context.CrsResult.ToList();
        }

        //Get one ById
        public CrsResult GetById(int id)
        {
            return context.CrsResult.SingleOrDefault(crs => crs.ID == id);
        }

        //Create
        public int Create(CrsResult crsResult)
        {
            context.CrsResult.Add(crsResult);
            int row = context.SaveChanges();
            return row;
        }

        //Update
        public int Update(int id, CrsResult crsResult)
        {
            CrsResult _crsResult = context.CrsResult.FirstOrDefault(crs => crs.ID == id);

            _crsResult.ID = crsResult.ID;
            _crsResult.Trainee = crsResult.Trainee;
            _crsResult.Degree = crsResult.Degree;
            _crsResult.Course = crsResult.Course;
            _crsResult.CrsID = crsResult.CrsID;
            _crsResult.Trainee_ID = crsResult.Trainee_ID;

            int row = context.SaveChanges();
            return row;
        }

        //delete
        public int Delete(CrsResult crsResult)
        {
            context.CrsResult.Remove(crsResult);
            int row = context.SaveChanges();
            return row;
        }
    }
}
