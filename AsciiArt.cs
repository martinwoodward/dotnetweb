using System;
using System.Collections.Generic;
using System.Linq;


namespace dotnetweb
{
    public static class AsciiArt
    {
        // Distance between Mona and dotnet-bot
        private const int SPACING = 26;
        // Start column for speech bubble
        private const int SPEECH_COL = 33;

        //// str - the source string
        //// index- the start location to replace at (0-based)
        //// length - the number of characters to be removed before inserting
        //// replace - the string that is replacing characters
        public static string ReplaceAt(this string str, int index, string replace)
        {
            return str.Remove(index, Math.Min(replace.Length, str.Length - index))
                    .Insert(index, replace);
        }         
       
       public static string CreateDotnetMona(string message)
       {
           string space = new String(' ', SPACING);
           string[] art = new string[] {
                "         MMM.           .MMM       " + space + "                        (O)",
                "         MMMMMMMMMMMMMMMMMMM       " + space + "                        ||",
                "         MMMMMMMMMMMMMMMMMMM       " + space + "                 .DDDDDDDDDDDDDDDD.",
                "        MMMMMMMMMMMMMMMMMMMMM      " + space + "              .DDDDDDDDDDDDDDDDDDDDDD.",
                "       MMMMMMMMMMMMMMMMMMMMMMM     " + space + "           .DDDDDDDDDDDDDDDDDDDDDDDDDDDD.",
                "      MMMMMMMMMMMMMMMMMMMMMMMM     " + space + "          .'DDDDDDDDDDDDDDDDDDDDdDD'  DDDD.",
                "      MMMM::- -:::::::- -::MMMM    " + space + "          :  .DDDDD.'.DDDDDDDDD         DDD.",
                "       MM~:~ 00~:::::~ 00~:~MM     " + space + "          :    _            __        .DDDDD.",
                "  .. MMMMM::.00:::+:::.00::MMMMM .." + space + "         .:    0            00        .DDDDD.",
                "        .MM::::: ._. :::::MM.      " + space + "        .DDD       ^                 .DDDDD.",
                "           MMMM;:::::;MMMM         " + space + "        .DDDD.  .DDDDD.          .DDDDDDDDDDD.",
                "    -MM        MMMMMMM             " + space + "        .DDDDDDDDDDDDDDDDDDDDDDDDDDDDDDD'  .DDDDD.",
                "    ^  M+     MMMMMMMMM            " + space + "     .DDDDDDDDDDD#NET#DDDDDDDDDDDdDDDDD'     .DDDDD.",
                "        MMMMMMM MM MM MM           " + space + "  .DDDDDD.    .DdDDDDDDDDDDDDDDDDdDDDD.      .DDDDDDDD.",
                "             MM MM MM MM          " + space + ".DD'DDDDDD     DDDDDD. .DDDDDDDD....DD.         .DDDDD.",
                "             MM MM MM MM        " + space + ".dDDDDb       .DDDD'D.               .D'DDDD.",
                "          .~~MM~MM~MM~MM~~.        " + space + "         .DDDDDD'D.               .D'DDDDDDD.",
                "       ~~~~MM:~MM~~~MM~:MM~~~~     " + space + "      .DDDDDDDDD'D.               'D'DDDDDDDDD.",
                "      ~~~~~~==~==~~~==~==~~~~~~    " + space + "    .DDDDDDDDDDD'D.               'D'DDDDDDDDDDD.",
                "       ~~~~~~==~==~==~==~~~~~~     " + space + "   .DDDDDDDDDDDDD.                 D'DDDDDDDDDDD.",
                "           :~==~==~==~==~~         " + space + "     .DDDDDD."
                };
           if (!String.IsNullOrEmpty(message))
           {
               int messageMinLength = 3;
               if (message.Length < messageMinLength)
               {
                   message = message.PadRight(messageMinLength,' ');
               }
               // Add a speech bubble               
               art[2] = art[2].ReplaceAt(SPEECH_COL + 1, new String('_',message.Length+2));
               art[3] = art[3].ReplaceAt(SPEECH_COL,"|" + new String(' ',message.Length+2) + "|");
               art[4] = art[4].ReplaceAt(SPEECH_COL,"| " + message + " |");
               art[5] = art[5].ReplaceAt(SPEECH_COL,"|_   " + new String('_',message.Length -2) + "|");
               art[6] = art[6].ReplaceAt(SPEECH_COL + 2,"|/");
           } 
            
           return String.Join('\n',art);
       }

    }    
}