using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Common.Mappings;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.DrawingGenerator.step2.GetOemsHarnessMakers.Dto;

public class HarnessMakersDto :IMapFrom<Harnessmaker>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
}