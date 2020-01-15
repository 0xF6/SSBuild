namespace SSBuild
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using RC.Framework;
    using Soul.Core.Rex;
    using Soul.Core.Types;

    internal class xInput
    {
        internal const string headerConsole = "§4 Soul§0 ";
        internal const string headerError = "§6 Error§0 ";
        internal static string versionBuild = "1.4";

        internal static List<string> IncludeAssembly = new List<string>();
        public static bool isStopCompile;

        private static void Main(string[] args)
        {
            //! Write Header SSBuild
            Terminal.WriteLine($"Version:{versionBuild}");
            Terminal.WriteLine($"Soul Sharp Builder.");
            Terminal.WriteLine($"Support §6 Runtime§0  Platform: dotnet §24.0§0, soul.core §2 1.0§0 .");
            Terminal.WriteLine($"Copyright (C) Of Fire Twins Wesp 2015");

            if (!args.Any())
            {
                return;
            }

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
            var rexIncludeAssembly = new Regex(RegexBase.MultiLine + RegexBase.PreProc.IncludeAssembly);
            var rexIncludeSoulHeader = new Regex(RegexBase.MultiLine + RegexBase.PreProc.IncludeSoulHeader);

            var mtAssembly = rexIncludeAssembly.Match(str);
            var mtHeader = rexIncludeSoulHeader.Match(str);
            return mtHeader.Success || mtAssembly.Success;
        }

        public static void ParseRegex(string str)
        { }

        public static void ErrorSyntax(SoulError er)
            => Terminal.WriteLine($"[{line}:{pos}]:{er.ConvertToString()}");
    }
}