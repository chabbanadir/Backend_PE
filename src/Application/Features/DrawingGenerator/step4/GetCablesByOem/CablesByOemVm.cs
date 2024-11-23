using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.DrawingGenerator.step4.GetCablesByOem.Dto;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.DrawingGenerator.step4.GetCablesByOem;

public class CablesByOemVm : IMapFrom<Cable>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Cable, CablesByOemVm>().ReverseMap();
    }

}
