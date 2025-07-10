using Media_Web_Server.Components;
using System.Diagnostics;
using System.IO.Pipes; //to open other apps
using Media_Web_Server.Classes;

//TEMP 

Application.EnableVisualStyles();
//Application.Run(new MyForm());

PanelSwitcherForm pathGetter = new PanelSwitcherForm();
Application.Run(pathGetter);



return 0;



//Application.EnableVisualStyles();
//Application.Run(new MyForm());




















//=======================================================//
//////////     SERVER STUFF     ///////////////////////////

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

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
