using LabStreamer.Application.Contas.Profile;
using LabStreamer.Application.Contas;
using LabStreamer.Repository;
using LabStreamer.Repository.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner.
builder.Services.AddControllers();

// Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("LabStreamerConnection");


builder.Services.AddDbContext<LabStreamerContext>(options =>
{
    // Defina a montagem de migra��es correta aqui
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LabStreamer.Api"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);


//Repositories
builder.Services.AddScoped<UsuarioRepository>();
//builder.Services.AddScoped<PlanoRepository>();
//builder.Services.AddScoped<BandaRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();
//builder.Services.AddScoped<BandaService>();

var app = builder.Build();

// Configure o pipeline de solicita��o HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
