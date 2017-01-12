using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class SetResetPresenceCommand : Helper.HelperControle
    {
        public SetResetPresenceCommand(string guid)
        {
            if (OnlyHexInString(guid))
            {
                ExecReqSqlNoQuery MyExecReqSqlNoQuery = new ExecReqSqlNoQuery();
                MyExecReqSqlNoQuery.ExecuteReq(@"
UPDATE CtrlPc.dbo.FILE_UPLOAD SET PRESENCE=0 WHERE ID_GUID=(SELECT ID_GUID FROM CtrlPc.dbo.GUID WHERE GUID='" + @guid + @"')
");
               
            }
            
        }

    }
}
