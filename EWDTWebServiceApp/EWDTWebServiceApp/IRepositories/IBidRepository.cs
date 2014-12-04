using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace EWDTWebServiceApp.Models
{
    interface IBidRepository
    {
        IEnumerable<BidClass> GetAll();
        BidClass GetByBid(string bid);
        BidClass Add(BidClass item);
        void Remove(string bid);
        bool Update(BidClass item);
    }
}
