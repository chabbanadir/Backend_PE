using MediatR;

namespace Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakerDetail;

public class HarnessMakersDetailQuery : IRequest<HarnessMakersDetailVm>
{
    public string? Id { get; set; }

}
