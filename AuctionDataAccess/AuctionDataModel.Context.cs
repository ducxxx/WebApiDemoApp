﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuctionDataAccess
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AuctionEntities : DbContext
    {
        public AuctionEntities()
            : base("name=AuctionEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<Bid> Bids { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    
        public virtual ObjectResult<SelectItemById_Result> SelectItemById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectItemById_Result>("SelectItemById", idParameter);
        }
    
        public virtual ObjectResult<SelectItemByItemTypeId_Result> SelectItemByItemTypeId(Nullable<int> itemtypeid)
        {
            var itemtypeidParameter = itemtypeid.HasValue ?
                new ObjectParameter("itemtypeid", itemtypeid) :
                new ObjectParameter("itemtypeid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SelectItemByItemTypeId_Result>("SelectItemByItemTypeId", itemtypeidParameter);
        }
    
        public virtual ObjectResult<selectInfoBidsbyMemberID_Result> selectInfoBidsbyMemberID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectInfoBidsbyMemberID_Result>("selectInfoBidsbyMemberID", idParameter);
        }
    
        public virtual ObjectResult<selectTopItemByPrice_Result> selectTopItemByPrice()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectTopItemByPrice_Result>("selectTopItemByPrice");
        }
    
        public virtual ObjectResult<selectTopItemByPriceAndItemTypeID_Result> selectTopItemByPriceAndItemTypeID(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<selectTopItemByPriceAndItemTypeID_Result>("selectTopItemByPriceAndItemTypeID", idParameter);
        }
    
        public virtual int insertItem(Nullable<int> itemTypeID, string itemName, string itemDescription, Nullable<int> sellerID, Nullable<double> minimumBidIncrement, Nullable<System.DateTime> endDateTime, Nullable<double> currentPrice)
        {
            var itemTypeIDParameter = itemTypeID.HasValue ?
                new ObjectParameter("itemTypeID", itemTypeID) :
                new ObjectParameter("itemTypeID", typeof(int));
    
            var itemNameParameter = itemName != null ?
                new ObjectParameter("itemName", itemName) :
                new ObjectParameter("itemName", typeof(string));
    
            var itemDescriptionParameter = itemDescription != null ?
                new ObjectParameter("itemDescription", itemDescription) :
                new ObjectParameter("itemDescription", typeof(string));
    
            var sellerIDParameter = sellerID.HasValue ?
                new ObjectParameter("sellerID", sellerID) :
                new ObjectParameter("sellerID", typeof(int));
    
            var minimumBidIncrementParameter = minimumBidIncrement.HasValue ?
                new ObjectParameter("minimumBidIncrement", minimumBidIncrement) :
                new ObjectParameter("minimumBidIncrement", typeof(double));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var currentPriceParameter = currentPrice.HasValue ?
                new ObjectParameter("currentPrice", currentPrice) :
                new ObjectParameter("currentPrice", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertItem", itemTypeIDParameter, itemNameParameter, itemDescriptionParameter, sellerIDParameter, minimumBidIncrementParameter, endDateTimeParameter, currentPriceParameter);
        }
    
        public virtual int updateItem(Nullable<int> itemTypeID, string itemName, string itemDescription, Nullable<int> sellerID, Nullable<double> minimumBidIncrement, Nullable<System.DateTime> endDateTime, Nullable<double> currentPrice, Nullable<int> itemID)
        {
            var itemTypeIDParameter = itemTypeID.HasValue ?
                new ObjectParameter("itemTypeID", itemTypeID) :
                new ObjectParameter("itemTypeID", typeof(int));
    
            var itemNameParameter = itemName != null ?
                new ObjectParameter("itemName", itemName) :
                new ObjectParameter("itemName", typeof(string));
    
            var itemDescriptionParameter = itemDescription != null ?
                new ObjectParameter("itemDescription", itemDescription) :
                new ObjectParameter("itemDescription", typeof(string));
    
            var sellerIDParameter = sellerID.HasValue ?
                new ObjectParameter("sellerID", sellerID) :
                new ObjectParameter("sellerID", typeof(int));
    
            var minimumBidIncrementParameter = minimumBidIncrement.HasValue ?
                new ObjectParameter("minimumBidIncrement", minimumBidIncrement) :
                new ObjectParameter("minimumBidIncrement", typeof(double));
    
            var endDateTimeParameter = endDateTime.HasValue ?
                new ObjectParameter("endDateTime", endDateTime) :
                new ObjectParameter("endDateTime", typeof(System.DateTime));
    
            var currentPriceParameter = currentPrice.HasValue ?
                new ObjectParameter("currentPrice", currentPrice) :
                new ObjectParameter("currentPrice", typeof(double));
    
            var itemIDParameter = itemID.HasValue ?
                new ObjectParameter("itemID", itemID) :
                new ObjectParameter("itemID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateItem", itemTypeIDParameter, itemNameParameter, itemDescriptionParameter, sellerIDParameter, minimumBidIncrementParameter, endDateTimeParameter, currentPriceParameter, itemIDParameter);
        }
    }
}
