namespace Minimal_API_Example.Presentation.Configuration
{
    public static class ApiConfig
    {
        public static WebApplication AddApiConfiguration(WebApplicationBuilder builder)
        {
            //Adicionando Swagger para documentação da API
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                //Ativando o swagger
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            return app;
        }
    }
}
