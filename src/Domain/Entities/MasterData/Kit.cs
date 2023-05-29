namespace Backend.Domain.Entities.MasterData;

public partial class Kit : AuditableEntity
{

        public string? Name     { get; set; }
        public double Length    { get; set; }


        public int Position     { get; set; }
        
        public Guid FK_OemId { get; set; }
        public Guid? FK_PictureId { get; set; }


        public virtual Oem Oem { get; set; } = null!;
        public virtual Picture Picture { get; set; } = null!;

        public Status Status { get; set; }

}
