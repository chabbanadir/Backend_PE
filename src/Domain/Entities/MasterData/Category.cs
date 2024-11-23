

namespace Backend.Domain.Entities.MasterData;

   public partial class Category : AuditableEntity
    {
        public string? Name { get; set; }

        public bool HasNote { get; set; }
        public bool HasCable { get; set; }
        public bool HasConfig { get; set; }

        public Status Status { get; set; }

        public Guid? FK_PictureId { get; set; }
        public virtual Picture Picture { get; set; } = null!;
        public virtual ICollection<Component> Components { get; set; } = new HashSet<Component>();

}


