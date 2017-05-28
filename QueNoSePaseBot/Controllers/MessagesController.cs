using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;
using QueNoSePaseBot.BotHelper;
using QueNoSePase.API.Controllers;
using QueNoSePaseBot.Models;

namespace QueNoSePaseBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        private HorariosController _horariosController;
        private ParadasCercanasController _paradasCercanasController;
        public MessagesController()
        {
            _horariosController = new HorariosController();
            _paradasCercanasController = new ParadasCercanasController();
        }

        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                try
                {
                    //if(activity.ChannelData != null)
                        //LogHelper.LogAsync(JsonConvert.SerializeObject(activity.ChannelData), "MessagesController_Post", "ChannelData", "fvillar");

                    ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));

                    Activity isTyping = activity.CreateReply();
                    isTyping.Type = ActivityTypes.Typing;
                    await connector.Conversations.ReplyToActivityAsync(isTyping);

                    Activity reply =
                        activity.CreateReply(
                            GetNoMsgRandom());
                    int state = 0;

                    if (activity.Attachments != null && activity.Attachments.Count > 0)
                    {
                        reply = activity.CreateReply("Disculpe, sólo se aceptan mensajes de texto");
                        state = 1;
                    }
                    
                    if (state == 0 && activity.Entities.Count > 0 && activity.ChannelData != null)
                    {
                        //LogHelper.LogAsync(JsonConvert.SerializeObject(activity.Entities), "MessagesController_Post", "Entities", "fvillar");

                        var d = JsonConvert.DeserializeObject<TelegramChannelData>(activity.ChannelData.ToString());

                        if (d != null)
                        {
                            string loc = d.message.location.latitude.ToString().Replace(".", ",");
                            loc += ";";
                            loc += d.message.location.longitude.ToString().Replace(".", ",");
                            string msg = BotHelper.BotHelper.ParseLocation(loc, _paradasCercanasController);
                            //reply = activity.CreateReply("Latitude: " + d.message.location.latitude + ", Longitude: " + d.message.location.longitude);
                            reply = activity.CreateReply(msg);
                        }
                        else
                        {
                            reply = activity.CreateReply("Disculpe, no he podido procesar su consulta. Intenta nuevamente más tarde");
                        }
                        state = 2;
                    }

                    if (string.IsNullOrEmpty(activity.Text) && state == 0)
                    {
                        //CardAction action = new CardAction
                        //{
                        //    Type = "openUrl",
                        //    Title = "Ver Paradas Cercanas",
                        //    Value = "http://map.quenosepase.com.ar/?user=-33.5650168;-64.8363918&paradas=1,Linea%2010,C1234,-31.387147;-64.217691|2,Linea%2022,C4444,-31.384493;-64.200605"
                        //};
                        //activity.Attachments.Add(new Attachment
                        //{

                        //});
                        reply = activity.CreateReply("Ups.. Mensaje vacío!\nPrueba mandando el número de parada");
                        state = 2;
                    }                    

                    if (state == 0)
                    {
                        var newMsg = BotHelper.BotHelper.ParseMessage(activity, _horariosController);
                        reply = activity.CreateReply(newMsg);
                    }

                    await connector.Conversations.ReplyToActivityAsync(reply);
                }
                catch (Exception ex)
                {
                    LogHelper.LogAsync(ex, "MessagesController_BotHelper", (activity != null ? activity.Text : ""), (activity != null ? activity.From.Name : ""));
                }
            }
            else
            {
                HandleSystemMessage(activity);
            }
            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels

            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
                Activity reply = message.CreateReply();
                reply.Type = "Ping";
                return reply;
            }

            return null;
        }

        private string GetNoMsgRandom()
        {
            return Models.Constants.NO_MSG[new Random().Next(0, Models.Constants.SALUDOS.Count)];
        }
    }
}