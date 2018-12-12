using System;
using System.Collections.Generic;
using TaxiDispatcher.App.Models;
using static TaxiDispatcher.App.Global;

namespace TaxiDispatcher.App
{
    public class Scheduler
    {
        #region Taxi Arsenal

        private static List<TaxiDriver> Drivers = new List<TaxiDriver>()
        {
            new TaxiDriver("Predrag"),
            new TaxiDriver("Nenad"),
            new TaxiDriver("Dragan"),
            new TaxiDriver("Goran")
        };

        private static List<TaxiCompany> Companies = new List<TaxiCompany>()
        {
            new TaxiCompany { Name = "Naxi", PriceFactor = 10 },
            new TaxiCompany { Name = "Alfa", PriceFactor = 15 },
            new TaxiCompany { Name = "Gold", PriceFactor = 13 }
        };

        private static List<Taxi> Taxis = new List<Taxi>()
        {
            new Taxi { Driver = Drivers[0], Company = Companies[0], Location = 1 },
            new Taxi { Driver = Drivers[1], Company = Companies[0], Location = 4 },
            new Taxi { Driver = Drivers[2], Company = Companies[1], Location = 6 },
            new Taxi { Driver = Drivers[3], Company = Companies[2], Location = 7 }
        };

        #endregion

        /// <summary>
        /// Order a ride with the closest taxi to the destination.
        /// </summary>
        /// <param name="locationFrom">Location of the customer</param>
        /// <param name="locationTo">Location of the destination</param>
        /// <param name="rideType">Within city or between cities</param>
        /// <param name="time">Time of the order</param>
        /// <returns></returns>
        public Ride OrderRide(int locationFrom, int locationTo, RideType rideType, DateTime time)
        {
            Taxi closestTaxi = GetClosestTaxi(locationFrom, locationTo);

            if (closestTaxi == null || Math.Abs(closestTaxi.Location - locationFrom) > DISTANCE_THRESHOLD)
                throw new Exception("There are no available taxi vehicles!");

            Ride ride = new Ride { Taxi = closestTaxi, LocationFrom = locationFrom, LocationTo = locationTo, RideType = rideType, Time = time };

            Console.WriteLine("Ride ordered, price: " + ride.Price.ToString());

            return ride;
        }

        public void AcceptRide(Ride ride)
        {
            InMemoryRideDataBase.SaveRide(ride);
            
            ride.Taxi.Location = ride.LocationTo;

            Console.WriteLine("Ride accepted, waiting for driver: " + ride.Taxi.Driver.Name);
        }

        public Taxi GetClosestTaxi(int locationFrom, int locationTo)
        {
            if (Taxis == null || Taxis.Count == 0)
                return null;

            Taxi closestTaxi = Taxis[0];

            foreach (Taxi taxi in Taxis)
                if (Math.Abs(taxi.Location - locationFrom) < Math.Abs(closestTaxi.Location - locationFrom))
                    closestTaxi = taxi;

            return closestTaxi;
        }
    }
}
