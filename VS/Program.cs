// =========================================================================//==============================================================//
//                                                                          //                                                              //
//                                                                          //             Copyright © Of Fire Twins Wesp 2015              //
// Author= {"Callada", "Another"}                                           //                                                              //
// Project="Soul.Language"                                                  //                  Alise Wesp & Yuuki Wesp                     //
// Version File="1.0"                                                       //                                                              //
// License="root\\LICENSE", LicenseType="MIT"                               //                                                              //
// =========================================================================//==============================================================//
using Rc.Framework;
using Soul.Core;
using Soul.Core.Rex;
using Soul.Core.Types;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SSBuild
{
    class xInput
    {
        internal const string headerConsole = "+g4 Soul+g0 ";
        internal const string headerError = "+g6 Error+g0 ";
        internal static string versionBuild = "1.4";

        internal static List<string> IncludeAssembly = new List<string>();
        internal static bool isStopCompile;

        static void Main(string[] args)
        {
            //! Write Header SSBuild
            Terminal.WriteLine($"Version:{versionBuild}", headerConsole);
            Terminal.WriteLine($"Soul Sharp Builder.", headerConsole);
            Terminal.WriteLine($"Support +g6 Runtime+g0  Platform: net.core +g2 4.0+g0 , soul.core +g2 1.0+g0 .", headerConsole);
            Terminal.WriteLine($"Copyright (C) Of Fire Twins Wesp 2015", headerConsole);
            //! End Write Header
            Parse(args[0]);
        }

        public static int line = 0;
        public static int pos = 0;

        public static void Parse(string FileName)
        {
            // Read
            using (StreamReader stream = File.OpenText(FileName))
            {
                S_START:
                string linecode = stream.ReadLine();
                line++;
                if (isRegexData(linecode))
                {
                    ParseRegex(linecode);
                    goto S_START;
                }
            }
        }
        public static bool isRegexData(string str)
        {
            Regex rexIncludeAssembly = new Regex(RegexBase.MultiLine + RegexBase.PreProc.IncludeAssembly);
            Regex rexIncludeSoulHeader = new Regex(RegexBase.MultiLine + RegexBase.PreProc.IcludeSoulHeader);

            Match mtAssembly = rexIncludeAssembly.Match(str);
            Match mtHeader = rexIncludeSoulHeader.Match(str);
            if (mtHeader.Success || mtAssembly.Success)
                return true;
            else
                return false;
        }
        public static void ParseRegex(string str)
        { }
        public static void ErrorSyntax(SoulError er)
        {
            Terminal.WriteLine($"[{line}:{pos}]:{er.ConvertToString()}", xInput.headerError);
        }
    }
}
