using ComplantSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ComplantSystem.Service
{
    public class ComplaintsRepository : ICompRepository<UploadsComplainte>
    {
        AppCompalintsContextDB dbContext;


        public ComplaintsRepository(AppCompalintsContextDB _dbContext)
        {
            dbContext = _dbContext;

        }

        public void Add(UploadsComplainte entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string id)
        {
            var record = Find(id, "");
            dbContext.UploadsComplaintes.Remove(record);
            dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public UploadsComplainte Find(string id, string KeyTerm)
        {
            var record = dbContext.UploadsComplaintes.Include(x => x.StagesComplaint).Include(x => x.StatusCompalint).SingleOrDefault(x => x.Id == id);
            return record;
        }



        public IList<UploadsComplainte> List()
        {

            return dbContext.UploadsComplaintes
                .Include(x => x.StagesComplaint)
                .Include(x => x.StatusCompalint)
                .Include(x => x.Governorate)
                .ToList();
        }

        public List<UploadsComplainte> Search(string id, string KeyTerm)
        {

            var rusult = dbContext.UploadsComplaintes
                .Include(x => x.StagesComplaint)
                .Include(x => x.StatusCompalint)
                .Include(x => x.Governorate)
               .Where(b => b.Id.Contains(KeyTerm)).ToList();
            return rusult;
        }



        public void Update(string Id, UploadsComplainte entity)
        {
            dbContext.Update(entity);
            dbContext.SaveChanges();
        }

    }
}
