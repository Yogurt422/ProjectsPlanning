using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov
{
    public class SeedDataPriority
    {
        public static async System.Threading.Tasks.Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            // Проверяем, существуют ли уже приоритет в базе данных
            if (!dbContext.Priorities.Any())
            {
                var priorities = new[]
                {
                    new Priority
                    {
                        Name = "Низкий",
                        Description = "Низкий приоритет ставится проетам и задачам, выполняемым в последнюю очередь"

                    },
                    new Priority
                    {
                        Name = "Средний",
                        Description = "Средний приоритет ставится проетам и задачам, которые могут быть отложены"
                    },
                    new Priority
                    {
                        Name = "Высокий",
                        Description = "Проекты и задачи с высоким приоритетом, выполняются в первую очередь"
                    }
                };
                await dbContext.Priorities.AddRangeAsync(priorities);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
