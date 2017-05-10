using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetHeartbeatCommand
    {
        public string GetHeartbeatCommandAction(string guid, DateTime date)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
SELECT CtrlPc.dbo.VerifArret('" + guid + "',CONVERT(DATETIME,'" + date.ToString("yyyy-MM-dd HH:mm:ss") + @"',120))
");
            return MyExecReqSqlReader.result;
        }
    }
}
