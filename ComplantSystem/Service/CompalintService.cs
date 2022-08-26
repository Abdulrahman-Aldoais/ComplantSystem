using ComplantSystem.Models;
using ComplantSystem.Models.Data.Base;


namespace ComplantSystem.Service
{
    public class CompalintService : EntityBaseRepository<UploadsComplainte>
    {
        public CompalintService(AppCompalintsContextDB context) : base(context) { }
    }
}
