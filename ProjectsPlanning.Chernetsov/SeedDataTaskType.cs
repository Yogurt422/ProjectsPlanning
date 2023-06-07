using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov
{
    public class SeedDataTaskType
    {
        public static async System.Threading.Tasks.Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            // Проверяем, существуют ли уже должности в базе данных
            if (!dbContext.TaskTypes.Any())
            {
                var taskTypes = new[]
                {
                    new TaskType
                    {
                        Name = "Создание нового продукта или услуги",
                        Description = "Задачи, связанные с создание, разработкой и планированием продукта или услуги"
                    },
                    new TaskType
                    {
                        Name = "Анализ и оптимизация рабочих процессов",
                        Description = "Задачи, связанные с анализом, вносом изменений и оптимизацией рабочих процессов на предприятии"
                    },
                    new TaskType
                    {
                        Name = "Документация",
                        Description = "Задачи, связанные со сбором, заполнением, написанием или подписями документами"
                    },
                    new TaskType
                    {
                        Name = "Адаптация продукта или услуги",
                        Description = "Задачи, связанные с адаптацией продукта или услуги под требования конкретного рынка или клиента"
                    },
                    new TaskType
                    {
                        Name = "Другое",
                        Description = "Задача, не относящаяся к вышеперечисленным типам"
                    }
                };
                await dbContext.TaskTypes.AddRangeAsync(taskTypes);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
