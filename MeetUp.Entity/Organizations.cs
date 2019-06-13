namespace MeetUp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Organizations
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organizations()
        {
            Participants = new HashSet<Participants>();
        }

        [Key]
        public int OrganizationID { get; set; }

        public int? UserID { get; set; }

        [StringLength(50)]
        public string OrganizationName { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(50)]
        public string Place { get; set; }

        public DateTime? ApplicationStartDate { get; set; }

        public int? TotalParticipantNumber { get; set; }

        public string Image { get; set; }

        public string Details { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participants> Participants { get; set; }
    }
}
