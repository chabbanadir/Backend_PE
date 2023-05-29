using Backend.Application.Common.Mappings;
using Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail.Dtos;
using Backend.Domain.Entities.MasterData;
using Backend.Domain.Enums;

namespace Backend.Application.Features.MasterData.Oems.Queries.GetOemDetail;

public class OemDetailVm : IMapFrom<Oem>
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Status Status { get; set; }


    /*    public virtual ICollection<PartNumberDto> PartNumbers { get; set; } = new HashSet<PartNumberDto>();
        public virtual ICollection<ConfigDto> Configs { get; set; } = new HashSet<ConfigDto>();*/
    /*    public int ComponentsCount { get; set; }
        public int CablesCount  { get; set; }*/

    // ready dtos
/*    public virtual ICollection<ComponentDto> Components { get; set; } = new HashSet<ComponentDto>();
    public virtual ICollection<CableDto> Cables { get; set; } = new HashSet<CableDto>();*/


}
