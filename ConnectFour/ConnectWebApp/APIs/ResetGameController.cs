using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConnectWebApp.APIs
{
    public class ResetGameController : ApiController
    {
        private IGameController connectGameController;

        public ResetGameController(IGameController connectGameController)
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

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
            ConnectGameController.Reset();
        }

    }
}