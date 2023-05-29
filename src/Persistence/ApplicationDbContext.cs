using System.Reflection;
using Backend.Application.Common.Interfaces;
using Backend.Domain.Common;
using Backend.Domain.Entities;
using Backend.Domain.Entities.DrawingGenerator;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Entities.Tools;
using Duende.IdentityServer.EntityFramework.Options;
using Identity.Services;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IDateTime _dateTime;
    private readonly IDomainEventService _domainEventService;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<OperationalStoreOptions> operationalStoreOptions,
        ICurrentUserService currentUserService,
        IDomainEventService domainEventService,
        IDateTime dateTime) : base(options, operationalStoreOptions)
    {
        _currentUserService = currentUserService;
        _domainEventService = domainEventService;
        _dateTime = dateTime;
    }

    public DbSet<TodoList> TodoLists => Set<TodoList>();
    public DbSet<TodoItem> TodoItems => Set<TodoItem>();

    // Master DATA 
    public DbSet<Oem> Oems => Set<Oem>();
    public DbSet<Component> Components => Set<Component>();
    public DbSet<Config> Configurations => Set<Config>();
    public DbSet<Note> Notes => Set<Note>();
    public DbSet<Package> Packages => Set<Package>();
    public DbSet<Harnessmaker> Harnessmakers => Set<Harnessmaker>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Cable> Cables => Set<Cable>();
    public DbSet<PartNumber> PartNumbers => Set<PartNumber>();
    public DbSet<Info> Infos => Set<Info>();
    public DbSet<ComponentPart> ComponentParts => Set<ComponentPart>();

    // Tools
    public DbSet<Picture> Pictures => Set<Picture>();


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedBy = _currentUserService.UserId;
                    entry.Entity.Created = _dateTime.Now;
                  //  entry.Entity.Id = new Guid();
                    break;

                case EntityState.Modified:
                    entry.Entity.LastModifiedBy = _currentUserService.UserId;
                    entry.Entity.LastModified = _dateTime.Now;
                    break;

              /*  case EntityState.Deleted:
                    entry.Entity.IsDeleted = true;
                    break;*/
            }
        }

        var events = ChangeTracker.Entries<IHasDomainEvent>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .Where(domainEvent => !domainEvent.IsPublished)
                .ToArray();

        var result = await base.SaveChangesAsync(cancellationToken);

        await DispatchEvents(events);

        return result;
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {

      // builder.Entity<AuditableEntity>().Property(x => x.Id).HasDefaultValue("NEWID()");
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        builder.Entity<ComponentWithSide>()
            .HasKey(c => new { c.DrawingDataId, c.ComponentId });

        builder.Entity<ComponentWithSide>()
            .HasOne(c => c.DrawingData)
            .WithMany()
            .HasForeignKey(c => c.DrawingDataId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ComponentWithSide>()
            .HasOne(c => c.Component)
            .WithMany()
            .HasForeignKey(c => c.ComponentId)
            .OnDelete(DeleteBehavior.NoAction);

        base.OnModelCreating(builder);
    }

    private async Task DispatchEvents(DomainEvent[] events)
    {
        foreach (var @event in events)
        {
            @event.IsPublished = true;
            await _domainEventService.Publish(@event);
        }
    }
}


