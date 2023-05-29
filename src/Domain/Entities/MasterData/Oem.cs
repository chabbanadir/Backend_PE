namespace Backend.Domain.Entities.MasterData;

public class Oem : AuditableEntity
{

    public string? Name { get; set; }
    public Status Status { get; set; }


    public virtual ICollection<Cable> Cables { get; set; } = new HashSet<Cable>();
    public virtual ICollection<Component> Components { get; set; } = new HashSet<Component>();
    public virtual ICollection<PartNumber> PartNumbers { get; set; } = new HashSet<PartNumber>();
    public virtual ICollection<Info> Infos { get; set; } = new HashSet<Info>();
    public virtual ICollection<Config> Configs { get; set; } = new HashSet<Config>();

}


