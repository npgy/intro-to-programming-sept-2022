using Microsoft.EntityFrameworkCore;
using PlaylistsApi.Adapters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(pol =>
{
    pol.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

builder.Services.AddScoped<IProvideTheSongCatalog, SongCatalog>();
builder.Services.AddDbContext<PlaylistsDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("songs"));
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dc = scope.ServiceProvider.GetRequiredService<PlaylistsDataContext>();
    dc.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
