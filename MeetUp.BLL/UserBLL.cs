using MeetUp.DAL;
using MeetUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.BLL
{
    public class UserBLL
    {
        Repository<Users> repo = new Repository<Users>();

        public Users GetUser(string email)
        {
            return repo.Find(x => x.Email == email);
        }

        public List<Users> GetUsers()
        {
            return repo.List();
        }

        public void Update(Users users)
        {
            repo.Update(users);
        }

        public void AddUser(Users user)
        {
            repo.Insert(user);
        }
    }
}
