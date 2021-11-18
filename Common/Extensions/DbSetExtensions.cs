using Microsoft.EntityFrameworkCore;

namespace Blog.Common.Extensions;

public static class DbSetExtensions
{
    public static async Task<TOut> FindOrErrorAsync<TOut>(this DbSet<TOut> entitySet, Guid ID) where TOut : class
    {
        var entity = await entitySet.FindAsync(ID);

        if (entity is null) throw new Exception($"Entity with id {ID} not found");

        return entity;
    }
}
