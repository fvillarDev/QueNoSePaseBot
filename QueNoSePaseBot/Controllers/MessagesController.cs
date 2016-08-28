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

namespace QueNoSePaseBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                Activity reply = activity.CreateReply("Disculpe, no hemos podido procesar su consulta. Verifique que los datos sean correctos");
                int state = 0;

                if (activity.Attachments.Count > 0)
                {
                    reply = activity.CreateReply("Disculpe, sólo se aceptan mensajes de texto");
                    state = 1;
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
                    reply = activity.CreateReply("Ups.. Mensaje vacío!");
                    state = 2;
                }

                if (state == 0)
                {
                    var newMsg = BotHelper.BotHelper.ParseMessage(activity);
                    reply = activity.CreateReply();
                    reply.Attachments = new List<Attachment>();
                    var actions = new List<CardAction>
                    {
                        new CardAction
                        {
                            Title = "Ver Paradas Cercanas",
                            Value = newMsg,
                            Type = ActionTypes.OpenUrl
                        }
                    };
                    reply.AttachmentLayout = AttachmentLayoutTypes.List;
                    reply.Attachments.Add(
                        new HeroCard
                        {
                            Title = "Click para ver las Paradas Cercanas",
                            Images = new List<CardImage>(),
                            Buttons = actions
                        }.ToAttachment()
                    );
                }

                await connector.Conversations.ReplyToActivityAsync(reply);
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
    }
}