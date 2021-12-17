
using AuctionDataAccess;
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
        /*
         * public IEnumerable<Item> get()
        {
             using(AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.Items.ToList();
            }
        }
        */

        // Get Item By id 
        /*
         public HttpResponseMessage Get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
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
        */


        // Get Count Item By ItemType 

        /*public int Get(int id)
       {
           using (AuctionEntities entities = new AuctionEntities())
           {
               entities.Configuration.ProxyCreationEnabled = false;
               int count = (from i in entities.Items where i.ItemTypeID == id select i).Count();
               return count;
           }
       }*/

        //Join 2 tabale by linq (Item and ItemType)
        /*
         public IEnumerable<object> Get()
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var kq = (from i in entities.Items
                             join it in entities.ItemTypes on i.ItemTypeID equals it.ItemTypeID                              
                             select new { 
                                 i.ItemID, 
                                 ItemName = i.ItemName,
                                 ItemTypeName= it.ItemTypeName                                 
                             }).ToList();
                return kq;
            }
        }
         */

        //get data by join 3 by linq table
        /*
        public IEnumerable<object> Get()
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var kq = (from i in entities.Items
                             join it in entities.ItemTypes on i.ItemTypeID equals it.ItemTypeID
                             join b in entities.Bids on i.ItemID equals b.ItemID    
                             select new { 
                                 i.ItemID, 
                                 ItemName = i.ItemName,
                                 ItemTypeName= it.ItemTypeName,
                                 BidId=b.BidID,
                                 BidPrice=b.BidPrice
                             }).ToList();
                return kq;
            }
        }
        */

        //use store procedure select 2 table
        //SelectItemByItemTypeId
        /*
        public IEnumerable<object> get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                return entities.SelectItemByItemTypeId(id).ToList();
            }
        }
        */
        
        //get top item byprice by strore procedure
        public IEnumerable<object> get()
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.selectTopItemByPrice().ToList();
                return entity; 
            }
        }

        public IEnumerable<object> get(int id)
        {
            using (AuctionEntities entities = new AuctionEntities())
            {
                entities.Configuration.ProxyCreationEnabled = false;
                var entity = entities.selectTopItemByPriceAndItemTypeID(id).ToList();
                return entity;
            }
        }
        
        //insert
        /*
        public HttpResponseMessage Post([FromBody] Item item)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
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
        */

        //insert by store procedure
        public HttpResponseMessage Post([FromBody] Item item)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    entities.insertItem(item.ItemTypeID, 
                        item.ItemName,
                        item.ItemDescription,
                        item.SellerID, 
                        item.MinimumBidIncrement, 
                        item.EndDateTime, 
                        item.CurrentPrice);

                    entities.SaveChanges();
                    var message = Request.CreateResponse(HttpStatusCode.Created, item);
                    message.Headers.Location = new Uri(Request.RequestUri +item.ToString());
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //method delete
        /*
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    Item item = entities.Items.FirstOrDefault(i => i.ItemID == id);
                    if (item == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item with Id = " + id.ToString() + " not found");
                    }
                    else{
                        entities.Items.Remove(item);
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK);
                    }
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }          
        }
        */

        //delete by store procedure
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    Item item = entities.Items.FirstOrDefault(i => i.ItemID == id);
                    if (item == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item with Id = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entities.deleteItem(id);
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
        //update
        /*
          public HttpResponseMessage Put(int id, [FromBody]Item item)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    Item entity = entities.Items.FirstOrDefault(i => i.ItemID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item with Id = " + id.ToString() + " not found");
                    }
                    else
                    {
                        entity.ItemDescription = item.ItemDescription;
                        entity.MinimumBidIncrement=item.MinimumBidIncrement;
                        entity.EndDateTime = item.EndDateTime;  
                        entity.ItemName= item.ItemName;
                        entity.CurrentPrice = item.CurrentPrice;
                        entity.SellerID = item.SellerID;
                        entity.ItemTypeID = item.ItemTypeID;
                        entities.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK,entity);
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        } */

        //update by store procedure
        public HttpResponseMessage Put(int id, [FromBody] Item item)
        {
            try
            {
                using (AuctionEntities entities = new AuctionEntities())
                {
                    entities.Configuration.ProxyCreationEnabled = false;
                    Item entity = entities.Items.FirstOrDefault(i => i.ItemID == id);
                    if (entity == null)
                    {
                        return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item with Id = " + id.ToString() + " not found");
                    }
                    else
                    {                       
                        entities.updateItem(item.ItemTypeID,
                            item.ItemName,
                            item.ItemDescription,
                            item.SellerID,
                            item.MinimumBidIncrement,
                            item.EndDateTime,
                            item.CurrentPrice,
                            entity.ItemID);
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
    }
}
