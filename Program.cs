using ArticulosAPI;
using ArticulosAPI.Data;
using ArticulosAPI.Repositorio; // <--- NUEVO
using AutoMapper;                // <--- NUEVO
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Conexión a la base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// AutoMapper
var mapperConfig = MappingConfig.RegisterMaps(); // <--- NUEVO
IMapper mapper = mapperConfig.CreateMapper();    // <--- NUEVO
builder.Services.AddSingleton(mapper);           // <--- NUEVO
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // <--- NUEVO

// Repositorio
builder.Services.AddScoped<IArticuloRepositorio, ArticuloRepositorio>(); // <--- NUEVO

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
