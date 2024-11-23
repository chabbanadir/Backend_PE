using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Entities.MasterData;

namespace Backend.Domain.Entities.Tools;

public partial class Picture : AuditableEntity
{
    public string? Name { get; set; }
    public string? PicPath { get; set; }


    public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    public virtual ICollection<Component> Components { get; set; } = new HashSet<Component>();
    public virtual ICollection<Config> Configurations { get; set; } = new HashSet<Config>();

   // public override string ToString() =>$"site.com/{PicPath}";

}
