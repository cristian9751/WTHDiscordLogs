using Core.Enums;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine.Networking;
using Utf8Json;
using Exiled.API.Features;

namespace WebhookLogs.API
{
    public class WebhookSender
    {
        public static void AddMessage(string content, WebhookType type)
        {
            content = $"<t:{((DateTimeOffset)DateTime.Now).ToUnixTimeSeconds()}:T> " + content;
            MsgQueue[type].Add(content);
        }

        
        private static IEnumerator<float> SendMessage(LogMessage message, WebhookType type)
        {
            string url = WebhookLogs.Singleton.Config.Webhooks[type];

            if (string.IsNullOrWhiteSpace(url))
                yield break;

            UnityWebRequest webRequest = new(url, UnityWebRequest.kHttpVerbPOST);
            UploadHandlerRaw uploadHandler = new(JsonSerializer.Serialize(message));
            uploadHandler.contentType = "application/json";
            webRequest.uploadHandler = uploadHandler;

            yield return Timing.WaitUntilDone(webRequest.SendWebRequest());

            if (webRequest.isNetworkError || webRequest.isHttpError)
            {
                Log.Error($"Error al mandar el mensaje: {webRequest.responseCode} - {webRequest.error}");
            }
        }
        public static IEnumerator<float> ManageQueue()
        {
            while (true)
            {
                foreach (KeyValuePair<WebhookType, List<string>> webhook in MsgQueue)
                {
                    StringBuilder builder = new("");

                    foreach (string message in webhook.Value.ToList())
                    {
                        if (builder.Length + message.Length < 2000)
                        {
                            builder.AppendLine(message);
                            MsgQueue[webhook.Key].Remove(message);
                        }
                        else
                        {
                            break;
                        }
                    }

                    string content = builder.ToString();

                    if (string.IsNullOrWhiteSpace(content))
                        continue;

                    yield return Timing.WaitUntilDone(Timing.RunCoroutine(SendMessage(new LogMessage(builder.ToString()), webhook.Key)));
                }

                yield return Timing.WaitForSeconds(10);
            }
        }

        private static readonly Dictionary<WebhookType, List<string>> MsgQueue = new() { [WebhookType.CommandLogs] = new List<string>(), [WebhookType.GameLogs] = new List<string>(), [WebhookType.KillLogs] = new List<string>(), [WebhookType.ConsoleCommandLogs] = new List<string>(), [WebhookType.JoinLogs] = new List<string>(), [WebhookType.BanLogs] = new List<string>() };
    }
}
