using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Application.Common.Mappings;
using Backend.Application.Features.MasterData.Components.Queries.GetComponentParts;
using Backend.Domain.Entities.MasterData;

namespace Backend.Application.Features.MasterData.Components.Commands.ImportParts;


public class ImportPartMV : IMapFrom<ComponentPart>
{
    public Guid Id { get; set; }



    public void Mapping(Profile profile)
    {
        profile.CreateMap<Component, GetComponentPartsVm>().ReverseMap();
    }
}