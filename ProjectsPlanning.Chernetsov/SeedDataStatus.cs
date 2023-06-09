using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov
{
    public class SeedDataStatus
    {
        public static async System.Threading.Tasks.Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            // Проверяем, существуют ли уже статус в базе данных
            if (!dbContext.Statuses.Any())
            {
                var statuses = new[]
                {
                    new Status
                    {
                        Name = "Запланирован",
                        Description = "Проект или задача, добавленные в базу, но не используемые"

                    },
                    new Status
                    {
                        Name = "В работе",
                        Description = "Проект или задача, работа над которым начата"
                    },
                    new Status
                    {
                        Name = "Готов",
                        Description = "Проект или задача, работа над которым закончена"
                    }
                };
                await dbContext.Statuses.AddRangeAsync(statuses);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
