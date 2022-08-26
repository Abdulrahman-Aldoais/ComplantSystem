using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models.Data.Base
{
    public interface IEntityBase
    {
       
        public string Id { get; set; }
    }
}
