using ApiDemo.Models;
using AuctionDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ApiDemo.Controllers
{
    public class ItemTypeController : ApiController
    {
          public IEnumerable<ItemType> get()
        {
            using (var entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.ItemTypes.ToList();
            }
        }
        /*
        public ItemType Get(int id)
        {
            using(var entities= new AuctionEntities()){
                entities.Configuration.ProxyCreationEnabled=false;
                return entities.ItemTypes.FirstOrDefault(it=>it.ItemTypeID==id);
            }
        }
        */
       
        public IEnumerable<object> Get(int id)
        {
            using(var entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled=false;
                var entity = (from it in entities.ItemTypes
                              join i in entities.Items
                              on it.ItemTypeID equals i.ItemTypeID
                              where i.ItemTypeID == id
                              select i).ToList();
                return entity;
            }
        }
        
        public HttpResponseMessage Post([FromBody] ItemType it)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.ItemTypes.Add(it);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, it);
                    message.Headers.Location = new Uri(Request.RequestUri + it.ItemTypeID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public void Delete(int id)
        {
            using(var entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                ItemType at=entities.ItemTypes.FirstOrDefault(it=>it.ItemTypeID==id);
                entities.ItemTypes.Remove(at);
                entities.SaveChanges();
            }
        }
        public ItemType Put([FromBody] ItemType itemtype,int id)
        {
            using (var entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                ItemType it = entities.ItemTypes.FirstOrDefault(i => i.ItemTypeID == id);
                it.ItemTypeName = itemtype.ItemTypeName;
                entities.SaveChanges();
                return it;
            }
        }
    }
}