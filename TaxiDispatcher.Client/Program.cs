﻿using System;
using TaxiDispatcher.App;
using TaxiDispatcher.App.Models;
using static TaxiDispatcher.App.Global;

namespace TaxiDispatcher.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Scheduler scheduler = new Scheduler();

            try
            {
                Console.WriteLine("Ordering ride from 5 to 0...");
                Ride ride = scheduler.OrderRide(5, 0, RideType.City, new DateTime(2018, 1, 1, 23, 0, 0));
                scheduler.AcceptRide(ride);
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                if (e.Message == "There are no available taxi vehicles!")
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("");
                }
                else
                    throw;
            }

            try
            {
                Console.WriteLine("Ordering ride from 0 to 12...");
                Ride ride = scheduler.OrderRide(0, 12, RideType.InterCity, new DateTime(2018, 1, 1, 9, 0, 0));
                scheduler.AcceptRide(ride);
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                if (e.Message == "There are no available taxi vehicles!")
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("");
                }
                else
                    throw;
            }

            try
            {
                Console.WriteLine("Ordering ride from 5 to 0...");
                Ride ride = scheduler.OrderRide(5, 0, RideType.City, new DateTime(2018, 1, 1, 11, 0, 0));
                scheduler.AcceptRide(ride);
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                if (e.Message == "There are no available taxi vehicles!")
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("");
                }
                else
                    throw;
            }

            try
            {
                Console.WriteLine("Ordering ride from 35 to 12...");
                Ride ride = scheduler.OrderRide(35, 12, RideType.City, new DateTime(2018, 1, 1, 11, 0, 0));
                scheduler.AcceptRide(ride);
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                if (e.Message == "There are no available taxi vehicles!")
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("");
                }  
                else
                    throw;
            }

            Console.WriteLine("Driver with ID = 2 earned today:");
            int total = 0;
            foreach (Ride r in InMemoryRideDataBase.GetRideList(2))
            {
                total += r.Price;
                Console.WriteLine("Price: " + r.Price);
            }
            Console.WriteLine("Total: " + total);

            Console.ReadLine();
        }
    }
}
