using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WSCtrlPc.Model
{
    public class ExecReqSqlReader
    {
        private string Myresult;

        public string result
        {
            get
            {
                return Myresult;               
            }
            set
            {
                Myresult = value;
            }
        }
        public void ExecuteReq(string requete)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=SRVPROD\ADMSRV;Initial Catalog=donnee_01;Persist Security Info=True;User ID=dev1;Password=Stine1!?");
            SqlCommand cmd = new SqlCommand(requete, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            int count = reader.FieldCount;
            while (reader.Read())
            {
                string tmpligne = "";
                for (int i = 0; i < count; i++)
                {
                    tmpligne = tmpligne + reader[i] + ";";

                }
                Myresult = Myresult + tmpligne + Environment.NewLine;
            }
            conn.Close();
        }
    }
}
