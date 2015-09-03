using Rc.Framework;
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
            
            Regex r = new RegexBase().rex_method;
            string sdahd =
                @"
                #include <Soul.dll>
                // REGEX TEST BVEAASDASDASD
                {WHILE(true) {asdasd}};
                foreach(string src in strCode)
                {
                    if (src[0] == ('#'))
                    {}
                    else if (src[0] == '/' && src[1] == '/')
                        break;
                };
                ";
            MatchCollection col = Regex.Matches(sdahd, "(?m)" + RegexBase.PreProc.IncludeAssembly);
            foreach (Match mt in col)
            {
                string str = mt.Value;
            }


            string code = File.ReadAllText("cad.soul");
            string[] ArrayCode = code.Split('\n');

            Parse(ArrayCode);
        }

        public static void Parse(string[] strCode)
        {
            bool isMethod;
            bool isEvent;
            string NameMethod;
            string TypeClassMethod;
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
