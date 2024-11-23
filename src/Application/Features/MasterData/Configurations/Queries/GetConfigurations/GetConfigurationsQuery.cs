using MediatR;

namespace Backend.Application.Features.MasterData.Configurations.Queries.GetConfigurations;

public class GetConfigurationsQuery : IRequest<List<GetConfigurationsResponse>>
{
}
