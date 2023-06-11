using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectsPlanning.Chernetsov.Entities.DTO
{
    public class EditProject
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Максимальная длина {1}")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [StringLength(500, ErrorMessage = "Максимальная длина {1}")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date, ErrorMessage = "Не правильная дата окончания")]
        public DateTime DueDate { get; set; }

        public IEnumerable<Project> Projects { get; set; }


        public List<SelectListItem> EditCategoryItems { get; set; }
        public List<SelectListItem> EditPriorityItems { get; set; }
        public List<SelectListItem> EditTeamItems { get; set; }
        public List<SelectListItem> EditStatusItems { get; set; }

        [Display(Name = "Категория")]
        public int SelectedValueCategory { get; set; }

        [Display(Name = "Приоритет")]
        public int SelectedValuePriority { get; set; }

        [Display(Name = "Команды")]
        public int SelectedValueTeam { get; set; }

        [Display(Name = "Статус")]
        public int SelectedValueStatus { get; set; }

        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public int TeamId { get; set; }


        public Category Category { get; set; }
        public Status Status { get; set; }
        public Priority Priority { get; set; }
        public Team Team { get; set; }


    }
}
