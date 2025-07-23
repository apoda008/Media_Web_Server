using Media_Web_Server;
using Media_Web_Server.Components;
using System.Diagnostics;
//using System.IO.Pipes; //to open other apps

using System.Runtime.CompilerServices;
//Connect();
//MediaRepoConnection connect = new MediaRepoConnection();

//await connect.ConnectAsync();
//var result = connect.jsonResponse;

//=======================================================//
//////////     SERVER STUFF     ///////////////////////////

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();
builder.Services.AddSingleton<MediaRepoConnection>();

var app = builder.Build();

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
