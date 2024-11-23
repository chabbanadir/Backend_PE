using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.Common.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.DrawingGenerator.step5.GetPartsByComponent.Dtos;

public class ComponentDto : IMapFrom<Component>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public string? Rev { get; set; }
    public string? Description { get; set; }
    public double Length { get; set; }
    public int Position { get; set; }

    public ShowIn ShowIn { get; set; }
    public Status Status { get; set; }
    public Orientation Orientation { get; set; }

    public  CableDto Cable { get; set; } = null!;
    public  ConfigDto Config { get; set; } = null!;

}
