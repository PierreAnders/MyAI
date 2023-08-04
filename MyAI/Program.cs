using Microsoft.AspNetCore.Routing;
using MyAI.Configurations;
using MyAI.Services;

// Initialise un nouvel objet `WebApplicationBuilder` en utilisant les arguments
// fournis lors de l'ex�cution de l'application.
var builder = WebApplication.CreateBuilder(args);

// Configure le service `OpenAiConfig` en utilisant les valeurs trouv�es
// dans la section "OpenAI" du fichier de configuration de l'application.
builder.Services.Configure<OpenAiConfig>(builder.Configuration.GetSection("OpenAI"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure le service `IOpenAiService` pour le r�soudre en utilisant
// l'impl�mentation `OpenAiService` de fa�on � ce qu'une instance par
// requ�te soit cr��e.
builder.Services.AddScoped<IOpenAiService, OpenAiService>();

var app = builder.Build();

// V�rifie si l'application est en mode d�veloppement.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirige toutes les requ�tes HTTP vers HTTPS.
app.UseHttpsRedirection();

// Ajoute le middleware pour g�rer l'autorisation.
app.UseAuthorization();

// Configure le routage des contr�leurs
app.MapControllers();

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json", optional: true)
    .Build();

// Ex�cute l'application.
app.Run();
