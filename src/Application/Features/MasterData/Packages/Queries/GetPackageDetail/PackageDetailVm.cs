using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Packages.Queries.GetPackageDetail;

public class PackageDetailVm : IMapFrom<Package>
{
    public Guid Id { get; set; }
    public string? Layer { get; set; }
    public string? PN { get; set; }
    public string? Qte { get; set; }
    public int Order { get; set; }
    public Status Status { get; set; }
}