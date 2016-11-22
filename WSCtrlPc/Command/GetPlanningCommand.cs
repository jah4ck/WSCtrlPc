using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetPlanningCommand
    {
        public string GetPlanningCommandAction(string guid)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
SELECT 
      [DATE_DEBUT]
      ,[DATE_FIN]
  FROM [CtrlPc].[dbo].[PLANNING]
  INNER JOIN [CtrlPc].[dbo].[GUID]
  ON [PLANNING].[ID_GUID]=[GUID].[ID_GUID]
  WHERE [GUID].[GUID] = '"+guid+@"'
  AND (DATE_DEBUT between getdate()-1 and getdate()+7
  OR DATE_FIN between getdate()-1 and getdate()+7)
  ORDER BY DATE_DEBUT ASC
");
            return MyExecReqSqlReader.result;
        }
    }
}
