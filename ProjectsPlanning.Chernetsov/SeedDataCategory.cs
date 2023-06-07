using ProjectsPlanning.Chernetsov.Data;
using ProjectsPlanning.Chernetsov.Entities;

namespace ProjectsPlanning.Chernetsov
{
    public class SeedDataCategory
    {
        public static async System.Threading.Tasks.Task EnsureSeedData(IServiceProvider provider)
        {
            var dbContext = provider.GetRequiredService<ApplicationDbContext>();

            // Проверяем, существуют ли уже должности в базе данных
            if (!dbContext.Categories.Any())
            {
                var categories = new[]
                {
                    new Category
                    {
                        Name = "Разработка продукта или услуги",
                        Description = "Проекты, связанные с создание, разработкой и планированием продукта или услуги"
                    },
                    new Category
                    {
                        Name = "Инфраструктурный проект",
                        Description = "Проекты, связанные со строительством или реконструкцией здания и сооружений"
                    },
                    new Category
                    {
                        Name = "IT-проект",
                        Description = "Проекты, связанные с разработкой и внедрением новых информационных систем и программного обеспечения"
                    },
                    new Category
                    {
                        Name = "Другое",
                        Description = "Проекты, не относящиеся к вышеперечисленным категориям"
                    }
                };
                await dbContext.Categories.AddRangeAsync(categories);
                try
                {
                    await dbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
