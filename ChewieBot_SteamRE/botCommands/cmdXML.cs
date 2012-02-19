//////////////////////////////////////////////////////////////////////////////////
//                                                                              //
// Please read LICENSE.TXT for License Information                              //
//                                                                              //
// ChewieBot: A Steam Chat Bot used to kick players or run other commands       //
// via PHP scripts                                                              //
//                                                                              //
// Thanks to VoiDeD and SteamRE https://bitbucket.org/VoiDeD/steamre/overview   //
// for the Steam Client API                                                     //
//                                                                              //
// Written by c355n4 nhrules (at) hotmail.com                                   // 
//                                                                              // 
//////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace ChewieBot_SteamRE
{
    class cmdXML
    {
        private XElement _xml;

        public void LoadXMLFile()
        {
            string fileloc = Environment.CurrentDirectory + "\\settings.xml";
            if (File.Exists(fileloc))
            {
                _xml = XElement.Load(fileloc);
            }
        }

        /// <summary>
        /// Checks if this command exists
        /// </summary>
        /// <param name="command">line from chat</param>
        /// <returns></returns>
        public bool isCommand(string command)
        {
            return ((_xml.Elements("Command").Any(u => command == u.Element("ChatCommand").Value)) || (command == "!commands"));
        }

        /// <summary>
        /// Checks if this command exists for the ChatSteamID
        /// </summary>
        /// <param name="command">line from chat</param>
        /// <param name="ChatSteamID">SteamID of Chat</param>
        /// <returns></returns>
        public bool isCommand(string command, string ChatSteamID)
        {
            return ((_xml.Elements("Command").Any(u => command == u.Element("ChatCommand").Value && u.Element("ChatSteamID").Value == ChatSteamID)) || (command == "!commands"));
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="command">line from chat</param>
        /// <returns>Returns string to echo back to chat</returns>
        public string parseCommand(string command)
        {
            string retVal = string.Empty;

            if (command == "!commands")
            {
                retVal = listCommands();
            }
            else
            {
                var cmd = (from page in _xml.Elements("Command")
                           where command == page.Element("ChatCommand").Value
                           select page).FirstOrDefault();

                //TODO: check query for no results.  Though, this should never happen...

                if (cmd.Element("CommandType").Value == "Chat")
                {
                    retVal = cmd.Element("ChatReply").Value;
                }
                else if (cmd.Element("CommandType").Value == "URL")
                {
                    execURL execute = new execURL();
                    retVal = execute.executeCommand(cmd.Element("URL").Value);
                }
            }
            

            //string v = (from page in _xml.Elements("Command") where command == page.Element("ChatCommand").Value select page.Element("ChatReply").Value).FirstOrDefault();

            return retVal;
        }

        /// <summary>
        /// Execute command
        /// </summary>
        /// <param name="command">line from chat</param>
        /// <param name="ChatSteamID">SteamID of Chat</param>
        /// <returns>Returns string to echo back to chat</returns>
        public string parseCommand(string command, string ChatSteamID)
        {
            string retVal = string.Empty;

            if (command == "!commands")
            {
                retVal = listCommands(ChatSteamID);
            }
            else
            {
                var cmd = (from page in _xml.Elements("Command")
                           where command == page.Element("ChatCommand").Value && ChatSteamID == page.Element("ChatSteamID").Value
                           select page).FirstOrDefault();

                //TODO: check query for no results.  Though, this should never happen...

                if (cmd.Element("CommandType").Value == "Chat")
                {
                    retVal = cmd.Element("ChatReply").Value;
                }
                else if (cmd.Element("CommandType").Value == "URL")
                {
                    execURL execute = new execURL();
                    retVal = execute.executeCommand(cmd.Element("URL").Value);
                }
            }

            //string v = (from page in _xml.Elements("Command") where command == page.Element("ChatCommand").Value select page.Element("ChatReply").Value).FirstOrDefault();

            return retVal;
        }

        /// <summary>
        /// Internal function to return list of commands
        /// </summary>
        /// <returns></returns>
        private string listCommands()
        {
            string retVal = string.Empty;

            var cmd = (from page in _xml.Elements("Command") select page);

            foreach (XElement x in cmd)
            {
                retVal += (x.Element("ChatCommand").Value + " ");
            }

            return retVal;
        }

        /// <summary>
        /// Internal function to return list of commands for Chat specified by ChatSteamID
        /// </summary>
        /// <param name="ChatSteamID">SteamID of Chat</param>
        /// <returns></returns>
        private string listCommands(string ChatSteamID)
        {
            // TODO: fix for multiple chatrooms

            string retVal = string.Empty;

            var cmd = (from page in _xml.Elements("ChatCommand") where page.Element("ChatSteamID").Value == ChatSteamID select page);

            foreach (XElement x in cmd)
            {
                retVal += (x.Element("ChatCommand").Value + " ");
            }

            return retVal;
        }
    }
}
