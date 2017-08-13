using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectWebApp.Controllers
{
    public class HomeController : Controller
    {

        private IGameController connectGameController;

        public HomeController(IGameController connectGameController)
        {
            this.connectGameController = connectGameController;
        }

        public IGameController ConnectGameController
        {
            get
            {
                return connectGameController;
            }
        }

        // GET: Home
        public ActionResult Index()
        {
            connectGameController.Reset();
            return View();
        }
    }
}