using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetArretCommand
    {
        public string GetArretCommandAction(string guid)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
SELECT ARRET
FROM CtrlPc.dbo.FORCE_ARRET
INNER JOIN CtrlPc.dbo.GUID
ON FORCE_ARRET.ID_GUID=GUID.ID_GUID
WHERE GUID.GUID='"+guid+@"'
");
            return MyExecReqSqlReader.result;
        }
    }
}
