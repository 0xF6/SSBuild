using Soul.Core.Build;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Soul.Core.Types
{
    public enum PreProcessor : short
    {
        pInclude = 0x1,
        pPragma = 0x2,
        pLock = 0x3
    }
    public enum KeyWord
    {
        pAlias,
        pAbstract,
        pVoid,
        pEvent,
        pThis,
        pIf,
        pElse,
        pInt,
        pLong
    }
    public enum KeyOperators
    {
        Plus,
        Minus,
        Equals,
        And,
        Or
    }
    public class Operators
    {

    }
    public class Type
    {
        
    }
    public class PreProc
    {
        public static BuildStackMessage TryParce(string str, out PreProcessor p, int line)
        {
            try
            {
                p = (PreProcessor)Enum.Parse(typeof(PreProcessor), $"p{str}", true);
                return new BuildStackMessage(line, $"", TypeBuild.Complete);
            }
            catch
            {
                p = 0;
                return new BuildStackMessage(line, $"", TypeBuild.Error);
            }
        }
    }
}
