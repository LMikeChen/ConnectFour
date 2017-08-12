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
    public class MoveController : ApiController
    {
        private IGameController connectGameController;

      //  [Inject]
        public MoveController(IGameController connectGameController)
        {
            this.connectGameController = connectGameController;
        }

        public IGameController ConnectGameController
        {
            get
            {
                //if (connectGameController == null)
                //{
                //    connectGameController = connectGameController = DependencyResolver.Current.GetService<IGameController>();
                //}
                return connectGameController;

            }
        }
        
        // PUT api/<controller>/5
        public IMoveResult Put(int id, [FromBody]string value)
        {
            IMoveResult  result = ConnectGameController.ProcessMove(id);

            return result;
            
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}