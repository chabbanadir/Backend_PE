using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationsByOem;

public class ConfigurationsByOemVm : IMapFrom<Config>
{

    public Guid Id { get; set; }
    public string? Name { get; set; } 
}
