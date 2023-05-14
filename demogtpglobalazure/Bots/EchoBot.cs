// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.18.1

using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace demogtpglobalazure.Bots
{
    public class EchoBot : ActivityHandler
    {
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string openaiApiKey = "";
            string prompt = turnContext.Activity.Text;

            string response = await GetCompletion(openaiApiKey, prompt);

            if (response != null)
            {
                await turnContext.SendActivityAsync(MessageFactory.Text(response), cancellationToken);
            }
            else
            {
                await turnContext.SendActivityAsync(MessageFactory.Text("Estamos teniendo un problema de comunicacion con el servidor. Por favor, volver a intentar mas tarde."), cancellationToken);
            }
        }

        private static async Task<string> GetCompletion(string openaiApiKey, string prompt)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", openaiApiKey);
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var requestData = new
            {
                model = "gpt-3.5-turbo",
                messages = new[] { new { role = "user", content = prompt } }
            };

            var response = await httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", requestData);
            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseObj = JObject.Parse(responseJson);
                var choices = responseObj["choices"] as JArray;
                var message = choices?[0]["message"]["content"].ToString();
                return message;
            }
            else
            {
                return $"Error: {response.StatusCode}";
            }
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
