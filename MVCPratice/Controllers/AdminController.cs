using MVCPratice.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCPratice.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            Country_Bind();
            return View();
        }
        [HttpPost]
        public ActionResult Index(User Obj)
        {
            BALUser obj = new BALUser();
            obj.SaveDate(Obj.Name, Obj.Address, Obj.Phone,Obj.BOD,Obj.Gender,Obj.Email, Obj.CityId);
            return RedirectToAction("Index");
        }
        public void Country_Bind()
        {
            BALUser obj = new BALUser();
            DataSet ds = obj.GetCountry();
            List<SelectListItem>
                CountryList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CountryList.Add(new SelectListItem
                {
                    Text = dr["CountryName"].ToString(),
                    Value = dr["CountryId"].ToString()
                });
            }
            ViewBag.Country = CountryList;
        }
        public JsonResult State_Bind(int Country_Id)
        { 
            User Obj = new User();
            BALUser obj = new BALUser();
            DataSet ds = obj.GetState(Country_Id);
            List<SelectListItem>
                StatesList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                StatesList.Add(new SelectListItem
                {
                    Text = dr["StateName"].ToString(),
                    Value = dr["StateId"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(StatesList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult City_Bind(int State_Id)

        {

            BALUser obj = new BALUser();
            DataSet ds = obj.GetCity(State_Id);
            List<SelectListItem> CityList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                CityList.Add(new SelectListItem
                {
                    Text = dr["cityName"].ToString(),
                    Value = dr["CityId"].ToString()
                });
            }
            // ViewBag.StateName = StatesList;
            return Json(CityList, JsonRequestBehavior.AllowGet);
        }
    }
}