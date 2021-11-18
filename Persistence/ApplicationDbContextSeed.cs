using Blog.Models.Entities;

namespace Blog.Persistence;

public static class ApplicationDbContextSeed
{
    public static async Task SeedGendersAsync(ApplicationDbContext context)
    {
        if (context.Sexes.Any())
            return;

        await context.Sexes.AddRangeAsync(new Sex { Name = "Male" }, new Sex { Name = "Female" });

        await context.SaveChangesAsync();
    }
}
