using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace ChewieBot_SteamRE
{
    class execURL
    {
        public string executeCommand(string url)
        {
            string returnMessage = string.Empty;

            string webURL = url;
            int count = 0;
            byte[] chewieBuf = new byte[8192];
            string htmlClear = @"<(.|\n)*?>";

            WebRequest request;
            WebResponse response;
            Stream stream;

            try
            {
                request = WebRequest.Create(webURL);

                response = request.GetResponse();
                stream = response.GetResponseStream();

                do
                {
                    count = stream.Read(chewieBuf, 0, chewieBuf.Length);

                    if (count != 0)
                    {
                        returnMessage = Encoding.ASCII.GetString(chewieBuf, 0, count);
                    }
                }
                while (count > 0);
                try
                {
                    // clean up the string removing html parses

                    foreach (Match match in Regex.Matches(returnMessage, htmlClear))
                        returnMessage = Regex.Replace(returnMessage, htmlClear, "");
                }
                catch (Exception)
                {
                }
            }
            catch (Exception)
            {
                // TODO: Timeouts?
                //Console.WriteLine(ex.ToString());
                //returnMessage = "Command Failed";
                //Console.WriteLine("Command " + message + " has an invalid url.");
            }

            return returnMessage;
        }
    }
}
