using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Contracts.Persistence;

public interface IComponentRepository : IAsyncRepository<Component>
{
    //Task<List<Component>> GetComponentDeatils(Guid id);
    Task<Component> GetComponentDeatils(Guid id, bool includeCategory);

}
