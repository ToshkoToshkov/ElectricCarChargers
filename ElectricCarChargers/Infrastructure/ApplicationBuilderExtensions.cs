namespace ElectricCarChargers.Infrastructure
{
    using ElectricCarChargers.Data;
    using ElectricCarChargers.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<ElectricCarChargersDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(ElectricCarChargersDbContext data) 
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category {Name = "Monophase"},
                new Category {Name = "Three-phase"},
            });
            
            data.SaveChanges();
        }
    }
}
