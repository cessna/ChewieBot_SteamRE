Read LICENSE.TXT for License Information

ChewieBot_SteamRE - Written by cessna

Version 3.1 - 2/18/2012:
settings.txt is now obsolete.  Commands are stored in settings.XML.  
Currently there is support for two types of XML command.
- "Chat" - Just returns string found in "ChatReply" 
- "URL" - Executes the page and returns string 

Protected commands like !version have been added

Version 3.0 - 2/17/2012:
New version/rewrite of ChewieBot written to use the new SteamRE API.  
Backward compatibility with the old ChewieBot settings.txt. 
Old version of ChewieBot can be found here: https://github.com/Hadlock/ChewieBot

FUTURE:
- Ability to join multiple chat channels (stored in XML file)
- Queueing of Commands 
- Parsing of flags for commands (ie, !kick thatguy)
- Include ability to use web service for commands and ditch the old php calls  

POSSIBLE?:
- Administration of bot via steam chat with authorized users
- Other bot chat capability