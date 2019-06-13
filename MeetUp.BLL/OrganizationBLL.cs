using MeetUp.DAL;
using MeetUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.BLL
{
    public class OrganizationBLL
    {
        Repository<Organizations> repo = new Repository<Organizations>();

        public List<Organizations> GetOrganizations()
        {
            return repo.List();
        }

        public void AddOrganization(Organizations organization)
        {
            repo.Insert(organization);
        }

        public Organizations GetOrganization(int Organizationid)
        {
            return repo.Find(x => x.OrganizationID == Organizationid);
        }

       
    }
}
