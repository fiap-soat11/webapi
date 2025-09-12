using Microsoft.OpenApi.Models;
using WebAPI.Configurations;


var builder = WebApplication.CreateBuilder(args);

// Add UseCases to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
        });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Lanchonete FIAP-SOAT11",
        Description = "ASP.NET Core Web API Para o sistema de fastfood da Lanchonete FIAP-SOAT11.",
        Contact = new OpenApiContact
        {
            Name = "Grupo 140 da SOAT11",
            Url = new Uri("https://github.com/fiap-soat11")
        },
        License = new OpenApiLicense
        {
            Name = "Página do Projeto",
            Url = new Uri("https://github.com/fiap-soat11"),
        }
    });
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    options.JsonSerializerOptions.WriteIndented = true; // opcional
});

builder.Services.AddHttpClient();
builder.Services.AddInfraStructure(builder.Configuration);
//builder.Services.AddBusinessServices(builder.Configuration);
//builder.Services.AddServiceMercadoPagoStructure(builder.Configuration);
builder.Services.AddValidators(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

var supportedCultures = new[] { "pt-BR", "br" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
