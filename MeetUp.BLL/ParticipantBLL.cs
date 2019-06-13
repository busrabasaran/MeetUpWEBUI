using MeetUp.DAL;
using MeetUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.BLL
{
    public class ParticipantBLL
    {
        Repository<Participants> repo = new Repository<Participants>();

        public List<Participants> GetParticipantOrganizations(int id)
        {
            return repo.List(x=> x.UserID==id);
        }

        public List<Participants> GetParticipantsList(int id)
        {
            return repo.List(x => x.OrganizationID == id );
        }

        public void JoınOrganization(Participants participant)
        {
            repo.Insert(participant);
        }

        public Participants GetParticipants(int participantid)
        {
            return repo.Find(x => x.ParticipantID == participantid);
        }

        public void JoınOrganizationUpdate(Participants participant)
        {
            repo.Update(participant);
        }

        public void DeleteParticipant(int id)
        {
            Participants participant = repo.Find(x => x.ParticipantID == id);
            repo.Delete(participant);
        }
    }
}
