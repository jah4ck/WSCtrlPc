using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSCtrlPc.Model;

namespace WSCtrlPc.Command
{
    public class GetPlageHoraireCommand
    {
        public string GetPlageHoraireCommandAction(string guid, DateTime dateheure)
        {
            ExecReqSqlReader MyExecReqSqlReader = new ExecReqSqlReader();
            MyExecReqSqlReader.ExecuteReq(@"
select CtrlPc.dbo.CtrlPlageHoraire('"+guid+"',CONVERT(DATETIME,'"+dateheure.ToString("yyyy-MM-dd HH:mm:ss")+@"',120))
");
            return MyExecReqSqlReader.result;
        }
    }
}
