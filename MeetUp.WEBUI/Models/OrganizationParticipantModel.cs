using MeetUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUp.WEBUI.Models
{
    public class OrganizationParticipantModel
    {
        public Organizations organizations { get; set; }

        public int ParticipantNumber { get; set; }

        public Users users { get; set; }
    }
}