using System.Collections.Generic;
using Core.Enums;
using System.ComponentModel;
using Exiled.API.Interfaces;
using System.Web;

namespace WebhookLogs
{
    public  class Config : IConfig
    {
        [Description("¿Plugin activado?: ")]
        public bool IsEnabled { get; set; } = true;
        [Description("Debug: ")]
        public bool Debug { get; set; } = true;
        public Dictionary<WebhookType, string> Webhooks { get; set; } = new()
        {
            [WebhookType.CommandLogs] = "Url Webhook para logs de comandos",
            [WebhookType.GameLogs] =  "Url Webhook para logs del juego",
            [WebhookType.ConsoleCommandLogs] = "Url Webhook para logs de commandos de consola",
            [WebhookType.KillLogs] = "Url Webhook para logs de kill y danyo",
            [WebhookType.JoinLogs] = "Url para logs de servidor y rondas",
            [WebhookType.BanLogs] = "Url del webhook para mostrar los bans del servidor"
        };
    }
}
