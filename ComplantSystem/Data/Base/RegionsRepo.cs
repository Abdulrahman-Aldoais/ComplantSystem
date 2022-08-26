using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;

namespace ComplantSystem.Data.Base
{
    public class RegionsRepo : EntityBaseRepository<Regions>, IRegionsRepo
    {
        public RegionsRepo(AppCompalintsContextDB context) : base(context)
        {

        }
    }

}
