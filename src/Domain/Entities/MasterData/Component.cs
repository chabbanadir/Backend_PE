namespace Backend.Domain.Entities.MasterData;

   public partial class Component : AuditableEntity
{

    // TODO EXPORT DETAILS TABLE minimize this fk code 
    public string? Name { get; set; }
    public string? TE_PN { get; set; }
    public string? Customer_PN { get; set; }
    public string? PDM_LINK_PN { get; set; }
    public string? Rev { get; set; }
    public string? Description { get; set; }
    public double Length { get; set; }
    public int Position { get; set; }

    public ShowIn ShowIn { get; set; }
    public Status Status { get; set; }
    public Orientation Orientation { get; set; }


    public Guid FK_OemId { get; set; }
    public Guid FK_CategoryId { get; set; }
    public Guid? FK_ConfigId { get; set; }

    /* public Guid? FK_ParentComponentId { get; set; } */
    public Guid? FK_PictureId { get; set; }
    //public Guid? FK_CableId { get; set; }


    public virtual Oem Oem { get; set; } = null!;
    public virtual Category Category { get; set; } = null!;

    /* public virtual Component component { get; set; } = null!; */
    public virtual Config Config { get; set; } = null!;
    public virtual Picture Picture { get; set; } = null!;

    /* public virtual ICollection<Component> ComponentChilds { get; set; } = new HashSet<Component>(); */


    public virtual List<ComponentCable> Cables { get; set; } = null!;
    public virtual List<ComponentPart> Parts { get; set; } = null!;
    public virtual List<ComponentPart> PartsOf { get; set; } = null!;

    public virtual ICollection<Info> Infos { get; set; } = new HashSet<Info>();
}


