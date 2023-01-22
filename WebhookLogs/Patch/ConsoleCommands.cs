using Core.Enums;
using Exiled.API.Features;
using HarmonyLib;
using NorthwoodLib.Pools;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using WebhookLogs.API;

namespace WebhookLogs.Patch
{
    [HarmonyPatch(typeof(CommandProcessor), nameof(CommandProcessor.ProcessQuery))]
    public static class ConsoleCommands
    {
        [HarmonyPrefix]
        public static void Prefix(string q, CommandSender sender)
        {
            try
            {
                string[] args = q.Trim().Split(QueryProcessor.SpaceArray, 512, StringSplitOptions.RemoveEmptyEntries);
                if (args[0].StartsWith("$"))
                    return;

                Player player = sender is PlayerCommandSender playerCommandSender
                    ? Player.Get(playerCommandSender)
                    : Server.Host;

                if (player != null)
                    WebhookSender.AddMessage($"{sender.Nickname} ({sender.SenderId ?? "Srv"}) ha usado el comadndo >> **`{q}`**", WebhookType.ConsoleCommandLogs);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
