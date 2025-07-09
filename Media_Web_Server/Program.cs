using Media_Web_Server.Components;
using Media_Web_Server.Components;
using System.Diagnostics;
using System.IO.Pipes; //to open other apps


const string pipeName = "MediaRepoPipe";

using (var pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut))
{
    WriteLine("Connecting to client...");
    pipeClient.Connect(); //blocks until server is ready 

    WriteLine("Connected");

    using (var writer = new StreamWriter(pipeClient) { AutoFlush = true })
    using (var reader = new StreamReader(pipeClient))
    {
        // Send a message to the server
        writer.WriteLine("Hello from client!");

        // Read response from server
        //trying to read here but MediaRepo closes
        string response = reader.ReadLine();
        Console.WriteLine("Server replied: " + response);
    }
}






















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
