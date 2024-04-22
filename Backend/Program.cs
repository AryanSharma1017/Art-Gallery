using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using art_gallery.Models;
using art_gallery.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder =>
    {
        builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ArtistService>();
builder.Services.AddSingleton<ExhibitionService>();
builder.Services.AddSingleton<ArtifactService>();
builder.Services.AddSingleton<ArtGalleryService>();
builder.Services.AddSingleton<ArtTypeService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseCors("AllowAnyOrigin");

app.UseAuthorization();
app.MapControllers();

app.Run();

