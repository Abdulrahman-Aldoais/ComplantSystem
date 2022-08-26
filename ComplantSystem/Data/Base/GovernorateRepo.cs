using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComplantSystem.Models.Data.Base
{
    public class GovernorateRepo : ILocationRepo<Governorate>
    {

        private readonly AppCompalintsContextDB _context;
        public GovernorateRepo(AppCompalintsContextDB context) 
        {
            _context = context;
        }

        public List<Governorate> ListByFilter(Func<Governorate, bool> lamda)
        {
            var x = _context.Governorates.Where(lamda).ToList();
            return x;
        }
        public List<Governorate> List()
        {
            var x = _context.Governorates.ToList();
            return x;
        }

        public Governorate Find(int Id)
        {
            var c = _context.Governorates.Find(Id);
            return c;
        }

      
    }
}
