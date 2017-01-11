using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WSCtrlPc.Command;

namespace WSCtrlPc
{
    /// <summary>
    /// Description résumée de WSCtrlPc
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    // [System.Web.Script.Services.ScriptService]
    public class WSCtrlPc : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public void CreateGuid(string hostname,string guid,string identifiant, string version)
        {
            CreateGuidCommand MyCreateGuidCommand = new CreateGuidCommand();
            MyCreateGuidCommand.CreateGuidAction(hostname, guid, identifiant, version);
        }

        [WebMethod]
        public void TraceLog(string guid, DateTime dateTraitement, string codeappli, int codeerreur, string description)
        {
            TraceLogCommand MyTraceLogCommand = new TraceLogCommand();
            MyTraceLogCommand.TraceLogAction(guid,dateTraitement,codeappli,codeerreur,description);
        }
        [WebMethod]
        public string TraceLogNew(string guid, DateTime dateTraitement, string codeappli, int codeerreur, string description)
        {
            WSCtrlPcInsert.WSCtrlPcInsert ws = new WSCtrlPcInsert.WSCtrlPcInsert();
            return ws.TraceLog(guid, dateTraitement, codeappli, codeerreur, description);
        }

        [WebMethod]
        public string GetPlanning(string guid)
        {
            GetPlanningCommand MyGetPlanningCommand = new GetPlanningCommand();
            return MyGetPlanningCommand.GetPlanningCommandAction(guid);
        }
        [WebMethod]
        public string GetArret(string guid)
        {
            GetArretCommand MyGetArretCommand = new GetArretCommand();
            return MyGetArretCommand.GetArretCommandAction(guid);
        }
        [WebMethod]
        public string GetPlageHoraire(string guid, DateTime dateheure)
        {
            GetPlageHoraireCommand MyGetPlageHoraireCommand = new GetPlageHoraireCommand();
            return MyGetPlageHoraireCommand.GetPlageHoraireCommandAction(guid, dateheure);
        }

        [WebMethod]
        public string GetRemLogInfo(string guid)
        {
            GetRemLogInfoCommand MyGetRemLogInfoCommand = new GetRemLogInfoCommand();
            return MyGetRemLogInfoCommand.GetRemLogInfoCommandAction(guid);
        }

        [WebMethod]
        public string GetDownloadFile(string guid,DateTime date)
        {
            GetDownloadFileCommand MyGetDownloadFileCommand = new GetDownloadFileCommand();
            return MyGetDownloadFileCommand.GetDownloadFileCommandAction(guid, date);
        }
        [WebMethod]
        public void SetDownloadFile(string guid,DateTime date, string dest,string source)
        {
            SetDownloadFileCommand MySetDownloadFileCommand = new SetDownloadFileCommand();
            MySetDownloadFileCommand.SetDownloadFileCommandAction(guid, date, dest, source);
        }

        [WebMethod]
        public string GetExecProgram(string guid,DateTime date)
        {
            GetExecProgramCommand MyGetExecProgramCommand = new GetExecProgramCommand();
            return MyGetExecProgramCommand.GetExecProgramAction(guid, date);
        }
        [WebMethod]
        public void SetExecProgram(int idexec, DateTime date)
        {
            SetExecProgramCommand MySetExecProgram = new SetExecProgramCommand(idexec, date);
        }
        [WebMethod]
        public string GetException(string guid)
        {
            GetExceptionCommand MyExceptionCommand = new GetExceptionCommand();
            return MyExceptionCommand.GetExceptionCommandAction(guid);
        }
        [WebMethod]
        public void SetDateDerniereConnexion(string guid)
        {
            SetDateDerniereConnexion MySetDateDerniereConnexion = new Command.SetDateDerniereConnexion(guid);
        }

        [WebMethod]
        public void SetIncrementeRelica(string guid)
        {
            SetIncrementeRelicaCommand mySetIncrementeRelica = new SetIncrementeRelicaCommand(guid);
        }
        //penser a ajouter des contrôle de ce qu'on insert en BDD
        
        [WebMethod]
        public string GetPresenceFile(string guid, string file)
        {
            GetPresenceFileCommand myGetPresenceFileCommand = new GetPresenceFileCommand();
            return myGetPresenceFileCommand.GetPresenceFileCommandAction(guid, file);
            
        }



    }
}
