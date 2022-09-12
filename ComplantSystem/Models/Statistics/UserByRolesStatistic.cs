using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models.Statistics
{
    public class UserByRolesStatistic
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string TotalCount { get; set; }
        public double RolsTot { get; set; }
    }
}
