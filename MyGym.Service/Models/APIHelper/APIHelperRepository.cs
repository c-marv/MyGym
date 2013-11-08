using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyGym.Service.Models.APIHelper
{
    public class APIHelperRepository
    {
        public IEnumerable<APIObject> GetAll()
        {
            return APIHelper.Context.API.AsEnumerable();
        }
        public APIObject Get(int id)
        {
            return APIHelper.Context.API.FirstOrDefault(item => item.ObjectId == id);
        }

    }
}