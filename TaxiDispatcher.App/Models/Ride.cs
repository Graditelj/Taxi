using System;
using System.Collections.Generic;
using static TaxiDispatcher.App.Global;

namespace TaxiDispatcher.App.Models
{
    public class Ride
    {
        #region Properties

        public int Id { get; set; }
        public int LocationFrom { get; set; }
        public int LocationTo { get; set; }
        public Taxi Taxi { get; set; }
        public RideType RideType { get; set; }
        public DateTime Time { get; set; }

        public int Price
        {
            get
            {
                int price = Taxi.Company.PriceFactor * Math.Abs(LocationFrom - LocationTo);

                if (RideType == RideType.InterCity)
                {
                    price *= 2;
                }

                if (Time.Hour < 6 || Time.Hour > 22)
                {
                    price *= 2;
                }

                return price;
            }
        }

        #endregion
    }
}
