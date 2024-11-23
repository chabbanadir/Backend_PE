using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.MasterData;

public partial class Info : AuditableEntity
{
    public string? Name { get; set; }
    public string? CustomerPn { get; set; }
    public string? ProjectNumber { get; set; }

    public int ComponentsCount { get; set; }


    public Guid FK_OemId { get; set; }
    public Guid FK_HarnessmakerId { get; set; }
    public Guid FK_ComponentId { get; set; }

    public Guid FK_CableId { get; set; }

    public virtual Oem Oem { get; set; } = null!;
    public virtual Harnessmaker Harnessmaker { get; set; } = null!;

    public virtual Component Component { get; set; } = null!;
    public virtual Cable Cable { get; set; } = null!;

}

