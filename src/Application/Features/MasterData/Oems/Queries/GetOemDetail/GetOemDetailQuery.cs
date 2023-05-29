using MediatR;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail;

public class GetOemDetailQuery : IRequest<OemDetailVm>
{
    public string? Id { get; set; }

}
