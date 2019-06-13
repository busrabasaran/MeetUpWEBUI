namespace MeetUp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Participants
    {
        [Key]
        public int ParticipantID { get; set; }

        public int? OrganizationID { get; set; }

        public int? UserID { get; set; }

        public int? NumberofPeople { get; set; }

        public DateTime? Date { get; set; }

        public virtual Organizations Organizations { get; set; }

        public virtual Users Users { get; set; }
    }
}
