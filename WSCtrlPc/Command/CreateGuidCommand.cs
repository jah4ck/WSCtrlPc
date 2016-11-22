using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class CreateGuidCommand
    {
        public void CreateGuidAction(string hostname, string guid, string identifiant, string version)
        {
            string requete = @"
DECLARE @GUID varchar(50);
DECLARE @VERSION varchar(10);
DECLARE @HOSTNAME varchar(500);
DECLARE @IDENTIFIANT varchar(500);

SET @GUID='"+guid+@"';
SET @VERSION='"+version+@"';
SET @HOSTNAME='"+hostname+@"';
SET @IDENTIFIANT='"+identifiant+@"';

IF EXISTS (SELECT * FROM [CtrlPc].[dbo].[GUID] WHERE [GUID]=@GUID)
BEGIN
	UPDATE [CtrlPc].[dbo].[GUID]
	SET [VERSION]=@VERSION, [DATE_MODIFICATION]=GETDATE()
	WHERE [GUID]=@GUID
END
ELSE
BEGIN
	INSERT INTO [CtrlPc].[dbo].[GUID]
           ([ID_USER]
           ,[GUID]
           ,[HOTSNAME]
           ,[VERSION])
     VALUES
           ((SELECT ID_USER FROM [CtrlPc].[dbo].[USER] WHERE EMAIL=@IDENTIFIANT)
           ,@GUID
           ,@HOSTNAME
           ,@VERSION)
END

";
            ExecReqSqlNoQuery MyExecReqSqlNoQuery = new ExecReqSqlNoQuery();
            MyExecReqSqlNoQuery.ExecuteReq(requete);
        }
    }
}
