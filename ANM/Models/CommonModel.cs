using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SubSonic.Schema;

namespace ANM.Models
{
    public class CommonModel
    {
        #region BaseUrl
        public static string GetBaseUrl()
        {
            UrlHelper urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            string host = HttpContext.Current.Request.Url.Host;
            if (host == "localhost")
            {
                host = HttpContext.Current.Request.Url.Authority;
                return HttpContext.Current.Request.Url.Scheme + "://" + host;
            }
            return urlHelper.Content("~/");
        }
        public static string GetFileUrl(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                return CommonModel.GetBaseUrl() + filePath.ToString().Replace("~", "");
            else
                return string.Empty;
        }
        #endregion
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
        public static DataSet GetSummaryData()
        {
            DataTable dt = new DataTable();
            StoredProcedure sp = new StoredProcedure("SP_Summary");
            DataSet ds = sp.ExecuteDataSet();
            return ds;
        }
        public static DataTable GetSPLastLogin()
        {
            StoredProcedure sp = new StoredProcedure("GetSPLastLogin");
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
        public static DataTable GetSPCutUserlist()
        {
            StoredProcedure sp = new StoredProcedure("SPGetCutUserlist");
            sp.Command.AddParameter("@User", HttpContext.Current.User.Identity.Name, DbType.String);
            DataTable dt = sp.ExecuteDataSet().Tables[0];
            return dt;
        }
    }
}