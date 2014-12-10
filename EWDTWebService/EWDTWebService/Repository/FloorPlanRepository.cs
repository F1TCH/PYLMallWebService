using EWDTWebService.Class;
using EWDTWebService.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EWDTWebService.Repository
{
    public class FloorPlanRepository : IFloorPlanRepository
    {
        public FloorPlanRepository()
        {

        }
        public FloorPlan Add(FloorPlan item)//register
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            if (RentDBManager.InsertUser(item) == 0)
            {
                return null;
            }

            else
            {
                return item;
            }
        }

        public FloorPlan GetUserByUsername(string id) //login
        {
            return RentDBManager.GetUserbyUsername(id);
        }

        //public UserAccount GetEmailbyUsername(string id) //login
        //{
        //    return RentDBManager.GetEmailbyUsername(id);
        //}

        public void Remove(string id)//delete
        {
            RentDBManager.DeleteUser(id);
        }

        //public bool UpdateUserPassword(UserAccount password)
        //{
        //    if (password == null)
        //    {
        //        throw new ArgumentNullException("password");
        //    }
        //    if (RentDBManager.UpdateUserPassword(password) == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
        //public bool UpdateUserEmail(UserAccount email)
        //{
        //    if (email == null)
        //    {
        //        throw new ArgumentNullException("email");
        //    }
        //    if (RentDBManager.UpdateUserEmail(email) == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}