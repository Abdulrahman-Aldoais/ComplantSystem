using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ComplantSystem
{

    public class VillageRepo : ILocationRepo<Village>
    {

        private readonly AppCompalintsContextDB _context;
        public VillageRepo(AppCompalintsContextDB context)
        {
            _context = context;
        }

        public List<Village> ListByFilter(Func<Village, bool> lamda)
        {
            var v = _context.Villages.Where(lamda).ToList();
            return v;
        }
        public List<Village> List()
        {
            var v = _context.Villages.ToList();
            return v;
        }

        public Village Find(int Id)
        {
            var v = _context.Villages.Find(Id);
            return v;
        }


    }
}
