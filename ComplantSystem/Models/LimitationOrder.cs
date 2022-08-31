using ComplantSystem.Models.Data.Base;
using System;

namespace ComplantSystem.Models
{
    public class LimitationOrder : IEntityBase
    {
        public LimitationOrder()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }
        public int OrderStatus { get; set; }
        public int UserResponsibleId { get; set; }
        public DateTime OrderDate { get; set; }
        public string Reason { get; set; }

    }
}