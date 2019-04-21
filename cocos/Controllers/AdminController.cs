using cocos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cocos.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private Db_Context db = new Db_Context(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult LoginAdmin(string login, string password)
        {
            var user = db.Users.Where(u => u.login == login && u.password == password && u.is_admin == true).FirstOrDefault();
            Session["userId"] = user.id;
            if (user != null)
            {
                return Json("ok", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("not", JsonRequestBehavior.AllowGet);
            }
        }
        public object getCharacteristics()
        {
            var characteristic_list = db.Characteristics.ToList();
            List<List<string>> list = new List<List<string>>();
            foreach (var ch in characteristic_list)
            {

                list.Add(new List<string> { ch.name, ch.id.ToString() });
                bool fl1 = false;
                bool fl2 = false;
                bool fl3 = false;
                bool fl4 = false;
                bool fl5 = false;
                bool fl6 = false;
                bool fl7 = false;
                foreach (var c in ch.characteristicByTypes)
                {
                    if (c.productTypes.id == 1)
                        fl1 = true;
                    if (c.productTypes.id == 2)
                        fl2 = true;
                    if (c.productTypes.id == 3)
                        fl3 = true;
                    if (c.productTypes.id == 4)
                        fl4 = true;
                    if (c.productTypes.id == 5)
                        fl5 = true;
                    if (c.productTypes.id == 6)
                        fl6 = true;
                    if (c.productTypes.id == 7)
                        fl7 = true;
                }
                List<string> list1 = new List<string>();
                if (fl1 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                if (fl2 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                if (fl3 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                if (fl4 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                if (fl5 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                if (fl6 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                if (fl7 == true)
                    list1.Add("1");
                else
                    list1.Add("0");
                list.Add(list1);
            }
            object list_ = list;
            return list_;
        }
        public JsonResult AddCharacteristic(string name, int? headphones, int? acoustics, int? cables, int? drives, int? backpacksAndBags, int? smartWatch, int? smartHouse)
        {
            var ch = new Characteristics
            {
                name = name
            };
            db.Characteristics.Add(ch);
            db.SaveChanges();
            List<string> list = new List<string>();
            list.Add(name);
            list.Add(ch.id.ToString());
            if (headphones != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Наушники").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 1).ToList();
                foreach(var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product=pr.id,
                        text=""
                    });
                    db.SaveChanges();
                }
            }

            if (acoustics != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Акустика").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 2).ToList();
                foreach (var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product = pr.id,
                        text = ""
                    });
                    db.SaveChanges();
                }
            }

            if (cables != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Кабели").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 3).ToList();
                foreach (var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product = pr.id,
                        text = ""
                    });
                    db.SaveChanges();
                }
            }

            if (drives != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Накопители").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 4).ToList();
                foreach (var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product = pr.id,
                        text = ""
                    });
                    db.SaveChanges();
                }
            }

            if (backpacksAndBags != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Рюкзаки и сумки").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 5).ToList();
                foreach (var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product = pr.id,
                        text = ""
                    });
                    db.SaveChanges();
                }
            }

            if (smartWatch != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Смарт-часы").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 6).ToList();
                foreach (var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product = pr.id,
                        text = ""
                    });
                    db.SaveChanges();
                }
            }

            if (smartHouse != null)
            {
                db.CharacteristicByTypes.Add(new CharacteristicByTypes
                {
                    id_characteristics = ch.id,
                    id_type_product = db.ProductTypes.Where(t => t.name == "Умный дом").Select(t => t.id).FirstOrDefault()
                });
                db.SaveChanges();
                var products = db.Products.Where(p => p.id_type_product == 7).ToList();
                foreach (var pr in products)
                {
                    db.ProductCharacteristics.Add(new ProductCharacteristics
                    {
                        id_characteristic = ch.id,
                        id_product = pr.id,
                        text = ""
                    });
                    db.SaveChanges();
                }
            }

            //object list_ = getCharacteristics();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCharacteristic(int id)
        {
            var characteristic = db.Characteristics.Where(c => c.id == id).FirstOrDefault();
            db.Characteristics.Remove(characteristic);
            db.SaveChanges();
            //object list_ = getCharacteristics();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public JsonResult UpdateCharacteristic(int id, string name, int? headphones, int? acoustics, int? cables, int? drives, int? backpacksAndBags, int? smartWatch, int? smartHouse)
        {
            var characteristic = db.Characteristics.Where(c => c.id == id).FirstOrDefault();
            characteristic.name = name;
            db.SaveChanges();

            var chType = db.CharacteristicByTypes.Where(c => c.id_characteristics == id).ToList();
            if (headphones != null)
            {
                if (chType.Where(c => c.id_type_product == 1).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Наушники").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 1 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 1).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 1).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c=>c.id_characteristics==id && c.id_type_product==1).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 1 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 1).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }
            if (acoustics != null)
            {
                if (chType.Where(c => c.id_type_product == 2).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Акустика").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 2 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 2).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 2).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c => c.id_characteristics == id && c.id_type_product == 2).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 2 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 2).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }
            if (cables != null)
            {
                if (chType.Where(c => c.id_type_product == 3).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Кабели").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 3 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 3).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 3).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c => c.id_characteristics == id && c.id_type_product == 3).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 3 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 3).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }
            if (drives != null)
            {
                if (chType.Where(c => c.id_type_product == 4).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Накопители").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 4 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 4).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 4).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c => c.id_characteristics == id && c.id_type_product == 4).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 4 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 4).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }
            if (backpacksAndBags != null)
            {
                if (chType.Where(c => c.id_type_product == 5).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Рюкзаки и сумки").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 5 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 5).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 5).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c => c.id_characteristics == id && c.id_type_product == 5).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 5 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 5).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }
            if (smartWatch != null)
            {
                if (chType.Where(c => c.id_type_product == 6).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Смарт-часы").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 6 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 6).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 6).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c => c.id_characteristics == id && c.id_type_product == 6).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 6 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 6).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }
            if (smartHouse != null)
            {
                if (chType.Where(c => c.id_type_product == 7).FirstOrDefault() == null)
                {
                    db.CharacteristicByTypes.Add(new CharacteristicByTypes
                    {
                        id_characteristics = id,
                        id_type_product = db.ProductTypes.Where(t => t.name == "Умный дом").Select(t => t.id).FirstOrDefault()
                    });
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 7 && p.id_characteristic == id).FirstOrDefault() == null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 7).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Add(new ProductCharacteristics
                        {
                            id_characteristic = id,
                            id_product = pr.id,
                            text = ""
                        });
                        db.SaveChanges();
                    }
                }
            }
            else
            {
                if (chType.Where(c => c.id_type_product == 7).FirstOrDefault() != null)
                {
                    db.CharacteristicByTypes.Remove(db.CharacteristicByTypes.Where(c => c.id_characteristics == id && c.id_type_product == 7).FirstOrDefault());
                    db.SaveChanges();
                }
                if (db.ProductCharacteristics.Where(p => p.products.id_type_product == 7 && p.id_characteristic == id).FirstOrDefault() != null)
                {
                    var products = db.Products.Where(p => p.id_type_product == 7).ToList();
                    foreach (var pr in products)
                    {
                        db.ProductCharacteristics.Remove(db.ProductCharacteristics.Where(p => p.id_characteristic == id && p.id_product == pr.id).FirstOrDefault());
                        db.SaveChanges();
                    }
                }
            }



            //object list_ = getCharacteristics();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Characteristics()
        {
            if (Session["userId"] != null)
            {
                ViewBag.characteristics = db.Characteristics.OrderBy(c=>c.name).ToList();
                return View();
            }
            else
                return Redirect("Index");
        }

        public ActionResult Home()
        {
            return View();
        }
        
        public ActionResult Headphones()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "НАУШНИКИ";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Наушники").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 1).ToList();
                ViewBag.titleID = 1;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult AddProduct(int product_type_id)
        {
            if (Session["userId"] != null)
            {
                ViewBag.characteristic = db.CharacteristicByTypes.Where(c => c.id_type_product == product_type_id).Select(c => c.characteristics.name).ToList();
                ViewBag.titleID = product_type_id;
                return View();
            }
            else
                return Redirect("Index");
        }
        [HttpPost]
        public ActionResult SaveProduct(int product_type_id, string name, HttpPostedFileBase main_files, IEnumerable<HttpPostedFileBase> files, int price,int count, string description,string guarant, string country, List<string> characteristic_name, List<string> characteristic)
        {
            Products product = new Products
            {
                name = name,
                id_type_product = product_type_id,
                price = price,
                count = count,
                description = description,
                guarant=guarant,
                country=country,
                date=DateTime.Now.Date
            };
            db.Products.Add(product);
            db.SaveChanges();
            string fileNameMain = System.IO.Path.GetFileName(main_files.FileName);
            main_files.SaveAs(Server.MapPath("~/Content/Image/" + fileNameMain));
            db.Photos.Add(new Photos
            {
                id_product = product.id,
                photo = "~/Content/Image/" + fileNameMain,
                is_main = true
            });
            db.SaveChanges();
            foreach (var f in files)
            {
                string fileName = System.IO.Path.GetFileName(f.FileName);
                f.SaveAs(Server.MapPath("~/Content/Image/" + fileName));
                db.Photos.Add(new Photos
                {
                    id_product = product.id,
                    photo = "~/Content/Image/" + fileName,
                    is_main = false
                });
                db.SaveChanges();
            }
            for(var i=0;i<characteristic.Count();i++)
            {
                var ch = characteristic_name[i];
                var id = db.Characteristics.Where(chh => chh.name == ch).FirstOrDefault();
                db.ProductCharacteristics.Add(new ProductCharacteristics
                {
                    id_characteristic = id.id,
                    id_product = product.id,
                    text = characteristic[i]
                });
                db.SaveChanges();
            }
            if(product_type_id==1)
                return RedirectToAction("Headphones");
            if (product_type_id == 2)
                return RedirectToAction("Acoustics");
            if (product_type_id == 3)
                return RedirectToAction("Cables");
            if (product_type_id == 4)
                return RedirectToAction("Drives");
            if (product_type_id == 5)
                return RedirectToAction("BackpacksAndBags");
            if (product_type_id == 6)
                return RedirectToAction("SmartWatch");
            if (product_type_id == 7)
                return RedirectToAction("SmartHouse");
            return View();
        }
        public ActionResult UpdateProduct(int id)
        {
            if (Session["userId"] != null)
            {
                ViewBag.product = db.Products.Where(p => p.id == id).FirstOrDefault();
                int product_type_id= db.Products.Where(p => p.id == id).Select(p=>p.id_type_product).FirstOrDefault();
                //var characteristic_name=db.CharacteristicByTypes.Where(c => c.id_type_product == product_type_id).Select(c => c.characteristics.name).ToList();
                var characteristic = db.ProductCharacteristics.Where(p => p.id_product == id).ToList();
                //ViewBag.characteristic_name = characteristic_name;
                //List<string>


                ViewBag.characteristic = characteristic;
                ViewBag.titleID = product_type_id;
                ViewBag.mainPhoto= db.Products.Where(p => p.id == id).Select(p => p.photo.FirstOrDefault()).FirstOrDefault();
                return View();
            }
            else
                return Redirect("Index");
        }
        public ActionResult SaveUpdateProduct(int id,int product_type_id, string name, int price, int count, string description, string guarant, string country, List<string> characteristic_name, List<string> characteristic)
        {

            Products product = db.Products.Where(p => p.id == id).FirstOrDefault();
            product.name = name;
            product.price = price;
            product.count = count;
            product.description = description;
            product.guarant = guarant;
            product.country = country;
            product.date = DateTime.Now.Date;
            db.SaveChanges();
            
            for (var i = 0; i < characteristic.Count(); i++)
            {
                var ch = characteristic_name[i];
                ProductCharacteristics prodChar = product.productCharacteristics.Where(p => p.characteriactics.name == ch).FirstOrDefault();
                prodChar.text = characteristic[i];
                db.SaveChanges();
            }
            if (product_type_id == 1)
                return RedirectToAction("Headphones");
            if (product_type_id == 2)
                return RedirectToAction("Acoustics");
            if (product_type_id == 3)
                return RedirectToAction("Cables");
            if (product_type_id == 4)
                return RedirectToAction("Drives");
            if (product_type_id == 5)
                return RedirectToAction("BackpacksAndBags");
            if (product_type_id == 6)
                return RedirectToAction("SmartWatch");
            if (product_type_id == 7)
                return RedirectToAction("SmartHouse");
            return View();
        }
        public JsonResult DeleteProduct(int id)
        {
            db.Products.Remove(db.Products.Where(p=>p.id==id).FirstOrDefault());
            db.SaveChanges();
            //object list_ = getCharacteristics();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Acoustics()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "АКУСТИКА";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Акустика").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 2).ToList();
                ViewBag.titleID = 2;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult Cables()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "КАБЕЛИ";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Кабели").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 3).ToList();
                ViewBag.titleID = 3;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult Drives()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "НАКОПИТЕЛИ";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Накопители").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 4).ToList();
                ViewBag.titleID = 4;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult BackpacksAndBags()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "РЮКЗАКИ И СУМКИ";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Рюкзаки и сумки").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 5).ToList();
                ViewBag.titleID = 5;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult SmartWatch()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "СМАРТ-ЧАСЫ";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Смарт-часы").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 6).ToList();
                ViewBag.titleID = 6;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult SmartHouse()
        {
            if (Session["userId"] != null)
            {
                ViewBag.title = "УМНЫЙ ДОМ";
                ViewBag.product = db.Products.Where(p => p.id_type_product == db.ProductTypes.Where(t => t.name == "Умный дом").Select(t => t.id).FirstOrDefault()).ToList();
                ViewBag.prodChar = db.CharacteristicByTypes.Where(p => p.id_type_product == 7).ToList();
                ViewBag.titleID = 7;
                return View("~/Views/Admin/Product.cshtml");
            }
            else
                return Redirect("Index");
        }
        public ActionResult Orders()
        {
            ViewBag.orders = db.Orders.OrderByDescending(o=>o.date).ToList();
            return View();
        }
        public JsonResult DeleteOrder(int id)
        {
            db.Orders.Remove(db.Orders.Where(p => p.id == id).FirstOrDefault());
            db.SaveChanges();
            //object list_ = getCharacteristics();
            return Json("ok", JsonRequestBehavior.AllowGet);
        }

    }
}