

namespace Backend.Domain.Entities.MasterData;

   public partial class Harnessmaker : AuditableEntity
{

      public string? Name { get; set; }
      public string? Manufacturing_code { get; set; }
      public string? Bar_code { get; set; }
        public Status Status { get; set; }


    public virtual ICollection<PartNumber> PartNumbers { get; set; } = new HashSet<PartNumber>();
    public virtual ICollection<Info> Infos { get; set; } = new HashSet<Info>();

}


