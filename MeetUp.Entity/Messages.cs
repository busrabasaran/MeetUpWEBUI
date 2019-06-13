namespace MeetUp.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Messages
    {
        [Key]
        public int MessageID { get; set; }

        public int? FromUserID { get; set; }

        public int? ToUserID { get; set; }

        public string Body { get; set; }

        public DateTime? Date { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }
    }
}
