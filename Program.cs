using System;
using BasicRender;
using SmokeSignal;

namespace SmokeSignal_CommandLine {
    class Program {
        public static void Main(string[] args) {
            
            //checks before we do
            if(args.Length==0||args[0]=="/?") { HelpScreen(); return; }
            if(args.Length==1) { IncorectSyntaxWarning(); return; }

            //Check the received string
            String[] IPPortCombo = args[0].Split(':');
            if(IPPortCombo.Length!=2) { IncorectSyntaxWarning(); return; }

            //get these cositas
            String IP = IPPortCombo[0];
            int Port;
            if(!int.TryParse(IPPortCombo[1],out Port)) { IncorectSyntaxWarning(); return; }

            //Get the message, including any of those after that may have been separated due to spaces.
            String Message = args[1];
            for(int X = 2; X<args.Length; X++) {Message+=" "+args[X];}

            //Echo the return of the server.
            try { Render.Echo(ServerCommand.RawCommand(Message,IP,Port)); } catch(Exception E) { Render.Sprite(E.Message,ConsoleColor.Black,ConsoleColor.Red); }
        }

        public static void IncorectSyntaxWarning() {Render.Echo("Incorrect Syntax. See SMOKESIGNAL /? for more help.");}

        /// <summary>Draws the help screen</summary>
        public static void HelpScreen() {

            DrawHeader();

            Render.Echo(".");
            Render.Echo("Sends a message to a SmokeSignal Server and displays a response.",true);
            Render.Echo(".");
            Render.Echo("SMOKESIGNAL IP:Port Message",true);
            Render.Echo(".",true);
            Render.Echo("  IP:Port        Specifies the IP/PORT to send the message to",true);
            Render.Echo("  Message        Message to send to the server",true);
            Render.Echo(".");
        }

        /// <summary>Draws the smokesignal header</summary>
        public static void DrawHeader() {
            
            //give us some space
            Render.Echo(".");

            //save these as a reference to where the cursor was when we started drawing
            int Left = Console.CursorLeft;
            int Top = Console.CursorTop;
            BasicGraphic SmokeLogo = new SmokeSignalLogo();

            //Actually draw the header
            SmokeLogo.draw(Left,Top);
            Render.Sprite("SmokeSignal Command Line [Version 1.0]",ConsoleColor.Black,ConsoleColor.White,Left+SmokeLogo.GetWidth()+1,Top+1);
            Render.Sprite("(C)2020 Igtampe, No rights reserved",ConsoleColor.Black,ConsoleColor.White,Left+SmokeLogo.GetWidth()+1,Top+2);
            
            //Leave the cursor *about* where it should be.
            Render.SetPos(Left+SmokeLogo.GetWidth(),Top+SmokeLogo.GetHeight());

        }


    }
}
