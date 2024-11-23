using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;


namespace Backend.Application.Features.MasterData.Harnessmakers.Queries.GetHarnessMakerDetail;

public class HarnessMakersDetailVm : IMapFrom<Harnessmaker>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? Manufacturing_code { get; set; }
    public string? Bar_code { get; set; }
    public Status Status { get; set; }
}
