using Biklas_API_V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Biklas_API_V2.Controllers
{
    public class BKBaseApiController : ApiController
    {
        private BiklasEntities _db = null;
        public BiklasEntities db
        {
            get
            {
                if(_db == null)
                {
                    _db = new BiklasEntities();
                }

                return _db;
            }
        }
    }
}