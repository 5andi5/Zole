using App.Zole.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace App.Zole.Repositories
{
    public static class Collections
    {
        public static MongoCollection<Game> Games
        {
            get
            {
                string connectionString=ConfigurationManager.AppSettings["mongo"];
                MongoClient client = new MongoClient(connectionString);
                MongoServer server = client.GetServer();
                MongoDatabase db= server.GetDatabase("Zole");
                MongoCollection<Game> result= db.GetCollection<Game>("Games");
                return result;
            }
        }
    }
}