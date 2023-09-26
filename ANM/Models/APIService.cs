using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;
using ANM.Models;
using System.Globalization;
using System.Net.Mail;
using SubSonic.Schema;
using Microsoft.AspNet.Identity;

namespace ANM.Models
{
    public class APIService
    {
        private static ANMEntities db = new ANMEntities();
        public static string GetUsernameODK()
        {
            return "jtspteam@gmail.com";
        }
        public static string GetPasswordODK()
        {
            return "PCI@12345";
        }
        public static string GetUrlEncodedString(DateTime date)
        {
            string result = date.ToString("MMM dd, yyyy hh:mm:ss tt");
            result = HttpUtility.UrlEncode(result);
            result = result.Replace("+", "%20").ToUpper();
            return result;
        }
        public static string GetMAXDate(string para)
        {
            DataTable dt = new DataTable(); string strdate = string.Empty;
            StoredProcedure sp = new StoredProcedure("SP_GetMAXDate");
            sp.Command.AddParameter("@para", para, DbType.String);
            DataSet ds = sp.ExecuteDataSet();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                strdate = dt.Rows[0]["maxdate"].ToString();
            }
            return strdate;
        }
        private static long ConvertToTimestamp(DateTime value)
        {
            long epoch = (value.Ticks - 621355968000000000) / 10000000;
            return epoch;
        }
        public static void ErrorWrittext(string er)
        {
            var path = HttpContext.Current.Server.MapPath("~/TempFile/ErrorList.txt");
            File.WriteAllText(path, er);
        }

        //public static int GETImmunization()
        //{
        //    try
        //    {
        //        ////https://api.ona.io/jtspteam/formList?formID=Session_1_Immunization_schedule__Checklist

        //        string maxdate = GetMAXDate("1");
        //        string datem = Convert.ToDateTime(maxdate.ToString()).ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
        //        // long timestamp = ConvertToTimestamp(Convert.ToDateTime(maxdate));

        //        WebRequest req = WebRequest.Create(@"https://api.ona.io/api/v1/data/758721.json?query={%22_submission_time%22:{%22$gte%22:%22" + datem + "%22}}");

        //        req.Method = "GET";
        //        req.Credentials = new System.Net.NetworkCredential(GetUsernameODK(), GetPasswordODK());
        //        HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

        //        var dataStream = resp.GetResponseStream();
        //        StreamReader reader = new StreamReader(dataStream);
        //        string JsonData = reader.ReadToEnd();
        //        List<ImmModel> list = (List<ImmModel>)JsonConvert.DeserializeObject(JsonData, typeof(List<ImmModel>));

        //        if (list != null && list.Count > 0)
        //        {
        //            foreach (var m in list)
        //            {
        //                var chkkey = db.tbl_ImmunizationS1.Where(x => x.C_uuid == m.C_uuid).Count();
        //                tbl_ImmunizationS1 tbl = new tbl_ImmunizationS1();
        //                if (chkkey == 0 && !db.tbl_ImmunizationS1.Any(x => x.C_uuid == m.C_uuid))
        //                {
        //                    tbl.SubDate = m.SubDate;
        //                    tbl.Sub_id = m.Sub_id;
        //                    tbl.MobileNo = m.MobileNo;
        //                    tbl.Q1_A = m.Q1_A;
        //                    tbl.Q2_A = m.Q2_A;
        //                    tbl.Q3_A = m.Q3_A;
        //                    tbl.Q4_A = m.Q4_A;
        //                    tbl.Q5_A = m.Q5_A;
        //                    tbl.Q6_A = m.Q6_A;
        //                    tbl.Q7_A = m.Q7_A;
        //                    tbl.Q8_A = m.Q8_A;
        //                    tbl.Q9_A = m.Q9_A;
        //                    tbl.G4_Q1 = m.G4_Q1;
        //                    tbl.G5_Q2 = m.G5_Q2;
        //                    tbl.G6_Q3 = m.G6_Q3;
        //                    tbl.G7_Q4 = m.G7_Q4;
        //                    tbl.G8_Q5 = m.G8_Q5;
        //                    tbl.G9_Q6 = m.G9_Q6;
        //                    tbl.Marks = m.Marks;
        //                    tbl.Q10_A = m.Q10_A;
        //                    tbl.Q11_A = m.Q11_A;
        //                    tbl.Q12_A = m.Q12_A;
        //                    tbl.C_tags = m.C_tags;
        //                    tbl.C_uuid = m.C_uuid;
        //                    tbl.today = m.today;
        //                    tbl.G10_Q7 = m.G10_Q7;
        //                    tbl.G11_Q8 = m.G11_Q8;
        //                    tbl.G12_Q9 = m.G12_Q9;
        //                    tbl.G2_ANM = m.G2_ANM;
        //                    tbl.C_notes = m.C_notes;
        //                    tbl.EndTime = m.EndTime;
        //                    tbl.G13_Q10 = m.G13_Q10;
        //                    tbl.G14_Q11 = m.G14_Q11;
        //                    tbl.G15_Q12 = m.G15_Q12;
        //                    tbl.C_edited = m.C_edited;
        //                    tbl.C_status = m.C_status;
        //                    tbl.G2_BLOCK = m.G2_BLOCK;
        //                    tbl.C_version = m.C_version;
        //                    tbl.C_duration = m.C_duration;
        //                    tbl.C_xform_id = m.C_xform_id;
        //                    tbl.timeStart = m.timeStart;
        //                    tbl.G2_DISTRICT = m.G2_DISTRICT;
        //                    tbl.C_attachments = m.C_attachments;
        //                    tbl.C_geolocation = m.C_geolocation;
        //                    tbl.C_media_count = m.C_media_count;
        //                    tbl.C_total_media = m.C_total_media;
        //                    tbl.formhub_uuid = m.formhub_uuid;
        //                    tbl.C_submitted_by = m.C_submitted_by;
        //                    tbl.C_date_modified = m.C_date_modified;
        //                    tbl.meta_instanceID = m.meta_instanceID;
        //                    tbl.C_submission_time = m.C_submission_time;
        //                    tbl.C_xform_id_string = m.C_xform_id_string;
        //                    tbl.C_bamboo_dataset_id = m.C_bamboo_dataset_id;
        //                    tbl.C_media_all_received = m.C_media_all_received;
        //                    tbl.IsActive = true;
        //                    tbl.CreatedDt = DateTime.Now;
        //                    db.tbl_ImmunizationS1.Add(tbl);
        //                    var res = db.SaveChanges();
        //                    if (res > 0)
        //                    {
        //                        return res;
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return 0;
        //}
    }
}