using MediatR;

namespace Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakers;

public class GetHarnessMakersQuery : IRequest<List<HarnessMakersResponse>>
{
}
