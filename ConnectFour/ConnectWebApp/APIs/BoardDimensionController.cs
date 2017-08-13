using Common.Interface;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace ConnectWebApp.APIs
{
    public class BoardDimensionController : ApiController
    {
        private IGameController connectGameController;

        public BoardDimensionController(IGameController connectGameController)
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
        // GET api/<controller>
        public IEnumerable<int> Get()
        {
            return new int[] { ConnectGameController.BoardRows, ConnectGameController.BoardColumns};
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

    }
}