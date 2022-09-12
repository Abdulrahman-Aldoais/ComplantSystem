using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplantSystem.Models.Statistics
{
    public class StutusCompalintStatistic
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string Name { get; set; }
        public string TotalCountStutus { get; set; }
        public double stutus { get; set; }
    }
}
