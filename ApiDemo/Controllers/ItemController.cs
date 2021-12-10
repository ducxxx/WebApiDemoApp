using ItemDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ApiDemo.Controllers
{
    public class ItemController : ApiController
    {
        public IEnumerable<Item> get()
        {
             using(AuctionEntities entities = new AuctionEntities())
            {
                
                return entities.Items.ToList();
            }
        }
        public HttpResponseMessage Get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                var entity = entities.Items.FirstOrDefault(i=>i.ItemID==id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
                else
                {
                    return Request.CreateResponse( HttpStatusCode.NotFound, "Item with id= "+ id.ToString()+" not found");
                }
            }
        }
        public HttpResponseMessage Post([FromBody] Item item)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {

                    entities.Items.Add(item);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, item);
                    message.Headers.Location = new Uri(Request.RequestUri + item.ItemID.ToString());
                    return message;
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        [HttpDelete]
        public void Delete(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                Item item = entities.Items.FirstOrDefault(i => i.ItemID == id);
                entities.Items.Remove(item);
            }
        }

    }
}
