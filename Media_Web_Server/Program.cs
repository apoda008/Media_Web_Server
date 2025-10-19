using Media_Web_Server;
using Media_Web_Server.Components;
using System.Diagnostics;
//using System.IO.Pipes; //to open other apps

using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddScoped<MediaRepoConnection>();  

//builder.Services.AddSingleton<MediaRepoConnection>();

var app = builder.Build();
app.MapControllers();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>();

app.Run();
//Moving to a new build. I have forgotten most of this and it isnt in the standard MCV template