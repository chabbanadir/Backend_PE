using MediatR;

namespace Backend.Application.Features.MasterData.Cables.Queries.GetCables;

public class GetCablesQuery : IRequest<List<GetCablesResponse>>
{
}
