using AuctionDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiDemo.Controllers
{
    public class BidController : ApiController
    {
        public IEnumerable<Bid> get()
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Bids.ToList();
            }
        }
        /*
        public HttpResponseMessage Get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.Bids.FirstOrDefault(b => b.BidID == id);
                if (entity != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, entity);

                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Bid with id= " + id.ToString() + " not found");
                }
            }
        }
        */

        //use linq join 2 table
        /*
        public IEnumerable<object> Get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = (from b in entities.Bids
                              join i in entities.Items
                              on b.ItemID equals i.ItemID
                              where b.BidID== id
                              select new
                              {
                                  ID = b.BidID,
                                  ItemName = i.ItemName,
                                  Price = b.BidPrice
                              }).ToList();

                return entity;
            }
        }
        */
        public IEnumerable<object> get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled=false;
                var entity = entities.selectInfoBidsbyMemberID(id).ToList();
                return entity;
            }
        }
        public HttpResponseMessage Post([FromBody] Bid bid)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.Bids.Add(bid);
                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, bid);
                    message.Headers.Location = new Uri(Request.RequestUri + bid.BidID.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    Bid bid = entities.Bids.FirstOrDefault(b => b.BidID == id);
                    if (bid == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bid with Id = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entities.Bids.Remove(bid);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public HttpResponseMessage Put(int id, [FromBody] Bid bid)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    Bid entity = entities.Bids.FirstOrDefault(b => b.BidID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bid with Id = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.BidDateTime = bid.BidDateTime;
                        entity.BidPrice = bid.BidPrice;
                        entity.BidderID = bid.BidderID;
                        entity.ItemID = bid.ItemID;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, entity);
                    }

                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}

