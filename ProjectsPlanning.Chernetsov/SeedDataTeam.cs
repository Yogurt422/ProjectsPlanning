using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov
{
    public class SeedDataTeam
    {
        public static async System.Threading.Tasks.Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            // Проверяем, существуют ли уже приоритет в базе данных
            if (!dbContext.Teams.Any())
            {
                var teams = new[]
                {
                    new Team
                    {
                        Name = "Команда 1"

                    },
                    new Team
                    {
                        Name = "Команда 2"
                    },
                    new Team
                    {
                        Name = "Команда 3"
                    }
                };
                await dbContext.Teams.AddRangeAsync(teams);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
