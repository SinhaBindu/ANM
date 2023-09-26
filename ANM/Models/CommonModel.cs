using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using SubSonic.Schema;

namespace ANM.Models
{
    public class CommonModel
    {
        public static DataTable GetCTFGEN(string UserName)
        {
            DataTable dt = new DataTable();
            StoredProcedure sp = new StoredProcedure("SP_GetCTFGen");
            sp.Command.AddParameter("@UserName", UserName, DbType.String);
            DataSet ds = sp.ExecuteDataSet();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return dt;
        }
    }
}