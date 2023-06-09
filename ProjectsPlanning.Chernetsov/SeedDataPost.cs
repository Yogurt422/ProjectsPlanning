using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov
{
    public class SeedDataPost
    {
        public static async System.Threading.Tasks.Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            // Проверяем, существуют ли уже должности в базе данных
            if (!dbContext.Posts.Any())
            {
                var posts = new[]
                {
                    new Post
                    {
                        Name = "Директор",
                        Description = "Высшему руководящий составом предприятий",
                        Responsibilities = "Разбираться с важными доументами и выполнять контроль на предприятии"
                    },
                    new Post
                    {
                        Name = "Программист",
                        Description = "Специалист, занимающийся разработкой алгоритмов и компьютерных программ с помощью написания исходного кода, поиска ошибок и добавления функций с учетом поставленной задачи.",
                        Responsibilities = "Делать всё, что не делает директор"
                    }
                };
                await dbContext.Posts.AddRangeAsync(posts);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
