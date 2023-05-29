namespace Backend.Domain.Entities.MasterData;

   public partial class Config : AuditableEntity
   {
       public string? Name { get; set; }
       public double Length { get; set; }
       public int Position { get; set; }
       public Status Status { get; set; }
       public Orientation Orientation { get; set; }


       public Guid FK_OemId { get; set; }
       public Guid FK_NoteId { get; set; }
       public Guid? FK_PictureId { get; set; }


        public virtual Oem Oem { get; set; }
        public virtual Note Note { get; set; }
        public virtual Picture Picture { get; set; }
        
        public virtual ICollection<Component> Components { get; set; } = null!;
}


