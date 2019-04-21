using cocos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace cocos.Controllers
{
    public class ProductsController : Controller
    {
        private Db_Context db = new Db_Context(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        static List<BasketHelp> backet = new List<BasketHelp>();
        //static List<int> count = new List<int>();
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                return Redirect("User/Index");
            }
            else
            {
                var product = db.Products.OrderByDescending(p => p.date).Take(8).ToList();
                ViewBag.product = product;
                List<string> photo = new List<string>();
                foreach (var p in product)
                {
                    photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
                }
                ViewBag.photo = photo;
                return View();
            }
        }
        public ActionResult Headphones()
        {
            ViewBag.title = "НАУШНИКИ";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Наушники").Select(t => t.id).FirstOrDefault()).OrderByDescending(p=>p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;


            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            //ViewBag.count = count;
            return View("~/Views/Products/Product.cshtml");
        }
        public ActionResult Acoustics()
        {
            ViewBag.title = "АКУСТИКА";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Акустика").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Product.cshtml");
        }
        public ActionResult Cables()
        {
            ViewBag.title = "КАБЕЛИ";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Кабели").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Product.cshtml");
        }
        public ActionResult Drives()
        {
            ViewBag.title = "НАКОПИТЕЛИ";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Накопители").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Product.cshtml");
        }
        public ActionResult BackpacksAndBags()
        {
            ViewBag.title = "РЮКЗАКИ И СУМКИ";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Рюкзаки и сумки").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Product.cshtml");
        }
        public ActionResult SmartWatch()
        {
            ViewBag.title = "СМАРТ-ЧАСЫ";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Смарт-часы").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Product.cshtml");
        }
        public ActionResult SmartHouse()
        {
            ViewBag.title = "УМНЫЙ ДОМ";
            var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Умный дом").Select(t => t.id).FirstOrDefault()).OrderBy(p => p.count).ToList();
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Product.cshtml");
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

        public JsonResult Authorization(string login, string pass)
        {
            if (db.Users.Where(u => u.login == login && u.password == pass && u.is_admin == false).FirstOrDefault() != null)
            {
                Session["user"] = db.Users.Where(u => u.login == login && u.password == pass && u.is_admin == false).Select(u => u.id).FirstOrDefault();
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Registration(string login, string pass)
        {
            if (db.Users.Where(u => u.login == login && u.password == pass && u.is_admin == false).FirstOrDefault() != null)
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
            else
            {
                db.Users.Add(new Users
                {
                    login=login,
                    password=pass,
                    is_admin=false
                });
                db.SaveChanges();
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Detail(int id)
        {
            var product = db.Products.Where(p => p.id == id).FirstOrDefault();
            ViewBag.product = product;
            ViewBag.photo = product.photo.ToList();
            ViewBag.main_photo = product.photo.Where(p => p.is_main == true).FirstOrDefault();
            ViewBag.comment = product.comments.ToList();
            ViewBag.characteristic = product.productCharacteristics.ToList();

            //ViewBag.basket_count = backet.Count;
            //ViewBag.basket_info = backet;
            //List<string> basket_photo = new List<string>();
            //foreach (var p in backet)
            //{
            //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            //}
            //ViewBag.basket_photo = basket_photo;
            return View("~/Views/Products/Detail.cshtml");
        }
        public JsonResult AddBacket(int id)
        {
            if (backet.Where(b => b.id_product == id).FirstOrDefault() == null)
            {
                backet.Add(new BasketHelp
                {
                    id_product = id,
                    name = db.Products.Where(p => p.id == id).Select(p => p.name).FirstOrDefault(),
                    price = db.Products.Where(p => p.id == id).Select(p => p.price).FirstOrDefault(),
                    photo = db.Photos.Where(p => p.id_product == id && p.is_main == true).Select(p => p.photo).FirstOrDefault(),
                    count = 1
                });
                object count_ = backet;

                //ViewBag.basket_count = backet.Count;
                //ViewBag.basket_info = backet;
                //List<string> basket_photo = new List<string>();
                //foreach (var p in backet)
                //{
                //    basket_photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
                //}
                //ViewBag.basket_photo = basket_photo;
                return Json(count_, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult SelectBasket()
        {
            foreach(var ba in backet)
            {
                if(ba.count>db.Products.Where(p=>p.id==ba.id_product).Select(p=>p.count).FirstOrDefault())
                {
                    ba.count = db.Products.Where(p => p.id == ba.id_product).Select(p => p.count).FirstOrDefault();
                }
            }
            object count_ = backet;
            return Json(count_, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddProductCount(int id)
        {
            var b = backet.Where(ba => ba.id_product == id).FirstOrDefault();
            var prod = db.Products.Where(p => p.id == id).FirstOrDefault();
            if (b.count < prod.count)
            {
                b.count = b.count + 1;
                object count_ = backet;
                return Json(count_, JsonRequestBehavior.AllowGet);
            }
            else
            {
                object count_ = "error";
                return Json(count_, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult MinusProductCount(int id)
        {
            var b = backet.Where(ba => ba.id_product == id).FirstOrDefault();
            //var prod = db.Products.Where(p => p.id == id).FirstOrDefault();
            if (b.count > 1)
            {
                b.count = b.count - 1;
                object count_ = backet;
                return Json(count_, JsonRequestBehavior.AllowGet);
            }
            else
            {
                object count_ = "error";
                return Json(count_, JsonRequestBehavior.AllowGet);
            }

        }
        public JsonResult DeleteProductInBasket(int id)
        {
            backet.Remove(backet.Where(ba => ba.id_product == id).FirstOrDefault());
            //var prod = db.Products.Where(p => p.id == id).FirstOrDefault();
            object count_ = backet;
            return Json(count_, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Basket()
        {
            ViewBag.basket = backet;
            return View();
        }
        public ActionResult Checkout()
        {
            ViewBag.basket = backet;
            return View();
        }
        public JsonResult SendOrder(string fio, string email, string phone)
        {
            Orders order=new Orders
            {
                fio = fio,
                email = email,
                phone = phone,
                date=DateTime.Now.Date
            };
            db.Orders.Add(order);
            db.SaveChanges();
            foreach(var b in backet)
            {
                db.CompositionOrders.Add(new CompositionOrders
                {
                    id_order = order.id,
                    name = b.name,
                    count = b.count,
                    price = b.price
                });
                var product = db.Products.Where(p => p.id == b.id_product).FirstOrDefault();
                product.count = product.count - b.count;
                db.SaveChanges();
            }
            backet.Clear();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Find(string search)
        {
            search = search.ToLower();
            ViewBag.title = "Результаты поиска по запросу: "+ search;
            var product0 = db.Products.OrderBy(p => p.count).ToList();
            List<Products> product = new List<Products>();
            foreach(var p in product0)
            {
                if(p.name.ToLower().IndexOf(search)>=0)
                {
                    product.Add(p);
                }
            }
            ViewBag.product = product;
            List<string> photo = new List<string>();
            foreach (var p in product)
            {
                photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
            }
            ViewBag.photo = photo;
            return View("~/Views/Products/Product.cshtml");
        }
    }
}