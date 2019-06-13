using MeetUp.DAL;
using MeetUp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetUp.BLL
{
    public class MessagesBLL
    {
        Repository<Messages> repo = new Repository<Messages>();

        public List<Messages> GetMessages()
        {
            return repo.List();
        }

        public Messages GetMessage(int id)
        {
            return repo.Find(x => x.MessageID == id);
        }

        public List<Messages> GetMessagesList(int id)
        {
            return repo.List(x => x.ToUserID == id || x.FromUserID == id);
        }

        public List<Messages> GetMessageList(string email)
        {
            return repo.List(x => x.Users.Email == email);
        }

        public void AddMessage(Messages message)
        {
            repo.Insert(message);
        }

        public void DeleteMessage(int id)
        {
            Messages message = repo.Find(x => x.MessageID == id);
            repo.Delete(message);
        }

    }
}
