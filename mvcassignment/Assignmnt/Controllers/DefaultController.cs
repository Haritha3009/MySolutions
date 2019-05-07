using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignmnt.Models;
namespace Assignmnt.Controllers
{   
    public class DefaultController : Controller
    {
        DataContainerEntities sd = new DataContainerEntities();
        Cascade cmd = new Cascade();

        // GET: Default
        public ActionResult Index()
        {
            State_Bind();
            return View();            
        }
        [HttpPost]
        public ActionResult Index(Cascade cas)
        {
            tblreg stud = new tblreg();
            if (ModelState.IsValid)
            {
                try
                {
                    stud.Name = cas.RegCand.Name;
                    stud.Address = cas.RegCand.Address;
                    stud.Gender = cas.RegCand.Gender;
                    stud.State = cas.StateId.ToString();
                    stud.City = cas.CityId.ToString();
                    cas.RegCand = stud;
                    sd.tblregs.Add(stud);
                    sd.SaveChanges();
                    State_Bind();
                }
                catch
                {
                    State_Bind();
                    return View(cas);
                }
            }
            ViewData["Ins"] = "Saved";
            return View(cas);

        }
        public void State_Bind()
        {
            List<tblstate> statelist = sd.tblstates.ToList();
            // ViewBag.statelist = new SelectList(statelist, "id", "name");
            ViewBag.statelist = sd.tblstates.Select(x => new SelectListItem { Text = x.name.ToString(), Value = x.id.ToString() }).ToList();
        }
        public ActionResult City_Bind(int stateId)
        {
            sd.Configuration.ProxyCreationEnabled = false;
            List<tblcity> cityl = sd.tblcities.Where(s => s.sid == stateId).ToList();
            return Json(cityl, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Home()
        {
            return View();
        }
        //public ActionResult ViewModelDemo()
        //{
        //    //Data _dummyData = new Data();
        //    //ViewModelDemo vmDemo = new ViewModelDemo();
        //    //vmDemo.allCourses = _dummyData.GetAllCourse();
        //    //vmDemo.allDepartments = _dummyData.GetAllDepartment();
        //    //vmDemo.allEmployees = _dummyData.GetAllEmployee();
        //    return View(vmDemo);
        public ActionResult Login(tblreg dlogin)
        {
            var v = sd.tblregs.Where(a => a.Name.Equals(dlogin.Name) && a.Address.Equals(dlogin.Address)).FirstOrDefault();
            //if (ModelState.IsValid)
            //{
                if (v!=null)
                {
                    Session["Usrname"] = dlogin.Name;
                    return RedirectToAction("Home");
                }
                return View(dlogin);
           // }
            //return View(dlogin);
        }
    }   
}