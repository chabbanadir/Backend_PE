namespace Backend.Domain.Entities.MasterData;

   public partial class Cable : AuditableEntity
{

    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? Description { get; set; }


    public Guid FK_OemId { get; set; }
    public virtual Oem Oem { get; set; } = null!;

    public Status Status { get; set; }


    public virtual ICollection<ComponentCable> Components { get; set; } = null!;

    public virtual ICollection<Info> Infos { get; set; } = new HashSet<Info>();
}


