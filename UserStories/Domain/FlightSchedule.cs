using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserStories.Domain
{
    public class FlightSchedule
    {
        public int FlightNumber { get; set; }
        public string FlightFrom { get; set; }
        public string FlightTo { get; set; }
        public int FlightDay { get; set; }
        public string OrderNumber { get; set; }

        public FlightSchedule() { }

        public FlightSchedule(int flightNumber, string flightFrom, string flightTo, int flightDay, string orderNumber = "")
        {
            this.FlightNumber = flightNumber;
            this.FlightFrom = flightFrom;
            this.FlightTo = flightTo;
            this.FlightDay = flightDay;
            this.OrderNumber = orderNumber;
        }

        public string ToStringWithoutOrder()
        {
            return string.Format("Flight: {0}, departure: {1}, arrival: {2}, day: {3}", this.FlightNumber, this.FlightFrom, this.FlightTo, this.FlightDay);
        }

        public string ToStringWithOrder()
        {
            return string.Format("order: {4}, flightNumber: {0}, departure: {1}, arrival: {2}, day: {3}", this.FlightNumber, this.FlightFrom, this.FlightTo, this.FlightDay, this.OrderNumber);
        }
    }
}
