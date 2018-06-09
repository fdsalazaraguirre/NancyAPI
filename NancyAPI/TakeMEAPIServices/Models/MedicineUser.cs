namespace TakeMEAPIServices.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TakeMeDB.MedicineUsers")]
    public partial class MedicineUser
    {
        [Key]
        public int MedicineId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public float Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public sbyte Days { get; set; }

        public sbyte Hours { get; set; }

        public short DoseInitial { get; set; }

        public short? Dose { get; set; }

        [Column(TypeName = "bit")]
        public bool Enable { get; set; }

        [StringLength(50)]
        public string Comments { get; set; }

        [NotMapped]
        public virtual User User { get; set; }
    }
}
