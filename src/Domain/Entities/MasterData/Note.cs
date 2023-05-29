namespace Backend.Domain.Entities.MasterData;

   public partial class Note : AuditableEntity
{


    public string? Name { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
    public NoteType NoteType { get; set; }
    public Status Status { get; set; }


    public virtual ICollection<Config> Configs { get; set; } = new HashSet<Config>();

}


