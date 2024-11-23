using Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers.Dto;

namespace Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers;

public class OemsHarnessMakersVm
{
    public IList<OemDto> Oems { get; set; } = new List<OemDto>();

    public IList<HarnessMakersDto> HarnessMakers { get; set; } = new List<HarnessMakersDto>();
}
