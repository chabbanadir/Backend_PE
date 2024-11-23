using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities.MasterData;
using CsvHelper.Configuration;

namespace Backend.Application.Features.MasterData.Components.Commands.ImportParts.ClassMap;

public class PartClassMap : ClassMap<ComponentPart>
{
    public PartClassMap()
    {
       // Map(x => x.CarrierNumber).Name("CarrierNumber");
        //Map(x => x.CarrierName).Name("CarrierName");
       // Map(x => x.CarrierDescription).Name("CarrierDescription");
    }
}