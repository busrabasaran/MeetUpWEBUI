using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetUp.WEBUI.Models
{
    public class MessageModel
    {
        public int? ToUserID { get; set; }

        public int? FromUserID { get; set; }

        public string Message { get; set; }

        public string Mail { get; set; }
        
    }
}