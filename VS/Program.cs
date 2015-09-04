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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SSBuild
{
    class Program
    {
        internal static string headerConsole = "+g4 Soul+g0 ";
        internal static string versionBuild = "1.4";

        internal static List<string> IncludeAssembly = new List<string>();
        static void Main(string[] args)
        {
            //! Write Header SSBuild
            Terminal.WriteLine($"Version:{versionBuild}", headerConsole);
            Terminal.WriteLine($"Soul Sharp Builder.", headerConsole);
            Terminal.WriteLine($"Support +g6 Runtime+g0  Platform: net.core +g2 4.0+g0 , soul.core +g2 1.0+g0 .", headerConsole);
            Terminal.WriteLine($"Copyright (C) Of Fire Twins Wesp 2015", headerConsole);
            //! End Write Header
            string code = File.ReadAllText("Code.soul");
            string[] ArrayCode = code.Replace("\r", "").Split('\n');
            List<LineProc> CodeData = new List<LineProc>();
            Regex rexIncludeAssembly = new Regex(RegexBase.MultiLine + RegexBase.PreProc.IncludeAssembly);
            foreach(Match Mt in rexIncludeAssembly.Matches(code))
            {
                LineProc Line = new LineProc();
                Line.Line = (ulong)Mt.Index;
                // Чертова математика..
                //x Line.Line = (ulong)Mt.Index - (ulong)Mt.Length + 1;
                //x Line.Line = (ulong)Mt.Index - (ulong)Mt.Index + 1;
                Line.Assembly = Mt.Value.Replace("#include ", "").Replace("<", "").Replace(">", "");
                CodeData.Add(Line);
                Terminal.WriteLine($"Include Assembly, Line:{Line.Line}, isSuccess:{Mt.Success}, Assembly:{Line.Assembly}");
            }
            Regex rexIncludeSoulHeader = new Regex(RegexBase.MultiLine + RegexBase.PreProc.IcludeSoulHeader);
            foreach (Match Mt in rexIncludeSoulHeader.Matches(code))
            {
                LineProc Line = new LineProc();
                Line.Line = (ulong)Mt.Index;
                Line.SoulHeader = Mt.Value.Replace("#include ", "").Replace("\"", "").Replace("\'", "");
                CodeData.Add(Line);
                Terminal.WriteLine($"Include Header, Line:{Line.Line}, isSuccess:{Mt.Success}, Header:{Line.SoulHeader}");
            }
            Parse(ArrayCode, ref CodeData);
        }

        public static void Parse(string[] strCode, ref List<LineProc> lst)
        {
            foreach(string src in strCode)
            {
                if (src[0] == ('#'))
                {

                }
                else if (src[0] == '/' && src[1] == '/')
                    break;
                else if (src.Contains("event"))
                {

                }

            }
        }
    }
}
