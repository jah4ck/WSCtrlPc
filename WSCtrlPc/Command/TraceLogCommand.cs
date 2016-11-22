using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class TraceLogCommand
    {
        public void TraceLogAction(string guid, DateTime dateTraitement, string codeappli, int codeerreur, string description)
        {
            if (description.Contains("'"))
            {
                description = description.Replace("'", "''");
            }
            string requete = @"
DECLARE @GUID varchar(50);
DECLARE @DATETRAITEMENT varchar(50);
DECLARE @CODEAPPLI varchar(50);
DECLARE @CODEERREUR int;
DECLARE @DESCRIPTION varchar(max);

SET @GUID='"+guid+@"';
SET @DATETRAITEMENT='"+dateTraitement.ToString("yyyy-MM-dd HH:mm:ss.FF")+@"';
SET @CODEAPPLI='"+codeappli+@"';
SET @CODEERREUR="+codeerreur+@";
SET @DESCRIPTION='"+description+@"';

INSERT INTO [CtrlPc].[dbo].[JOURNAL]
           ([ID_GUID]
           ,[DATE_TRAITEMENT]
           ,[CODE_APPLI]
           ,[CODE_ERREUR]
           ,[DESCRITION])
     VALUES
           ((SELECT ID_GUID FROM [CtrlPc].[dbo].[GUID] WHERE [GUID]=@GUID)
           ,@DATETRAITEMENT
           ,(SELECT ID_APPLI FROM [CtrlPc].[dbo].[APPLICATION] WHERE [LIBELLE]=@CODEAPPLI)
           ,@CODEERREUR
           ,@DESCRIPTION)
";
            ExecReqSqlNoQuery MyExecReqSqlNoQuery = new ExecReqSqlNoQuery();
            MyExecReqSqlNoQuery.ExecuteReq(requete);
        }
    }
}
