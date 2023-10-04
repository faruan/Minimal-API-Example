using Microsoft.EntityFrameworkCore;
using Minimal_API_Example.Context;
using Minimal_API_Example.Domain.Entities;

namespace Minimal_API_Example.Presentation
{
    public static class CidadeController
    {
        public static void AddEndpoints(WebApplication app)
        {
            app.MapGet("/cidades", async (Contexto dbContext) => await dbContext.Cidades.ToListAsync());

            app.MapGet("/cidades/{id}", async (int id, Contexto dbContext) =>
                await dbContext.Cidades.FirstOrDefaultAsync(cidade => cidade.Id == id));

            app.MapPost("/cidades", async (CidadeEntity cidade, Contexto dbContext) =>
            {
                if (cidade != null)
                {
                    dbContext.Cidades.Add(cidade);
                    await dbContext.SaveChangesAsync();
                }

                return cidade;
            });

            app.MapPut("/cidades/{id}", async (int id, CidadeEntity cidade, Contexto dbContext) =>
            {
                var cidadeAtual = await dbContext.Cidades.FirstOrDefaultAsync(c => c.Id == id);
                if (cidadeAtual != null && cidadeAtual.Id == cidade.Id)
                {
                    dbContext.Entry(cidade).State = EntityState.Modified;
                    await dbContext.SaveChangesAsync();

                    return cidade;
                }

                return null;
            });

            app.MapDelete("/cidades/{id}", async (int id, Contexto dbContext) =>
            {
                var cidade = await dbContext.Cidades.FirstOrDefaultAsync(c => c.Id == id);
                if (cidade != null)
                {
                    dbContext.Cidades.Remove(cidade);
                    await dbContext.SaveChangesAsync();
                }

                return;
            });
        }
    }
}
