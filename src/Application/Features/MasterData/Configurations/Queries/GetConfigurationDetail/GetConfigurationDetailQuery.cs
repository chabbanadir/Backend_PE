using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurationDetail;

public class GetConfigurationDetailQuery : IRequest<ConfigurationDetailVm>
{
    public string? Id { get; set; }

}
