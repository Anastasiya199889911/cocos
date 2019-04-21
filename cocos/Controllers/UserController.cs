using cocos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cocos.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        private Db_Context db = new Db_Context(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //static List<BasketHelp> backet = new List<BasketHelp>();
        public ActionResult Index()
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
        public ActionResult Headphones()
        {
            if (Session["user"] != null)
            {


                ViewBag.title = "НАУШНИКИ";
                var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Наушники").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
                ViewBag.product = product;
                List<string> photo = new List<string>();
                foreach (var p in product)
                {
                    photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
                }
                ViewBag.photo = photo;
                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult Acoustics()
        {
            if (Session["user"] != null)
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

                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult Cables()
        {
            if (Session["user"] != null)
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
                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult Drives()
        {
            if (Session["user"] != null)
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
                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult BackpacksAndBags()
        {
            if (Session["user"] != null)
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

                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult SmartWatch()
        {
            if (Session["user"] != null)
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

                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult SmartHouse()
        {
            if (Session["user"] != null)
            {
                ViewBag.title = "УМНЫЙ ДОМ";
                var product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Умный дом").Select(t => t.id).FirstOrDefault()).OrderByDescending(p => p.count).ToList();
                ViewBag.product = product;
                List<string> photo = new List<string>();
                foreach (var p in product)
                {
                    photo.Add(db.Photos.Where(ph => ph.id_product == p.id && ph.is_main == true).Select(ph => ph.photo).FirstOrDefault());
                }
                ViewBag.photo = photo;
                return View("~/Views/User/Product.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public ActionResult Detail(int id)
        {
            if (Session["user"] != null)
            {
                var product = db.Products.Where(p => p.id == id).FirstOrDefault();
                ViewBag.product = product;
                ViewBag.photo = product.photo.ToList();
                ViewBag.main_photo = product.photo.Where(p => p.is_main == true).FirstOrDefault();
                ViewBag.comment = product.comments.ToList();
                ViewBag.characteristic = product.productCharacteristics.ToList();

                return View("~/Views/User/Detail.cshtml");
            }
            else
                return Redirect("/Products");
        }
        public List<BasketHelp> SelectProdInBasket(int id_user)
        {
            var basket_db = db.Baskets.Where(b => b.id_user == id_user).ToList();
            List<BasketHelp> basket = new List<BasketHelp>();
            foreach (var ba in basket_db)
            {
                basket.Add(new BasketHelp
                {
                    id_product = ba.id_product,
                    name = db.Products.Where(p => p.id == ba.id_product).Select(p => p.name).FirstOrDefault(),
                    price = db.Products.Where(p => p.id == ba.id_product).Select(p => p.price).FirstOrDefault(),
                    photo = db.Photos.Where(p => p.id_product == ba.id_product && p.is_main == true).Select(p => p.photo).FirstOrDefault(),
                    count = ba.count
                });
            }
            return basket;
        }
        public JsonResult AddBacket(int id)
        {
            int id_user = Convert.ToInt32(Session["user"]);
            if (db.Baskets.Where(b => b.id_product == id && b.id_user == id_user).FirstOrDefault() == null)
            {
                db.Baskets.Add(new Baskets
                {
                    id_product = id,
                    id_user = id_user,
                    count = 1
                });
                db.SaveChanges();
                //backet.Add(new BasketHelp
                //{
                //    id_product = id,
                //    name = db.Products.Where(p => p.id == id).Select(p => p.name).FirstOrDefault(),
                //    price = db.Products.Where(p => p.id == id).Select(p => p.price).FirstOrDefault(),
                //    photo = db.Photos.Where(p => p.id_product == id && p.is_main == true).Select(p => p.photo).FirstOrDefault(),
                //    count = 1
                //});

                object count_ = SelectProdInBasket(id_user);


                return Json(count_, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult SelectBasket()
        {
            int id_user = Convert.ToInt32(Session["user"]);
            var basket_db = db.Baskets.Where(b => b.id_user == id_user).ToList();
            //backet = new List<BasketHelp>();
            foreach (var ba in basket_db)
            {
                if (ba.count > db.Products.Where(p => p.id == ba.id_product).Select(p => p.count).FirstOrDefault())
                {
                    ba.count = db.Products.Where(p => p.id == ba.id_product).Select(p => p.count).FirstOrDefault();
                }
                //backet.Add(new BasketHelp
                //{
                //    id_product = ba.id_product,
                //    name = db.Products.Where(p => p.id == ba.id_product).Select(p => p.name).FirstOrDefault(),
                //    price = db.Products.Where(p => p.id == ba.id_product).Select(p => p.price).FirstOrDefault(),
                //    photo = db.Photos.Where(p => p.id_product == ba.id_product && p.is_main == true).Select(p => p.photo).FirstOrDefault(),
                //    count = 1
                //});
            }
            db.SaveChanges();

            object count_ = SelectProdInBasket(id_user);
            return Json(count_, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddProductCount(int id)
        {
            int id_user = Convert.ToInt32(Session["user"]);
            var b = db.Baskets.Where(ba => ba.id_product == id && ba.id_user == id_user).FirstOrDefault();
            var prod = db.Products.Where(p => p.id == id).FirstOrDefault();
            if (b.count < prod.count)
            {
                b.count = b.count + 1;
                db.SaveChanges();
                object count_ = SelectProdInBasket(id_user);
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
            int id_user = Convert.ToInt32(Session["user"]);
            var b = db.Baskets.Where(ba => ba.id_product == id && ba.id_user == id_user).FirstOrDefault();
            var prod = db.Products.Where(p => p.id == id).FirstOrDefault();
            if (b.count > 1)
            {
                b.count = b.count - 1;
                db.SaveChanges();
                object count_ = SelectProdInBasket(id_user);
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
            int id_user = Convert.ToInt32(Session["user"]);
            db.Baskets.Remove(db.Baskets.Where(ba => ba.id_product == id && ba.id_user == id_user).FirstOrDefault());
            db.SaveChanges();
            //var prod = db.Products.Where(p => p.id == id).FirstOrDefault();
            object count_ = SelectProdInBasket(id_user);
            return Json(count_, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendComment(int id, string plus, string minus, string comment)
        {
            int id_user = Convert.ToInt32(Session["user"]);
            db.Comments.Add(new Comments
            {
                id_product = id,
                id_user = id_user,
                text = comment,
                plus = plus,
                minus = minus,
                date = DateTime.Now
            });
            db.SaveChanges();
            var com_db = db.Comments.Where(c => c.id_product == id).OrderBy(c => c.date).ToList();
            List<string> com = new List<string>();
            foreach (var c in com_db)
            {
                string date = "";
                if (c.date.Day < 10)
                    date += "0" + c.date.Day + ".";
                else
                    date += c.date.Day + ".";
                if (c.date.Month < 10)
                    date += "0" + c.date.Month + ".";
                else
                    date += c.date.Month + ".";
                date += c.date.Year;
                com.Add(date);
                com.Add(c.text);
                com.Add(c.plus);
                com.Add(c.minus);
            }
            object comment_ = com;
            return Json(comment_, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddListWishes(int id)
        {
            int id_user = Convert.ToInt32(Session["user"]);
            if (db.ListWishes.Where(l => l.id_product == id && l.id_user == id_user).FirstOrDefault() == null)
            {
                db.ListWishes.Add(new ListWishes
                {
                    id_user = id_user,
                    id_product = id
                });
                db.SaveChanges();
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("error", JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult ListWishes()
        {
            if (Session["user"] != null)
            {
                int id_user = Convert.ToInt32(Session["user"]);
                ViewBag.list = db.ListWishes.Where(l => l.id_user == id_user).ToList();
                return View();
            }
            else
                return Redirect("/Products");
        }
        public JsonResult DeleteInList(int id)
        {
            int id_user = Convert.ToInt32(Session["user"]);
            db.ListWishes.Remove(db.ListWishes.Where(l => l.id_user == id_user && l.id_product == id).FirstOrDefault());
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Checkout()
        {

            if (Session["user"] != null)
            {
                int id_user = Convert.ToInt32(Session["user"]);
                ViewBag.basket = db.Baskets.Where(b => b.id_user == id_user).ToList();
                return View();
            }
            else
                return Redirect("/Products");
        }
        public JsonResult SendOrder(string fio, string email, string phone)
        {
            int id_user = Convert.ToInt32(Session["user"]);
            Orders order = new Orders
            {
                id_user = id_user,
                fio = fio,
                email = email,
                phone = phone,
                date = DateTime.Now.Date
            };
            db.Orders.Add(order);
            db.SaveChanges();
            var basket = db.Baskets.Where(b => b.id_user == id_user).ToList();
            foreach (var b in basket)
            {
                db.CompositionOrders.Add(new CompositionOrders
                {
                    id_order = order.id,
                    name = b.product.name,
                    count = b.count,
                    price = b.product.price
                });
                var product = db.Products.Where(p => p.id == b.id_product).FirstOrDefault();
                product.count = product.count - b.count;
                db.SaveChanges();
            }
            db.Baskets.RemoveRange(basket);
            db.SaveChanges();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Find(string search)
        {
            search = search.ToLower();
            ViewBag.title = "Результаты поиска по запросу: " + search;
            var product0 = db.Products.OrderBy(p => p.count).ToList();
            List<Products> product = new List<Products>();
            foreach (var p in product0)
            {
                if (p.name.ToLower().IndexOf(search) >= 0)
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
            return View("~/Views/User/Product.cshtml");
        }
    }
}