using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ProjectsPlanning.Chernetsov.Entities.DTO
{
    //1
    //Для того чтобы создать форму для начала надо создать InputModel, который будет хранить в себе входные данные от пользователя, там мы прописываем
    //Дата аннотации (проверки)
    public class InputTask
    {
        [Required]
        [StringLength(100, ErrorMessage = "Максимальная длина {1}")]
        [Display(Name = "Название")]
        public string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Максимальная длина {1}")]
        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Тип задачи")]
        public string SelectedValueTaskType { get; set; }

        [Required]
        [Display(Name = "Приоритет")]
        public string SelectedValuePriority { get; set; }

        [Required]
        [Display(Name = "Дата окончания")]
        [DataType(DataType.Date, ErrorMessage = "Не правильная дата окончания")]
        public DateTime DueDate { get; set; }
    }
}
