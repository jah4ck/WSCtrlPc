using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetExceptionCommand
    {
        public string GetExceptionCommandAction(string guid)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
DECLARE @guid varchar(50);
SET @guid='"+guid+@"';

SELECT [EXCEPTION].[EXCEPTION]
FROM [CtrlPc].[dbo].[EXCEPTION]
INNER JOIN [CtrlPc].[dbo].[GUID]
ON [EXCEPTION].[ID_GUID]=[GUID].[ID_GUID]
WHERE [GUID].[GUID]=@guid
");
            return MyExecReqSqlReader.result;
        }
    }
}
