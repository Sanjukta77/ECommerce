using EcommerceWebside.Models;
using EcommerceWebside.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EcommerceWebside.Controllers
{
    public class ShoppingController : Controller
    {
        ECartDbEntities db = new ECartDbEntities();

        List<ShoppingCartModel> listOfShoppingCartModel = new List<ShoppingCartModel>();


        public ActionResult Index()
        {
            IEnumerable<shoppingViewModel> selectListItems = (from objItem in db.items
                                                              join
                                                              objCate in db.categories
                                                              on objItem.categoryId equals objCate.categoryId
                                                              select new shoppingViewModel()
                                                              {
                                                                  imagePath = objItem.imagePath,
                                                                  itemName = objItem.itemName,
                                                                  itemPrice = objItem.itemPrice,
                                                                  Description = objItem.Description,
                                                                  ItemId = objItem.ItemId,
                                                                  category = objCate.categoryName

                                                              }).ToList();
            return View(selectListItems);
        }

        [HttpPost]
          public JsonResult Index(string itemId)
          {          
            ShoppingCartModel objshoppingCartModel = new ShoppingCartModel();

            item objItem = db.items.Single(model => model.ItemId.ToString()== itemId);

            if (Session["CartCounter"] != null)
            {
                listOfShoppingCartModel = Session["CartItem"] as List<ShoppingCartModel>;

            }


            if (listOfShoppingCartModel.Any(model=>model.itemId== itemId))
            {
                objshoppingCartModel = listOfShoppingCartModel.Single(model => model.itemId == itemId);
                objshoppingCartModel.quantity = objshoppingCartModel.quantity + 1;

                objshoppingCartModel.Total = objshoppingCartModel.quantity * objshoppingCartModel.unitPrice;

            }
            else
           
            {
                objshoppingCartModel.itemId = itemId;
                objshoppingCartModel.imagePath = objItem.imagePath;
                objshoppingCartModel.itemName = objItem.itemName;
                objshoppingCartModel.quantity = 1;
                objshoppingCartModel.Total = Convert.ToInt32(objItem.itemPrice);
                objshoppingCartModel.unitPrice = Convert.ToInt32(objItem.itemPrice);

                listOfShoppingCartModel.Add(objshoppingCartModel);

            }



            Session["CartCounter"] = listOfShoppingCartModel.Count;
            Session["CartItem"] = listOfShoppingCartModel;


            return Json(new { Success = true, Counter=listOfShoppingCartModel.Count}, JsonRequestBehavior.AllowGet);

          }

        public ActionResult ShoppingCart()
        {

            //now here usin this Session["CartItem"] we will all the variables that are present in the session
            //we will convert it to in the form of list
            listOfShoppingCartModel = Session["CartItem"] as List<ShoppingCartModel>;

            //then that list we will send it to the view
            return View(listOfShoppingCartModel);
        }



        public ActionResult AddOrder()
        {
            int OrderId = 0;
            listOfShoppingCartModel = Session["CartItem"] as List<ShoppingCartModel>;

            Order orderObj = new Order()
            {
                OrderDate = DateTime.Now,
                OrderNumber = string.Format("{0:ddmmyyyHHmmss}", DateTime.Now)
            };
            OrderId = orderObj.OrderId;

            db.Orders.Add(orderObj);
            db.SaveChanges();


            foreach(var item in listOfShoppingCartModel)
            {
                OrderDetail orderDetail = new OrderDetail();

                orderDetail.Total = item.Total;
                //orderDetail.ItemId =item.itemId;
                orderDetail.Total = item.Total;
                orderDetail.OrderId = OrderId;
                orderDetail.Quantity = item.quantity;
                orderDetail.UnitPrice = item.unitPrice;
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();

            }

            Session["CartCounter"] = null; ;
            Session["CartItem"] = null;
           
            return RedirectToAction("Index");



            
        }


    }
}