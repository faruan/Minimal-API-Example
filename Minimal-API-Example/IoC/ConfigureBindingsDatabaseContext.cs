using Microsoft.EntityFrameworkCore;
using Minimal_API_Example.Context;

namespace Minimal_API_Example.IoC
{
    public static class ConfigureBindingsDatabaseContext
    {
        public static void RegisterBindings(WebApplicationBuilder builder)
        {
            //Injetando a dependência de dbcontext e sinalizando que vou utilizar InMemoryDabase
            builder.Services.AddDbContext<Contexto>(options => options.UseInMemoryDatabase("Cidades"));
        }
    }
}
