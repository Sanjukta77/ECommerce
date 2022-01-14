using EcommerceWebside.Models;
using EcommerceWebside.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebside.Controllers
{
    public class ItemController : Controller
    {
        ECartDbEntities db = new ECartDbEntities();

       
        public ActionResult Index()
        {
            itemViewModel objitemViewModel = new itemViewModel();
            objitemViewModel.CategorySelectListItem = (from objCat in db.categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.categoryName,
                                                           Value = objCat.categoryId.ToString(),
                                                           Selected = true
                                                       }).ToList();


            return View(objitemViewModel);

           
        }


        [HttpPost]
        public JsonResult Index(itemViewModel objitemViewModel)
        {

            string NewImage = Guid.NewGuid() + Path.GetExtension(objitemViewModel.imagePath.FileName);

            objitemViewModel.imagePath.SaveAs(Server.MapPath("~/Images/" + NewImage));

            item objitem = new item();
            objitem.imagePath = "~/Images/" + NewImage;
            objitem.itemCode = objitemViewModel.itemCode;
            objitem.itemName = objitemViewModel.itemName;
            objitem.itemPrice = objitemViewModel.itemPrice;
            objitem.Description = objitemViewModel.Description;
            objitem.categoryId = objitemViewModel.categoryId;
            objitem.ItemId = Guid.NewGuid();

            db.items.Add(objitem);
            db.SaveChanges();

            return Json(new { Success=true,Message="Item is succsessfully added"}, JsonRequestBehavior.AllowGet);
        }
    }
}