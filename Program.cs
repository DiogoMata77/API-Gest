using Microsoft.EntityFrameworkCore;
using APIGest.Data;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);


//Para criar uma base de dados temporaria e guardar os dados inseridos
//builder.Services.AddDbContext<ApiContext>(options =>
//    options.UseInMemoryDatabase("InMemoryDb"));


//Para defenir uma coneccao com uma base de dadoss
builder.Services.AddDbContext<ApiContext>(options =>
//Serve para adicionar uma conecção real a base de dados atraves da comnecção adicionada ao ficheiro json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


//Para definir o verisonamento de uma api
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);//Define uma versão padrao
    options.AssumeDefaultVersionWhenUnspecified = true; // Assume a versão padrão se não for especificada
    options.ReportApiVersions = true; // Informa as versões de suporte na cabeçalho 

});


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen( option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "API Gest",
        Description = "Manipular todos os dados da aplicação Gest"
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();

    //Configuarar a rota default
    app.UseSwaggerUI( c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "APIGest v1"));
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();