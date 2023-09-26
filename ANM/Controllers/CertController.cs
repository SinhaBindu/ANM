using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ANM.Models;

namespace ANM.Controllers
{
    [Authorize(Roles = "User")]
    public class CertController : Controller
    {
        ANMEntities db = new ANMEntities();
        public ActionResult Index()
        {
            CTFModel model = new CTFModel();
            if (User.Identity.IsAuthenticated)
            {
                DataTable dt = CommonModel.GetCTFGEN(User.Identity.Name);
                if (dt.Rows.Count > 0)
                {
                    var mark = dt.Rows[0]["Marks"].ToString();
                    var un = dt.Rows[0]["MobileNo"].ToString();
                    if (!string.IsNullOrWhiteSpace(mark))
                    {
                        if (50 >= Convert.ToInt32(mark))
                        {
                            model.Result = true;
                            model.Name = dt.Rows[0]["G2_ANM"].ToString();
                            return View(model);
                        }
                        else
                        {
                            model.Result = false;
                            return View(model);
                        }
                    }

                }
            }
            return RedirectToAction("Login", "Account");
        }
        //public ActionResult CertGen(string Id)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        if (!string.IsNullOrWhiteSpace(Id))
        //        {
        //            var getdata = db.tbl_ImmunizationS1?.FirstOrDefault(x => x.MobileNo == Id);
        //            if (getdata != null)
        //            {
        //                if (50 >= Convert.ToInt32(mark))
        //                {

        //                }
        //                return View(getdata);
        //            }
        //        }
        //    }
        //    return RedirectToAction("Login","Account");
        //}

    }
}