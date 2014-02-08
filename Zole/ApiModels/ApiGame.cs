using App.Zole.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole.ApiModels
{
    public class ApiGame
    {
        public ObjectId id { get; set; }
        public ApiPlayer[] players { get; set; }
    }
}