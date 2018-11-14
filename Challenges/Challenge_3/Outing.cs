using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3 {
    public enum EventType { Golf, Bowling, AmusementPark, Concert }

    class Outing {
        public EventType TypeOfEvent { get; set; }
        public DateTime DateOfEvent { get; set; }
        public int NumAttendees { get; set; }
        public double TicketCost { get; set; }
        public double TotalCost { get; set; }

        public Outing(EventType typeofevent, DateTime dateofevent, int numattendees, double ticketcost) {
            TypeOfEvent = typeofevent;
            DateOfEvent = dateofevent;
            NumAttendees = numattendees;
            TicketCost = ticketcost;
            TotalCost = Math.Round(TicketCost*NumAttendees, 2);
        }
    }
}
