using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplantSystem.Models.Data.Base
{
    public class DirectorateRepo : ILocationRepo<Directorate>
    {

        private readonly AppCompalintsContextDB _context;
        public DirectorateRepo(AppCompalintsContextDB context)
        {
            _context = context;
        }

        public List<Directorate> ListByFilter(Func<Directorate, bool> lamda)
        {
            var x = _context.Directorates.Where(lamda).ToList();
            return x;
        }
        public List<Directorate> List()
        {
            var x = _context.Directorates.ToList();
            return x;
        }

        public Directorate Find(int GovernorateId)
        {
            var c = _context.Directorates.Find(GovernorateId);
            return c;
        }




    }
}


