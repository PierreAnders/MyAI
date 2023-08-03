namespace MyAI.Services
{
    // Déclaration de l'interface IOpenAiService
    public interface IOpenAiService
    {
        // Déclaration de la méthode ChatWithAI qui renvoie une tâche asynchrone contenant
        // une chaîne de caractères, avec un paramètre de type string nommé language.
        Task<string> ChatWithAI(string language);
    }
}
