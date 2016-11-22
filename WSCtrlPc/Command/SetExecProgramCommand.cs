using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class SetExecProgramCommand
    {
        public SetExecProgramCommand(int idexec,DateTime date)
        {
            ExecReqSqlNoQuery MyExecReqSqlNoQuery = new ExecReqSqlNoQuery();
            MyExecReqSqlNoQuery.ExecuteReq(@"
UPDATE [CtrlPc].[dbo].[EXEC_PROGRAM] SET DATE_DERNIERE_EXECUTION=CONVERT(DATETIME,'" + date.ToString("yyyy-MM-dd HH:mm:ss") + @"') WHERE ID_EXEC="+idexec+@"
");
        }
    }
}
