using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace onePageCrudAjax.Controllers
{
    public class CrudController : Controller
    {
        // GET: Crud
        crudDBEntities db = new crudDBEntities();

        //public List<CrudMaster> filldata()
        //{
        //    List<CrudMaster> list = new List<CrudMaster>();
        //    var data = db.CrudMasters.ToList();
        //    list.Add(data);

        //    return list;

        //}

        public ActionResult Index()
        {
          

            return View();
        }
        [HttpPost]
        public ActionResult Index(CrudMaster model)
        {
            if (model.Id>0)
            {
                var data = db.CrudMasters.Where(m => m.Id == model.Id).FirstOrDefault();
                  data.Name = model.Name;
                  data.Email= model.Email;
                 data.City= model.City;
                db.SaveChanges();
            }
            else
            {
                var data = db.CrudMasters.Add(model);
                db.SaveChanges();
            }

       
            
            return Json(model.Id,JsonRequestBehavior.AllowGet);
        }
        public ActionResult getlist()
        {
            var list = db.CrudMasters.ToList();

            return Json(list,JsonRequestBehavior.AllowGet);
        }
        public ActionResult CrudMasterById(int cid)
        {
            var data = db.CrudMasters.Where(m => m.Id == cid).FirstOrDefault();

            return Json(data,JsonRequestBehavior.AllowGet);
        }

        public ActionResult deleteCrudMasterById(int cid)
        {
            var data = db.CrudMasters.Where(m => m.Id == cid).FirstOrDefault();
            db.CrudMasters.Remove(data);
            db.SaveChanges();

            return Json(data,JsonRequestBehavior.AllowGet);
        }


        public ActionResult dynamicTextBox()
        {
            return View();
        }
        [HttpPost]
        public ActionResult dynamicTextBox(CrudMaster model)
        {
            db.CrudMasters.Add(model);
            db.SaveChanges();
            return Json(model.Id,JsonRequestBehavior.AllowGet);
        }
    }
}