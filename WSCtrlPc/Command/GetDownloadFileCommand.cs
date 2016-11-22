using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetDownloadFileCommand
    {
        public string GetDownloadFileCommandAction(string guid,DateTime date)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
DECLARE @guid varchar(50);
DECLARE @date datetime;

SET @guid='"+guid+@"';
SET @date='"+date.ToString("yyyyMMdd")+@"';

SELECT [FILE_UPLOAD].[DESTINATION],[FILE_UPLOAD].[SOURCE]
FROM [CtrlPc].[dbo].[FILE_UPLOAD]
INNER JOIN [CtrlPc].[dbo].[GUID]
ON [FILE_UPLOAD].ID_GUID=[GUID].[ID_GUID]
WHERE [GUID].[GUID]=@guid
AND [FILE_UPLOAD].[DATE_UPLOAD]<=CAST(@date as date)
AND [FILE_UPLOAD].[UPLOADED]=0
");
            return MyExecReqSqlReader.result;
        }
    }
}
