using Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ConnectWebApp.APIs
{
    public class ChangeOponentController : ApiController
    {
        private IGameController connectGameController;

        public ChangeOponentController(IGameController connectGameController)
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
  
        // PUT api/<controller>/5
        public void Put(string id, [FromBody]string value)
        {
        }
    }
}