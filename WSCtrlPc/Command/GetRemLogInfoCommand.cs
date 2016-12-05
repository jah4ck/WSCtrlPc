using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetRemLogInfoCommand
    {
        public string GetRemLogInfoCommandAction(string guid)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
DECLARE @string varchar(5);
DECLARE @status int;
DECLARE @statusparam int;
DECLARE @type int;
DECLARE @IdGuid int;

SELECT @IdGuid=[ID_GUID]
FROM [CtrlPc].[dbo].[GUID]
WHERE [GUID]='"+guid+@"'

SELECT 
		@status=[PARAM_HISTO_JOURNAL].[ID_STATUS],
		@statusparam=[PARAM_HISTO_JOURNAL].[ID_STATUS_PARAM],
		@type=[PARAM_HISTO_JOURNAL].[ID_TYPE]
FROM [CtrlPc].[dbo].[PARAM_HISTO_JOURNAL]
WHERE [ID_GUID]=@IdGuid
AND [PARAM_HISTO_JOURNAL].[DATE] = cast(GETDATE() as date)

SET @string = cast(@status as varchar)+';'+cast(@statusparam as varchar)+';'+cast(@type as varchar)

IF LEN(@string)>3
BEGIN
	select @string
END
ELSE
BEGIN
	INSERT INTO [CtrlPc].[dbo].[PARAM_HISTO_JOURNAL]
	SELECT [PARAM_JOURNAL].ID_PARAM_JOURNAL,[PARAM_JOURNAL].ID_GUID,[PARAM_JOURNAL].ID_STATUS,[PARAM_JOURNAL].ID_STATUS,[PARAM_JOURNAL].ID_TYPE,cast(getdate() as date),0,0,[PARAM_JOURNAL].NB_INSERT_LIGNE,null,getdate()
	FROM [CtrlPc].[dbo].[PARAM_JOURNAL]	
	WHERE [ID_GUID]=@IdGuid

	SELECT 
		@status=[PARAM_HISTO_JOURNAL].[ID_STATUS],
		@statusparam=[PARAM_HISTO_JOURNAL].[ID_STATUS_PARAM],
		@type=[PARAM_HISTO_JOURNAL].[ID_TYPE]
	FROM [CtrlPc].[dbo].[PARAM_HISTO_JOURNAL]
	WHERE [ID_GUID]=@IdGuid
	AND [PARAM_HISTO_JOURNAL].[DATE] = cast(GETDATE() as date)

	SET @string = cast(@status as varchar)+';'+cast(@statusparam as varchar)+';'+cast(@type as varchar)

	SELECT @string
END
");
            return MyExecReqSqlReader.result;
        }
    }
}
