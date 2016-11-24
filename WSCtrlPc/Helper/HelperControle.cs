using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WSCtrlPc.Helper
{
    public class HelperControle
    {
        public bool OnlyHexInString(string test)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(test, @"\A\b[0-9a-fA-F]+\b\Z");
        }
    }
}
