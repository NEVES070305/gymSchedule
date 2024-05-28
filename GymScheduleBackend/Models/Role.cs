using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GymScheduleBackend.Models
{
    public class Role
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

    }
}
