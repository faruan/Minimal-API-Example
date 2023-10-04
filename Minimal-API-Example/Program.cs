using Minimal_API_Example.IoC;
using Minimal_API_Example.Presentation;
using Minimal_API_Example.Presentation.Configuration;

var builder = WebApplication.CreateBuilder(args);

ConfigureBindingsDatabaseContext.RegisterBindings(builder);

var app = ApiConfig.AddApiConfiguration(builder);

CidadeController.AddEndpoints(app);

app.Run();