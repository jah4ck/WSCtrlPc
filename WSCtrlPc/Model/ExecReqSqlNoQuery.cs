using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WSCtrlPc.Model
{
    public class ExecReqSqlNoQuery
    {
        private string Requete;

        public string req
        {
            get
            {
                return Requete;
            }
            set
            {
                Requete = value;
                ExecuteReq(Requete);
            }
        }
        public void ExecuteReq(string req)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=SRVPROD\ADMSRV;Initial Catalog=donnee_01;Persist Security Info=True;User ID=dev1;Password=Stine1!?";
            SqlCommand cmd = new SqlCommand(req, conn);
            
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            
        }
    }
}
