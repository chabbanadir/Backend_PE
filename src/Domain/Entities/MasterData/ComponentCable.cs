

namespace Backend.Domain.Entities.MasterData;

public partial class ComponentCable : AuditableEntity
{
    public Guid FK_ComponentId { get; set; }
    public virtual Component Component { get; set; } 

    public Guid? FK_CableId { get; set; }
    public virtual Cable Cable { get; set; }

}
