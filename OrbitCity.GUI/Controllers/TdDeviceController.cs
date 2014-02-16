using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrbitCity.API.Client;
using OrbitCity.API.DTO;

namespace OrbitCity.GUI.Controllers
{
    public class TdDeviceController : Controller
    {
        string server;
        private Telldus Td;

        public TdDeviceController()
        {
            server = "http://192.168.1.94:4567";
            Td = new Telldus(server);
        }

        public ActionResult Index()
        {
            List<TdDevice> TdList = Td.Get<List<TdDevice>>("device/all");
            return View( TdList );
        }


        public ActionResult On(int Id)
        {
            Td.Get<dynamic>("device/" + Id + "/switch/on");
            return new EmptyResult();
        }
        // /tddevice/off/:id
        public ActionResult Off(int Id)
        {
            Td.Get<dynamic>("device/" + Id + "/switch/off");
            return new EmptyResult();
        }
        // /tddevice/dim/:id?Lvl=20
        public ActionResult Dim(int Id, int Lvl)
        {
            Td.Get<dynamic>("device/" + Id + "/dim/" + Lvl);
            return new EmptyResult();
        }
    }
}
