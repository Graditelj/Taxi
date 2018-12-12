using System.Collections.Generic;
using TaxiDispatcher.App.Models;
using static TaxiDispatcher.App.Scheduler;

namespace TaxiDispatcher.App
{
    public static class InMemoryRideDataBase
    {
        public static List<Ride> Rides = new List<Ride>();

        public static void SaveRide(Ride ride)
        {
            int max_id = Rides.Count == 0 ? 0 : Rides[0].Id;
            foreach (Ride r in Rides)
            {
                if (r.Id > max_id)
                    max_id = r.Id;
            }

            ride.Id = max_id + 1;
            Rides.Add(ride);
        }

        public static Ride GetRide(int id)
        {
            Ride ride = Rides[0];
            bool found = ride.Id == id;
            int current = 1;
            while (!found)
            {
                ride = Rides[current];
                found = ride.Id == id;
                current += 1;
            }

            return ride;
        }

        public static List<int> GetRideIds()
        {
            List<int> ids = new List<int>();
            foreach (Ride ride in Rides)
            {
                ids.Add(ride.Id);
            }

            return ids;
        }

        public static List<Ride> GetRideList(int driverId)
        {
            List<Ride> rides = new List<Ride>();
            List<int> ids = GetRideIds();

            foreach (int id in ids)
            {
                Ride ride = GetRide(id);
                if (ride.Taxi.Driver.Id == driverId)
                    rides.Add(ride);
            }

            return rides;
        }
    }
}
