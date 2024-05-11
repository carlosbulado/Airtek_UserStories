using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserStories.Domain;

namespace UserStories
{
    public class UserStoryNumber1
    {
        private static int QTY_DAYS_CAN_BE_SCHEDULED = 2;
        private static int QTY_FLIGHTS_PER_DAY = 3;
        private static string DEFAULT_AIRPORT = "YUL";
        public static void Main()
        {
            List<FlightSchedule> flights = new List<FlightSchedule>();
            Console.WriteLine("Welcome to User Story #1!");
            while (true)
            {
                int option = 0;
                Console.WriteLine("Options: ");
                Console.WriteLine("     1 - Load flight schedule");
                Console.WriteLine("     2 - List flights");
                Console.WriteLine("     0 - Exit User Story #1");
                if (int.TryParse(Console.ReadLine(), out option))
                {
                    switch (option)
                    {
                        case 0:
                            Console.WriteLine("Back to Main Screen...");
                            return;
                        case 1:
                            int flightDay = (flights.Count / QTY_FLIGHTS_PER_DAY) + 1;
                            if (flightDay > QTY_DAYS_CAN_BE_SCHEDULED)
                            {
                                Console.WriteLine(string.Format("You can only book {0} days of flights", QTY_DAYS_CAN_BE_SCHEDULED));
                            }
                            else
                            {
                                Console.WriteLine("Where to (Enter the airport reference ID):");
                                string flightTo = Console.ReadLine();
                                flights.Add(new FlightSchedule(flights.Count + 1, DEFAULT_AIRPORT, flightTo, flightDay));
                            }
                            break;
                        case 2:
                            Console.WriteLine("Showing list of flights -->");
                            foreach (var item in flights)
                            {
                                Console.WriteLine(item.ToStringWithoutOrder());
                            }
                            Console.WriteLine("");
                            break;
                    }
                }
            }
        }
    }
}
