using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace MyGym.Service.Models.APIHelper
{
    public enum Tipo
    {
        GET, POST
    }
    public enum Definition
    {
        URL, BODY
    }
    public class APIObject
    {
        [Key]
        public int ObjectId { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string JsonPost { get; set; }
        public string JsonGet { get; set; }
        public string Sample { get; set; }
        public string Description { get; set; }
        public Tipo Type { get; set; }

        public virtual ICollection<APIParameter> Parameters { get; set; }
    }
    public class APIParameter
    {
        [Key]
        public int ParamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public Definition Definition { get; set; }
        public int ObjectID { get; set; }
        public virtual APIObject APIObject { get; set; }
    }
}