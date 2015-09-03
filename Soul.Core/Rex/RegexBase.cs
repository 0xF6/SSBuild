using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Soul.Core.Rex
{
    public class RegexBase
    {
        public Regex rex_method = new Regex("/{(.*?)};/Us", RegexOptions.Compiled);
        public class PreProc
        {
            public const string IncludeAssembly = "(^#(include )(<[a-zA-Z].*\\.dll>))"; // Include All Assembly
            public const string IcludeSoulHeader = "(^#(include )(['][a-zA-Z].*\\.sh[']))";
        }

        public const string REX_BRECKET_SQAER_MULTILINE = "(?<=\\[)[^\\[\\]]+(?=\\])";
        public const string REX_BRECKET_SQARE_ONLYLINE_ARRAY = "\\[([^,\\]]+),([^,\\]]+)\\]";
    }
}
