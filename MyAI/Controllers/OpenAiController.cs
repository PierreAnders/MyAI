using Microsoft.AspNetCore.Mvc;
using MyAI.Services;

namespace MyAI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OpenAiController : ControllerBase
    {
        // Déclaration d'une variable pour le journaliseur
        private readonly ILogger<OpenAiController> _logger;

        // Déclaration d'une variable pour le service OpenAI
        private readonly IOpenAiService _openAiService;

        // Constructeur du contrôleur avec injection de dépendances
        public OpenAiController(

            // ILogger pour l'enregistrement des journaux (logs)
            ILogger<OpenAiController> logger,

            // Service OpenAI pour effectuer des actions spécifiques
            IOpenAiService openAiService)
        {

            // Stocke l'instance du ILogger dans une variable de classe
            _logger = logger;

            // Stocke l'instance du service OpenAI dans une variable de classe
            _openAiService = openAiService;
        }

        [HttpPost()]
        [Route("ChatWithAI")]

        // Appel du service OpenAI pour obtenir une réponse à partir du message
        public async Task<IActionResult> AskQuestion(string message)
        {
            // Appel du service OpenAI pour obtenir une réponse à partir du message
            var result = await _openAiService.ChatWithAI(message);

            // Retourne un code HTTP 200 (OK) avec le résultat
            return Ok(result);
        }
    }
}

// Le journaliseur(logging en anglais) est un mécanisme utilisé dans le développement
// de logiciels pour enregistrer des informations sur l'exécution du programme. 
// Il sert à collecter des données concernant les erreurs, les événements, 
// les transactions et autres activités importantes. Le journaliseur est 
// un outil essentiel pour le débogage, la surveillance et l'analyse des 
// applications.