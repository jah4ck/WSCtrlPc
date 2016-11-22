using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class SetDownloadFileCommand
    {
        public void SetDownloadFileCommandAction(string guid,DateTime date,string dest,string source)
        {
            ExecReqSqlNoQuery MyExecReqSqlNoQuery = new ExecReqSqlNoQuery();
            MyExecReqSqlNoQuery.ExecuteReq(@"
DECLARE @guid varchar(50);
DECLARE @date datetime;
DECLARE @dest varchar(50);
DECLARE @source varchar(50);

SET @guid='"+guid+@"';
SET @date='"+date.ToString("yyyyMMdd")+@"';
SET @dest='"+dest+@"';
SET @source='"+source+@"';

UPDATE [CtrlPc].[dbo].[FILE_UPLOAD]
SET [UPLOADED]=1, [DATE_UPLOADED]=@date
FROM [CtrlPc].[dbo].[FILE_UPLOAD]
INNER JOIN [CtrlPc].[dbo].[GUID]
ON [FILE_UPLOAD].ID_GUID=[GUID].[ID_GUID]
WHERE [GUID].[GUID]=@guid
AND [FILE_UPLOAD].[DATE_UPLOAD]<=CAST(@date as date)
AND [FILE_UPLOAD].[UPLOADED]=0
AND [FILE_UPLOAD].[DESTINATION]=@dest
AND [FILE_UPLOAD].[SOURCE]=@source
");
        }
    }
}
