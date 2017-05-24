using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace QueNoSePaseBot.BotHelper
{
    public class LogHelper
    {
        public static void LogAsync(Exception ex, string controller = "", string request = "", string user = "")
        {
            var data = new LogData
            {
                ControllerName = controller,
                ErrorMessage = ex != null ? ex.ToString() : "",
                Request = request,
                UserName = user
            };
            Thread t = new Thread(delegate(object o)
            {
                if (o is LogData)
                {
                    var d = (LogData)o;
                    DataHelper.ExecuteNonQuery("ErrorsLog_Insert", d.ControllerName, d.ErrorMessage, d.Request, d.UserName);
                }
            });
            t.Start(data);
        }

        public static void LogAsync(string msg, string controller = "", string request = "", string user = "")
        {
            var data = new LogData
            {
                ControllerName = controller,
                ErrorMessage = msg,
                Request = request,
                UserName = user
            };
            Thread t = new Thread(delegate (object o)
            {
                if (o is LogData)
                {
                    var d = (LogData)o;
                    DataHelper.ExecuteNonQuery("ErrorsLog_Insert", d.ControllerName, d.ErrorMessage, d.Request, d.UserName);
                }
            });
            t.Start(data);
        }

        private class LogData
        {
            public string ErrorMessage { get; set; }
            public string ControllerName { get; set; }
            public string Request { get; set; }
            public string UserName { get; set; }
        }
    }
}