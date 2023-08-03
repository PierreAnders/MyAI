using Microsoft.AspNetCore.Routing;
using MyAI.Configurations;
using MyAI.Services;

// Initialise un nouvel objet `WebApplicationBuilder` en utilisant les arguments
// fournis lors de l'exécution de l'application.
var builder = WebApplication.CreateBuilder(args);

// Configure le service `OpenAiConfig` en utilisant les valeurs trouvées
// dans la section "OpenAI" du fichier de configuration de l'application.
builder.Services.Configure<OpenAiConfig>(builder.Configuration.GetSection("OpenAI"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure le service `IOpenAiService` pour le résoudre en utilisant
// l'implémentation `OpenAiService` de façon à ce qu'une instance par
// requête soit créée.
builder.Services.AddScoped<IOpenAiService, OpenAiService>();

var app = builder.Build();

// Vérifie si l'application est en mode développement.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirige toutes les requêtes HTTP vers HTTPS.
app.UseHttpsRedirection();

// Ajoute le middleware pour gérer l'autorisation.
app.UseAuthorization();

// Configure le routage des contrôleurs
app.MapControllers();

// Exécute l'application.
app.Run();
