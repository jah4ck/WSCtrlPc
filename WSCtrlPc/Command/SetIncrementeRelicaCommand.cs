using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class SetIncrementeRelicaCommand
    {
        public SetIncrementeRelicaCommand(string guid)
        {
            ExecReqSqlNoQuery MyExecReqSqlNoQuery = new ExecReqSqlNoQuery();
            MyExecReqSqlNoQuery.ExecuteReq(@"EXEC CtrlPc.dbo.PS_ControleInsert '" + guid + "'");//cela va juste incrémenter le relica
        }
    }
}
