using ANM.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using System.Data;

namespace ANM.Controllers
{
    [Authorize(Roles = "Admin,State")]
    public class HomeController : Controller
    {
        ANMEntities db = new ANMEntities();
        private ApplicationUserManager _userManager;

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ActionResult Index()
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds = CommonModel.GetSummaryData();
            if (ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
            }
            return View(dt);
        }
        [HttpPost]
        public ActionResult Get_DashBoard()
        {
            try
            {
                bool IsCheck = false;
                DataSet ds = new DataSet();

                ds = CommonModel.GetSummaryData();
                if (ds.Tables.Count > 0)
                {
                    IsCheck = true;
                }
                // var html = ConvertViewToString("_TreatmentComList", ds);
                var resds = JsonConvert.SerializeObject(ds);
                var res = Json(new { IsSuccess = IsCheck, Data = resds }, JsonRequestBehavior.AllowGet);
                res.MaxJsonLength = int.MaxValue;
                return res;//To DO
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return Json(new { IsSuccess = false, Data = "" }, JsonRequestBehavior.AllowGet); throw;
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";


            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public JsonResult APICall()
        {
            // //////https://api.ona.io/jtspteam/formList?formID=Session_1_Immunization_schedule__Checklist
            string str = string.Empty;
            ANMEntities db_ = new ANMEntities();
            try
            {
                string maxdate = APIService.GetMAXDate("1");
                WebRequest req;
                if (string.IsNullOrWhiteSpace(maxdate))
                {
                    req = WebRequest.Create(@"https://api.ona.io/api/v1/data/758721.json");
                }
                else
                {
                    string datem = Convert.ToDateTime(maxdate.ToString()).ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    req = WebRequest.Create(@"https://api.ona.io/api/v1/data/758721.json?query={%22_submission_time%22:{%22$gte%22:%22" + datem + "%22}}");
                }

                // long timestamp = ConvertToTimestamp(Convert.ToDateTime(maxdate));

                req.Method = "GET";
                req.Credentials = new System.Net.NetworkCredential(APIService.GetUsernameODK(), APIService.GetPasswordODK());
                HttpWebResponse resp = req.GetResponse() as HttpWebResponse;

                var dataStream = resp.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string JsonData = reader.ReadToEnd();
                List<ImmModel> list = (List<ImmModel>)JsonConvert.DeserializeObject(JsonData, typeof(List<ImmModel>));

                if (list != null && list.Count > 0)
                {
                    foreach (var m in list)
                    {
                        var chkkey = db_.tbl_ImmunizationS1.Where(x => x.C_uuid == m.C_uuid).Count();
                        tbl_ImmunizationS1 tbl = new tbl_ImmunizationS1();
                        if (chkkey == 0 && !db_.tbl_ImmunizationS1.Any(x => x.C_uuid == m.C_uuid))
                        {
                            //tbl.SubDate = m.SubDate;
                            tbl.Sub_id = m.Sub_id;
                            tbl.MobileNo = m.MobileNo;
                            tbl.Q1_A = m.Q1_A;
                            tbl.Q2_A = m.Q2_A;
                            tbl.Q3_A = m.Q3_A;
                            tbl.Q4_A = m.Q4_A;
                            tbl.Q5_A = m.Q5_A;
                            tbl.Q6_A = m.Q6_A;
                            tbl.Q7_A = m.Q7_A;
                            tbl.Q8_A = m.Q8_A;
                            tbl.Q9_A = m.Q9_A;
                            tbl.G4_Q1 = m.G4_Q1;
                            tbl.G5_Q2 = m.G5_Q2;
                            tbl.G6_Q3 = m.G6_Q3;
                            tbl.G7_Q4 = m.G7_Q4;
                            tbl.G8_Q5 = m.G8_Q5;
                            tbl.G9_Q6 = m.G9_Q6;
                            tbl.Marks = m.Marks;
                            tbl.Q10_A = m.Q10_A;
                            tbl.Q11_A = m.Q11_A;
                            tbl.Q12_A = m.Q12_A;
                            //tbl.C_tags = m.C_tags;
                            tbl.C_uuid = m.C_uuid;
                            tbl.today = m.today;
                            tbl.G10_Q7 = m.G10_Q7;
                            tbl.G11_Q8 = m.G11_Q8;
                            tbl.G12_Q9 = m.G12_Q9;
                            tbl.G2_ANM = m.G2_ANM;
                            //tbl.C_notes = m.C_notes;
                            tbl.EndTime = m.EndTime;
                            tbl.G13_Q10 = m.G13_Q10;
                            tbl.G14_Q11 = m.G14_Q11;
                            tbl.G15_Q12 = m.G15_Q12;
                            tbl.C_edited = m.C_edited;
                            tbl.C_status = m.C_status;
                            tbl.G2_BLOCK = m.G2_BLOCK;
                            tbl.C_version = m.C_version;
                            tbl.C_duration = m.C_duration;
                            tbl.C_xform_id = m.C_xform_id;
                            tbl.timeStart = m.timeStart;
                            tbl.G2_DISTRICT = m.G2_DISTRICT;
                            //tbl.C_attachments = m.C_attachments;
                            //tbl.C_geolocation = m.C_geolocation;
                            tbl.C_media_count = m.C_media_count;
                            tbl.C_total_media = m.C_total_media;
                            tbl.formhub_uuid = m.formhub_uuid;
                            tbl.C_submitted_by = m.C_submitted_by;
                            tbl.C_date_modified = m.C_date_modified;
                            tbl.meta_instanceID = m.meta_instanceID;
                            tbl.C_submission_time = m.C_submission_time;
                            tbl.C_xform_id_string = m.C_xform_id_string;
                            tbl.C_bamboo_dataset_id = m.C_bamboo_dataset_id;
                            tbl.C_media_all_received = m.C_media_all_received;
                            tbl.IsActive = true;
                            tbl.CreatedDt = DateTime.Now;
                            db.tbl_ImmunizationS1.Add(tbl);
                            var res = db.SaveChanges();
                            if (res > 0)
                            {
                                var user = new ApplicationUser { UserName = m.MobileNo, Email = m.MobileNo + "@gmail.com", PhoneNumber = m.MobileNo };
                                var result = UserManager.CreateAsync(user, m.MobileNo).Result;
                                if (result.Succeeded)
                                {
                                    var result1 = UserManager.AddToRole(user.Id, "User");
                                    str += res + "Success";
                                }

                            }
                        }
                    }
                    return Json(str, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
            }
            return Json(str, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SummaryData()
        {
            return View();
        }
    }
}