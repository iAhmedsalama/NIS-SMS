using NIS.Models;
using System.Collections.Generic;

namespace NIS.Services
{
    public interface ICrsResultRepository
    {
        int Create(CrsResult crsResult);
        int Delete(CrsResult crsResult);
        List<CrsResult> GetAll();
        CrsResult GetById(int id);
        int Update(int id, CrsResult crsResult);
    }
}