using Microsoft.Extensions.Options;
using MyAI.Configurations;
using OpenAI_API.Models;

namespace MyAI.Services
{
    // Déclaration de la classe OpenAiService qui implémente l'interface IOpenAiService
    public class OpenAiService : IOpenAiService
    {
        // Déclaration de la variable de configuration _openAiConfig
        private readonly OpenAiConfig _openAiConfig;

        // Constructeur de la classe OpenAiService prenant en paramètre un optionsMonitor
        public OpenAiService(
            IOptionsMonitor<OpenAiConfig> optionsMonitor
        )
        {
            // Affectation de la valeur actuelle de la configuration à la variable _openAiConfig
            _openAiConfig = optionsMonitor.CurrentValue;
        }

        public async Task<string> ChatWithAI(string message)
        {
            // Création d'une instance de la classe OpenAIAPI avec une clé d'API en paramètre
            var api = new OpenAI_API.OpenAIAPI(_openAiConfig.Key);

            // Création d'une conversation de chat
            var chat = api.Chat.CreateConversation();

            // Ajout d'un message système à la conversation (comme une introduction)
            //chat.AppendSystemMessage($"Tu es un assistant spécialisé dans le langage C# et dans le framework Vue.js");

            // Ajout de la saisie de l'utilisateur à la conversation
            chat.AppendUserInput(message);

            // Obtenir une réponse du chatbot de manière asynchrone
            var response = await chat.GetResponseFromChatbotAsync();

            // Retourner la réponse
            return response;
        }
    }
}

// Ce code est une méthode asynchrone appelée `ChatWithAI` qui prend en paramètre un message (`string`) de l'utilisateur et retourne une réponse (`string`) du chatbot.
   
// Il utilise la classe `OpenAIAPI` du package OpenAI_API pour communiquer avec l'API OpenAI. La clé d'accès à l'API est fournie dans le constructeur de la classe `OpenAIAPI`. Vous devrez donc vous assurer de fournir la clé d'accès appropriée à cet endroit dans votre propre code.
   
// Ensuite, une conversation de chat est créée à l'aide de la méthode `CreateConversation` de l'instance API. Cette conversation de chat est utilisée pour échanger des messages avec le chatbot.
   
// Le code ajoute d'abord un message système à la conversation en utilisant la méthode `AppendSystemMessage`. Ce message est une introduction pour informer le chatbot de son rôle : un assistant spécialisé dans le langage C# et dans le framework Vue.js.
   
// Ensuite, la saisie de l'utilisateur est ajoutée à la conversation en utilisant la méthode `AppendUserInput`. Cette saisie sera traitée par le chatbot dans le contexte de la conversation.
   
// Enfin, la méthode `GetResponseFromChatbotAsync` est utilisée pour obtenir la réponse du chatbot de manière asynchrone. La réponse est ensuite retournée par la méthode.
   
// Notez que le code utilise le mot-clé `await` avant d'appeler la méthode `GetResponseFromChatbotAsync`. Cela signifie que l'appel à cette méthode est attendu de manière asynchrone, ce qui permet de libérer le thread actuel pendant l'attente de la réponse.
   
