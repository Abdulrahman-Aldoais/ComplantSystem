using System.ComponentModel.DataAnnotations;

namespace ComplantSystem
{
    public class InputSearch
    {
        [MinLength(3)]
        [Required]
        public string Term { get; set; }
    }
}
