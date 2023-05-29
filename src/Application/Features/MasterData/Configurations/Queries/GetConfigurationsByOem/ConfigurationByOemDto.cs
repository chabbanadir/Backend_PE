using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationsByOem;

public class ConfigurationByOemDto: IMapFrom<Config>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}
