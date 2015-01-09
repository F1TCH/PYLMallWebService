using EWDTWebService.Class;
using EWDTWebService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebService.Repository
{
    public class BidRepository : IBidRepository
    {
          public BidRepository()
        {

        }

        public BidClass Bid(BidClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.CreateBid(item) == 0)
            {
                return null;
            }
            else
            {
                return item;
            }
            //return item;
        }


        public BidClass RetrieveBid(string userID)
        {
            return RentDBManager.RetrieveBid(userID);
        }

        public bool UpdateBid(BidClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.UpdateBid(item) == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void DeleteBid(string id)
        {
            RentDBManager.DeleteBid(id);
        }
    }
}