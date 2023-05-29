using Backend.Domain.Entities;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using Microsoft.EntityFrameworkCore;

namespace Backend.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }


    DbSet<Oem> Oems { get; }
    DbSet<Picture> Pictures { get; }

    DbSet<Cable> Cables { get; }
    DbSet<Category> Categories { get; }
    DbSet<Component> Components { get; }
    DbSet<Config> Configurations { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
