using MediatR;


namespace Backend.Application.Features.MasterData.Packages.Queries.GetPackageDetail;

public class GetPackageDetailQuery : IRequest<PackageDetailVm>
{
    public string? Id { get; set; }

}