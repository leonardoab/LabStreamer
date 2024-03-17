using LabStreamer.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using LabStreamer.Application.Profile;
using LabStreamer.Repository.Context;
using LabStreamer.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Adicione serviços ao contêiner.
builder.Services.AddControllers();

// Saiba mais sobre como configurar o Swagger/OpenAPI em https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("LabStreamerConnection");


builder.Services.AddDbContext<LabStreamerContext>(options =>
{
    // Defina a montagem de migrações correta aqui
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("LabStreamer.Api"));
});

builder.Services.AddAutoMapper(typeof(AlbumProfile).Assembly);
builder.Services.AddAutoMapper(typeof(BandaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(ListaFavoritaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(MusicaProfile).Assembly);
builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);


//Repositories
builder.Services.AddScoped<AlbumRepository>();
builder.Services.AddScoped<BandaRepository>();
builder.Services.AddScoped<ListaFavoritaRepository>();
builder.Services.AddScoped<MusicaRepository>();
builder.Services.AddScoped<UsuarioRepository>();


//Services
builder.Services.AddScoped<AlbumService>();
builder.Services.AddScoped<BandaService>();
builder.Services.AddScoped<ListaFavoritaService>();
builder.Services.AddScoped<MusicaService>();
builder.Services.AddScoped<UsuarioService>();
//builder.Services.AddScoped<BandaService>();

var app = builder.Build();

// Configure o pipeline de solicitação HTTP.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
