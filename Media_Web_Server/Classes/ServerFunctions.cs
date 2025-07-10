using System.IO.Pipes;

namespace Media_Web_Server.Classes
{
    partial class PanelSwitcherForm
    {
        public static void OpenPortForPath(string path) 
        {
            const string pipeName = "MediaRepoPipe";

            using (var pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut))
            {
                WriteLine("Connecting to client...");
                pipeClient.Connect(); //blocks until server is ready 

                WriteLine("Connected");
                int i = 0;
                using (var writer = new StreamWriter(pipeClient) { AutoFlush = true })
                using (var reader = new StreamReader(pipeClient))
                {
                    WriteLine(i);



                    // Send a message to the server
                    writer.WriteLine($"{path}");

                    // Read response from server
                    //trying to read here but MediaRepo closes
                    string response = reader.ReadLine();
                    Console.WriteLine("Server replied: " + response);
                    i++;
                    WriteLine(i);
                }
            }
        }   
    
    }
}
