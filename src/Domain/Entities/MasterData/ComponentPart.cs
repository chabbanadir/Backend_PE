using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.MasterData;

public partial class ComponentPart : AuditableEntity
{
    public Guid FK_ComponentId { get; set; }
    public virtual Component Component { get; set; } // parent & child 

    public Guid? FK_PartId { get; set; }
    public virtual Component Part { get; set; }

}
