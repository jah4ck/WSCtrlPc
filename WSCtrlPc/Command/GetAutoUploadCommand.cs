using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetAutoUploadCommand : Helper.HelperControle
    {
        public string GetAutoUploadAction(string guid)
        {
            if (OnlyHexInString(guid))
            {
                ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
                MyExecReqSqlReader.ExecuteReq(@"
EXEC CtrlPc.dbo.PS_AutoUpload '"+@guid+@"'
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
