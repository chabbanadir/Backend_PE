namespace Backend.Domain.Entities.DrawingGenerator;

public partial class PartNumber : AuditableEntity
{


    public string? BaseNumber { get; set; }
    public string? CustomerPn { get; set; }
    public string? ProjectNumber { get; set; }

    public int ComponentsCount { get; set; }


    public Guid FK_OemId { get; set; }
    public Guid FK_HarnessmakerId { get; set; }


    public virtual Oem Oem { get; set; } = null!;
    public virtual Harnessmaker Harnessmaker { get; set; } = null!;

}

