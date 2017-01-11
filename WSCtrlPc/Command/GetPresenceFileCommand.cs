using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetPresenceFileCommand : Helper.HelperControle
    {
        public string GetPresenceFileCommandAction(string guid, string file)
        {
            if (OnlyHexInString(guid))
            {
                ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
                MyExecReqSqlReader.ExecuteReq(@"
EXEC CtrlPc.dbo.PS_FileManager '"+guid+@"','"+@file+@"'
");
                return MyExecReqSqlReader.result;
            }
            else
            {
                return "GUID KO";
            }
        }
    }
}
