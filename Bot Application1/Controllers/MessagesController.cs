using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Utilities;
using Newtonsoft.Json;

namespace Bot_Application1
{
    // [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<Message> Post([FromBody]Message message)
        {
            if (message.Type == "Message")
            {
                string text = message.Text.ToLower();
                if (text.Contains("hello"))
                {
                    return message.CreateReplyMessage("hey there!");
                }
                if (text.Contains("c#"))
                {
                    if ((text.Contains("create") || text.Contains("make")) && text.Contains("object"))
                    {
                        return message.CreateReplyMessage("Ugh, why? How about a python object? I'm much better at those.");
                    }
                }
                else if (text.Contains("python"))
                {
                    if ((text.Contains("create") || text.Contains("make")) && text.Contains("object"))
                    {
                        return message.CreateReplyMessage("No problem. What kind of object would you like?");
                    }
                }

                return message.CreateReplyMessage("I didn't understand that... Sorry my english isn't that good.");
            }
            else
            {
                return HandleSystemMessage(message);
            }
        }

        private Message HandleSystemMessage(Message message)
        {
            if (message.Type == "Ping")
            {
                Message reply = message.CreateReplyMessage();
                reply.Type = "Ping";
                return reply;
            }
            else if (message.Type == "DeleteUserData")
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == "BotAddedToConversation")
            {
            }
            else if (message.Type == "BotRemovedFromConversation")
            {
            }
            else if (message.Type == "UserAddedToConversation")
            {
            }
            else if (message.Type == "UserRemovedFromConversation")
            {
            }
            else if (message.Type == "EndOfConversation")
            {
            }

            return null;
        }
    }
}