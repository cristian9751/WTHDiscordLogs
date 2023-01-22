using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using WebhookLogs;

namespace Core.Enums
{
    public enum WebhookType
    {
        GameLogs,
        CommandLogs,
        ConsoleCommandLogs,
        KillLogs,
        JoinLogs,
        BanLogs,
    }

    public class LogMessage
    {
        public string content { get; set; }

        public LogMessage(string _content)
        {
            content = _content;
        }
    }

}
