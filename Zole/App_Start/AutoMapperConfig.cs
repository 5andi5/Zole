using App.Zole.ApiModels;
using App.Zole.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Zole
{
    public class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.CreateMap<Game, ApiGame>();
            Mapper.CreateMap<Player, ApiPlayer>();
        }
    }
}