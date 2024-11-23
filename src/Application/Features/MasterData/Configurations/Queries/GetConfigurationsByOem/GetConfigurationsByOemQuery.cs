using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationsByOem;

public class GetConfigurationsByOemQuery : IRequest<List<ConfigurationsByOemVm>>
{
    public string? oemId { get; set; }
}
