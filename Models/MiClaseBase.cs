using System.ComponentModel.DataAnnotations;

namespace ICL.Models
{
    public class MiClaseBase
    {
        [Key]
        public int Id { get; set; }
        public bool Enable { get; set; } = true;
    }
}
