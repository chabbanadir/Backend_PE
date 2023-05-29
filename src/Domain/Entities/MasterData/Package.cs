using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.MasterData;

public class Package : AuditableEntity
{
    public string? Layer { get; set; }
    public string? PN { get; set; }
    public string? Qte { get; set; }
    public int Order { get; set; }
    public Status Status { get; set; }


}
