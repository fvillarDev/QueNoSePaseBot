using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QueNoSePaseBot.Models
{
    public class TelegramChannelData
    {
        public string update_id { get; set; }
        public ChannelMessage message { get; set; }
    }

    public class ChannelMessage
    {
        public int message_id { get; set; }
        public ChannelLocation location { get; set; }
    }

    public class ChannelLocation
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
    }
}