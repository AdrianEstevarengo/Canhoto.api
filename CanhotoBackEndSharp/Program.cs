using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Remova o "object value =" e apenas chame o método

// Configure CORS for frontend (allow the React dev servers)
builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy.WithOrigins(
            "http://localhost:5173",
            "http://localhost:8080",
            "http://localhost:8081"
        )
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

// Configure EF Core SQL Server
var connection = builder.Configuration.GetConnectionString("DefaultConnection") ?? "Server=(localdb)\\mssqllocaldb;Database=CanhotoDb;Trusted_Connection=True;MultipleActiveResultSets=true";
builder.Services.AddDbContext<CanhotoBackEndSharp.Data.ApplicationDbContext>(options =>
    options.UseSqlServer(connection)
);

// DI for repositories and services
builder.Services.AddScoped<CanhotoBackEndSharp.Repositories.IEntregaRepository, CanhotoBackEndSharp.Repositories.EntregaRepository>();
builder.Services.AddScoped<CanhotoBackEndSharp.Repositories.IOcorrenciaRepository, CanhotoBackEndSharp.Repositories.OcorrenciaRepository>();
builder.Services.AddScoped<CanhotoBackEndSharp.Services.IEntregaService, CanhotoBackEndSharp.Services.EntregaService>();
builder.Services.AddScoped<CanhotoBackEndSharp.Services.IOcorrenciaService, CanhotoBackEndSharp.Services.OcorrenciaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
// Enable developer exception page and Swagger UI for easier testing regardless of environment
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors("Frontend");

app.UseAuthorization();

app.MapControllers();

// Map a simple root endpoint that redirects to Swagger UI
app.MapGet("/", () => Results.Redirect("/swagger/index.html"));

app.Run();
