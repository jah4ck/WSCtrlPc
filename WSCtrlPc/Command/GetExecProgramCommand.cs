using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetExecProgramCommand
    {
        public string GetExecProgramAction(string guid, DateTime date)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
IF ((SELECT count(*) FROM CtrlPc.dbo.fn_ExecProgram('" + guid + @"',CONVERT(DATETIME,'" + date.ToString("yyyy-MM-dd HH:mm:ss") + @"',120)))>0)
BEGIN
	SELECT ID_EXEC,LIBELLE FROM CtrlPc.dbo.fn_ExecProgram('" + guid + @"',CONVERT(DATETIME,'" + date.ToString("yyyy-MM-dd HH:mm:ss") + @"',120))
END
ELSE
BEGIN
	(SELECT '0'as ID_EXEC,'0' as LIBELLE)
END
");
            string temp = MyExecReqSqlReader.result;
            if (temp.Length<1 || temp==null || temp=="")
            {
                temp = "0";
            }

            return temp;
        }
    }
}
