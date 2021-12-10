using ApiDemo.Models;
using AuctionDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiDemo.Controllers
{
    public class AuctionController : Controller
    {
        
        public IEnumerable<ItemType> get()
        {
            using (AuctionEntities entities = new AuctionEntities())
            {

                return entities.ItemTypes.ToList();
            }
        }
    }
}