using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var ws = new CoolWebSocket();            
            // when connected
            ws.OnOpen += () =>
            {
                Console.WriteLine("Connected to server");
            };
            // when a message is received, use messagetype to check if its binary or a text
            // and use ReadString() to parse if it is the case.
            ws.OnMessage += (messageType, message) =>
            {
                Console.WriteLine("Received the following message: " + ws.ReadString(message));
            };
            // when disconnected or kicked
            ws.OnClose += (closeStatus, closeMessage) => {
                Console.WriteLine($"Disconnected from server ({closeStatus}): {closeMessage}");
            };

            ws.Open(new Uri("wss://echo.websocket.org"));
            Console.WriteLine("Paused, press enter to continue");
            Console.ReadLine();
            
            ws.Close();
            Console.WriteLine("Paused, press enter to continue");
            Console.ReadLine();
        }
    }
}
