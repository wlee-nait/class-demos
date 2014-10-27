using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using eRestaurantSystem.Entities;
using eRestaurantSystem.DAL;
using System.ComponentModel;
using eRestaurantSystem.POCOs;
#endregion

namespace eRestaurantSystem.BLL
{
    [DataObject]
    public class eRestaurantController
    {
        #region SpecialEvents
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<SpecialEvent> SpecialEvent_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                //using Context DBSet to get entity data
                //return context.SpecialEvents.ToList();

                //get a list of instances for entity using LINQ
                var results = from item in context.SpecialEvents select item;
                return results.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public SpecialEvent SpecialEventByEventCode(string eventcode)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.SpecialEvents.Find(eventcode);
            }
        }
        [DataObjectMethod(DataObjectMethodType.Insert,false)]
        public void SpecialEvents_Add(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                SpecialEvent added = null;
                added = context.SpecialEvents.Add(item);
                // saves the add to the database
                // evaluates the annotaions (validation) on your entity
                // [Required],[StringLength],[Range],...
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Update,false)]
        public void SpecialEvents_Update(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                context.Entry<SpecialEvent>(context.SpecialEvents.Attach(item)).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete,false)]
        public void SpecialEvents_Delete(SpecialEvent item)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                SpecialEvent existing = context.SpecialEvents.Find(item.EventCode);
                context.SpecialEvents.Remove(existing);
                context.SaveChanges();
            }
        }
        #endregion

        #region Reservations
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> Reservation_List()
        {
            //interfacing with our Context class
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Reservations.ToList();
            }
        }
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Reservation> ReservationbyEvent(string eventcode)
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                return context.Reservations.Where(anItem => anItem.Eventcode == eventcode).ToList();
            }
        }
        #endregion

        #region Reports
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<POCOs.CategoryMenuItems> GetReportCategoryMenuItems()
        {
            using (eRestaurantContext context = new eRestaurantContext())
            {
                var results = from data in context.Items
                              select new POCOs.CategoryMenuItems
                              {
                                  CategoryDescription = data.MenuCategories.Description,
                                  ItemDescription = data.Description,
                                  Price = data.CurrentPrice,
                                  Calories = data.Calories,
                                  Comment = data.Comment
                              };
                return results.ToList(); // this was .Dump() in Linqpad
            }
        }
        #endregion

        #region Linq Queries
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public List<CategoryMenuItems> GetCategoryMenuItems()
        {
            using(eRestaurantContext context = new eRestaurantContext())
            {
                var results = from cat in context.MenuCategories
                              orderby cat.Description
                              select new CategoryMenuItems()
                              {
                                  Description = cat.Description,
                                  MenuItems = from item in cat.Items
                                              where item.Active
                                              select new MenuItem()
                                              {
                                                  Description = item.Description,
                                                  Price = item.CurrentPrice,
                                                  Calories = item.Calories,
                                                  Comment = item.Comment
                                              }
                              };
                return results.ToList(); // this was .Dump() in Linqpad
            }
        }
        #endregion

        #region UXClockpicker
        [DataObjectMethod(DataObjectMethodType.Select,false)]
        public DateTime GetLastBillDateTime()
        {
            using (var context = new eRestaurantContext())
            {
                var results = context.Bill.Max(x => x.BillDate);
                return results;
            }
        }
        #endregion
    }
}
