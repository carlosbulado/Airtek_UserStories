using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Domain;

namespace UserStories
{
    public class OrderJsonData
    {
        public string destination { get; set; }
    }

    public class UserStoryNumber2
    {
        private static int QTY_DAYS_CAN_BE_SCHEDULED = 2;
        private static int QTY_FLIGHTS_PER_DAY = 3;
        private static int MAX_CARGO_PER_FLIGHT = 20;
        private static string DEFAULT_AIRPORT = "YUL";
        public static void Main()
        {
            List<FlightSchedule> flights = new List<FlightSchedule>();
            Console.WriteLine("Welcome to User Story #2!");
            while (true)
            {
                int option = 0;
                Console.WriteLine("Options: ");
                Console.WriteLine("     1 - Load batch of orders from JSON file");
                Console.WriteLine("     2 - List order flights");
                Console.WriteLine("     0 - Exit User Story #2");
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 0:
                            Console.WriteLine("Back to Main Screen...");
                            return;
                        case 1:
                            flights = new List<FlightSchedule>();
                            using (StreamReader r = new StreamReader("OrdersToLoad.json"))
                            {
                                string json = r.ReadToEnd();
                                try
                                {
                                    Dictionary<string, OrderJsonData> items = JsonConvert.DeserializeObject<Dictionary<string, OrderJsonData>>(json);
                                    foreach (var item in items)
                                    {
                                        var flightDestintionGrouped = flights.FindAll(x => x.FlightTo == item.Value.destination).Select(x => new { x.FlightNumber, x.FlightTo }).GroupBy(x => x.FlightNumber);
                                        FlightSchedule flightForReference = null;
                                        foreach (var flight in flightDestintionGrouped)
                                        {
                                            if(flight.Count() > 0 && flight.Count() < MAX_CARGO_PER_FLIGHT)
                                            {
                                                flightForReference = flights.First(x => x.FlightNumber == flight.Key);
                                            }
                                        }
                                        if (flightForReference != null)
                                        {
                                            flights.Add(new FlightSchedule(flightForReference.FlightNumber, flightForReference.FlightFrom, flightForReference.FlightTo, flightForReference.FlightDay, item.Key));
                                        }
                                        else
                                        {
                                            var diffFlights = flights.Count > 0 ? flights.Max(x => x.FlightNumber) + 1 : 1;
                                            var distinctFlights = flights.Select(x => x.FlightNumber).Distinct();
                                            int flightDay = (distinctFlights.Count() / QTY_FLIGHTS_PER_DAY) + 1;
                                            if (flightDay <= QTY_DAYS_CAN_BE_SCHEDULED)
                                            {
                                                flights.Add(new FlightSchedule(diffFlights, DEFAULT_AIRPORT, item.Value.destination, flightDay, item.Key));
                                            }
                                        }
                                    }
                                    Console.WriteLine("Flights loaded!");
                                }
                                catch { Console.WriteLine("Error"); }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Showing list of flights -->");
                            using (StreamReader r = new StreamReader("OrdersToLoad.json"))
                            {
                                string json = r.ReadToEnd();
                                try
                                {
                                    Dictionary<string, OrderJsonData> items = JsonConvert.DeserializeObject<Dictionary<string, OrderJsonData>>(json);
                                    foreach (var item in items)
                                    {
                                        var possibleFlight = flights.Find(x => x.OrderNumber == item.Key);
                                        if (possibleFlight != null)
                                        {
                                            Console.WriteLine(possibleFlight.ToStringWithOrder());
                                        }
                                        else
                                        {
                                            Console.WriteLine(String.Format("order: {0}, flightNumber: not scheduled", item.Key));
                                        }
                                    }
                                }
                                catch { Console.WriteLine("Error"); }
                            }
                            Console.WriteLine("");
                            break;
                    }
                }
            }
        }
    }
}
