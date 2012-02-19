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

namespace ChewieBot_SteamRE
{
    class cmdProtected
    {
        /// <summary>
        /// Check for Protected Commands
        /// </summary>
        /// <param name="command">line from chat</param>
        /// <returns></returns>
        public string parseCommand(string command)
        {
            string retVal = string.Empty;

            switch (command)
            {
                case "!version":
                    retVal = "ChewieBot_SteamRE v3.1 - cessna / https://github.com/cessna/ChewieBot_SteamRE";
                    break;
            }

            return retVal;
        }
    }
}
