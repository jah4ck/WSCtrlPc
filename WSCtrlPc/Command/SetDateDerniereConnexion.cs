using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class SetDateDerniereConnexion : Helper.HelperControle
    {
        
        public SetDateDerniereConnexion(string guid)
        {
            if (OnlyHexInString(guid))
            {
                ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
                MyExecReqSqlReader.ExecuteReq(@"
UPDATE [CtrlPc].[dbo].[GUID]
SET [DATE_DERNIERE_CONNEXION]=getdate()
WHERE [GUID]='" + guid + @"'
");
            }
           
        }
    }
}
