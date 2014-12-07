using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebServiceApp.Models
{
    public class BidRepository : IBidRepository
    {
        public BidRepository()
        {

        }

        public IEnumerable<BidClass> GetAll()
        {
            return RentDBManager.GetAllBid().Cast<BidClass>();
        }
        public BidClass GetByBid(double bid)
        {
            return RentDBManager.GetBidByBidAmt(bid);
        }
        public BidClass Add(BidClass item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.InsertBid(item) == 0)
            {
                return null;
            }
            else
            {
                return item;
            }
        }
        public void Remove(double bid)
        {
            RentDBManager.DeleteBid(bid);
        }
        public bool Update(BidClass item)
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
    }
}
