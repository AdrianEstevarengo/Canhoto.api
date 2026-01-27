using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // Remova o "object value =" e apenas chame o método

// Configure CORS for frontend
var frontendOrigin = "http://localhost:8080";
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins(frontendOrigin).AllowAnyHeader().AllowAnyMethod();
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
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
