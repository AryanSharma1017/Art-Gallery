using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using art_gallery.Models;
using art_gallery.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using art_gallery.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
        builder.WithOrigins("http://localhost:3000", "https://662b54508fe6aa86796f39f2--aboriginalartgallery.netlify.app")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
});


builder.Services.AddControllers();

builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<ArtistService>();
builder.Services.AddSingleton<ExhibitionService>();
builder.Services.AddSingleton<ArtifactService>();
builder.Services.AddSingleton<ArtGalleryService>();
builder.Services.AddSingleton<ArtTypeService>();

builder.Services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions,BasicAuthenticationHandler>("BasicAuthentication", default);

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin"));

    options.AddPolicy("UserOnly", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin", "User"));

    options.AddPolicy("Generic", policy =>
        policy.RequireClaim(ClaimTypes.Role, "Admin", "User", "General"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();
app.MapControllers();

app.Run();

