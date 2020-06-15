using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicRender;

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

            String Message = args[2];
            bool Verbose = false;
            if(args.Length>=3&&args[2].ToUpper()=="/D") { Verbose=true; }







            //ok first things first
            foreach(string arg in args) {Render.Echo(arg,true);}
            Render.Pause();






        }

        public static void IncorectSyntaxWarning() {Render.Echo("Incorrect Syntax. See SMOKESIGNAL /? for more help.");}



        /// <summary>Draws the help screen</summary>
        public static void HelpScreen() {

            DrawHeader();

            Render.Echo(".");
            Render.Echo("Sends a message to a SmokeSignal Server and displays a response.",true);
            Render.Echo(".");
            Render.Echo("SMOKESIGNAL IP:Port Message [/D]",true);
            Render.Echo(".",true);
            Render.Echo("  IP:Port        Specifies the IP/PORT to send the message to",true);
            Render.Echo("  Message        Message to send to the server",true);
            Render.Echo("  /D             Enables Verbose Mode",true);
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
