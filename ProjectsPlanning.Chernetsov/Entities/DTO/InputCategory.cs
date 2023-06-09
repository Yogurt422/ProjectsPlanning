using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectsPlanning.Chernetsov.Entities.DTO
{
    public class InputCategory
    {
        [Required]
        [StringLength(100, ErrorMessage = "Максимальная длина {1}")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Максимальная длина {1}")]
        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}
