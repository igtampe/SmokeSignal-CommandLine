﻿using System;
using System.IO;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokeSignal {
    public class ServerCommand {

        public const string DEFAULT_IP = "127.0.0.1";
        public const int DEFAULT_PORT = 797;

        public static string RawCommand(String Message,String IP,int Port) {

            //Set up a few things
            TcpClient TC = new TcpClient();
            NetworkStream NS;
            BinaryReader BR;
            BinaryWriter BW;

            //Set the default server response
            String ServerMSG = "E";

            //make sure we have a message and an IP. We don't have to check if the port is empty because int cannot be null
            if(String.IsNullOrEmpty(Message)||String.IsNullOrEmpty(IP)) { throw new ArgumentNullException("I need something to send and somewhere to send it and I don't have one of them."); }

            //Try to connect. The only real exception that should occur here is socketexception.
            try {TC.Connect(IP,Port);} catch(SocketException) {throw new Exception("Unable to connect to the server");}

            //If we managed to connect, which we should've but just in case...
            if(TC.Connected) {
                NS=TC.GetStream();
                BR=new BinaryReader(NS);
                BW=new BinaryWriter(NS);


            
            }



            return null;
        }

    }
}
