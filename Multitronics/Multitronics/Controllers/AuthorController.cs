using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Multitronics.Controllers
{
    public class AuthorController : Controller
    {
        //
        // GET: /Author/

        public ActionResult Index(string name)
        {
            string s = "";
            if (name == null)
            {
                s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Авторы</title></head><body><ul><li><a href='?name=futupas'>Futupas</a></li><li><a href='?name=vadim'>Vadim</a></li><li><a href='?name=sprox'>Sprox</a></li><li><a href='?name=garryjane'>GarryJane</a></li><li><a href='?name=xfreed'>xfreed</a></li><li><a href='?name=nick'>nick</a></li></ul></body></html>";
            }
            else
            {
                switch (name.ToLowerInvariant())
                {
                    case "futupas": s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Автор</title></head><body><h2>Olexandr 'futupas' Panov</h2><p>Главный в проекте. Занимается базой данных и сервером. Помогал писать клиент.</p><p><a href='https://github.com/Futupas'>GitHub</a>, почта futupas@gmail.com</p></body></html>"; break;
                    case "vadim": s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Автор</title></head><body><h2>Vadim Gorkun</h2><p>Заказчик и дизайнер</p><p>Почта vgorkyn@mail.ru</p></body></html>"; break;
                    case "sprox": s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Автор</title></head><body><h2>Sergey 'sprox' Proskuryakov</h2><p>Помогал писать клиент.</p><p><a href='https://github.com/ProxS'>GitHub</a></p></body></html>"; break;
                    case "garryjane": s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Автор</title></head><body><h2>Михаил 'ddl' Молчанов</h2><p>Занимался JavaScript</p><p><a href='https://github.com/GarryJane'>GitHub</a></p></body></html>"; break;
                    case "xfreed": s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Автор</title></head><body><h2>Михайло 'xfreed' Кунинець</h2><p>Писал базу данных и сервер</p><p><a href='https://github.com/xfreed'>GitHub</a></p></body></html>"; break;
                    case "nick": s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Автор</title></head><body><h2>Nick 'nick' Sherbakov</h2><p>Главный в проекте. Занимается базой данных и сервером. Помогал писать клиент.</p><p><a href='https://github.com/sherbakov1'>GitHub</a></p></body></html>"; break;
                    default:
                        s = "<!DOCTYPE html><html lang='ru'><head><meta charset='UTF-8'><title>Авторы</title></head><body><ul><li><a href='?name=futupas'>Futupas</a></li><li><a href='?name=vadim'>Vadim</a></li><li><a href='?name=sprox'>Sprox</a></li><li><a href='?name=garryjane'>GarryJane</a></li><li><a href='?name=xfreed'>xfreed</a></li><li><a href='?name=nick'>nick</a></li></ul></body></html>";
                        break;
                }
            }
            return Content(s);
        }

    }
}
