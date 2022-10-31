using Curso.Prueba.Biblioteca.Application;
using Curso.Prueba.Biblioteca.Domain;
using Curso.Prueba.Biblioteca.Infraestructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<BibliotecaDbContext>();
builder.Services.AddTransient<IAutorRepository, AutorRepository>();
builder.Services.AddTransient<IAutorAppService, AutorAppSerivce>();
builder.Services.AddTransient<ILibroRepository, LibroRepository>();
builder.Services.AddTransient<ILibroAppService, LibroAppService>();
builder.Services.AddTransient<IEditorialRepository, EditorialRepository>();
builder.Services.AddTransient<IEditorialAppService, EditorialAppService>();


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
