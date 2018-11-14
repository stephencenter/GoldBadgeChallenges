using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3 {
    class ProgramUI {
        private OutingRepository outingrepo = new OutingRepository();
        private string divider = new String('-', 25);

        public void Run() {
            Console.WriteLine("Welcome to Komodo Enterprise's patended Outing Management System!");
            ChooseAnOption();
        }

        public string Input(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void ChooseAnOption() {
            while (true) {
                // Display a list of all outings.
                // Add individual outings to a list(don't need to worry about delete yet)
                // Calculations: 
                //   They'd like to see a display for the combined cost for all outings.
                //   They'd like to see a display of outing costs by type.
                //       For example, all bowling outings for the year were $2000.00.
                //       All Concert outings cost $5000.00.

                Console.WriteLine(divider);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("      [1] Add a new outing");
                Console.WriteLine("      [2] View list of outings");
                Console.WriteLine("      [3] Get Outing Costs");
                Console.WriteLine("      [4] Exit Program");

                while (true) {
                    string chosen = Input("Input [#]: ");

                    if (chosen == "1") {
                        Console.WriteLine(divider);
                        AddNewOuting();
                        break;
                    }

                    else if (chosen == "2") {
                        Console.WriteLine(divider);
                        if (outingrepo.GetList().Count > 0) {
                            ViewOutingList();
                        }

                        else {
                            Console.WriteLine("You have not added any outings yet.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "3") {
                        Console.WriteLine(divider);
                        if (outingrepo.GetList().Count > 0) {
                            GetOutingCosts();
                        }

                        else {
                            Console.WriteLine("You have not added any outings yet.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "4") {
                        System.Environment.Exit(1);
                    }
                }
            }
        }

        private void AddNewOuting() {
            //public EventType TypeOfEvent { get; set; }
            //public DateTime DateOfEvent { get; set; }
            //public int NumAttendees { get; set; }
            //public double TicketCost { get; set; }

            Console.WriteLine("What type of outing is this?");
            Console.WriteLine("      [1] Golf");
            Console.WriteLine("      [2] Bowling");
            Console.WriteLine("      [3] Amusement Park");
            Console.WriteLine("      [4] Concert");

            EventType eventtype;
            while (true) {
                string chosen = Input("Input [#]: ");

                if (chosen == "1") {
                    eventtype = EventType.Golf;
                }

                else if (chosen == "2") {
                    eventtype = EventType.Bowling;
                }

                else if (chosen == "3") {
                    eventtype = EventType.AmusementPark;
                }

                else if (chosen == "4") {
                    eventtype = EventType.Concert;
                }

                else {
                    continue;
                }

                break;
            }

            Console.WriteLine();
            DateTime dateofevent = DateTime.Parse(Input("What is the date of this event (MM/DD/YYYY)? "));
            int numattendees = int.Parse(Input("How many people are attending this event? "));
            double ticketcost = Math.Round(double.Parse(Input("How much is one ticket to this outing? $")), 2);

            Outing new_outing = new Outing(eventtype, dateofevent, numattendees, ticketcost);
            outingrepo.AddOutingToList(new_outing);

            Console.WriteLine();
            Console.WriteLine("Your outing has been added to the list!");
            Input("Press enter/return ");
        }

        private void ViewOutingList() {
            int counter = 1;
            foreach (Outing outing in outingrepo.GetList()) {
                Console.WriteLine($"Outing #{counter} details: ");
                Console.WriteLine($"    Event Type: {outing.TypeOfEvent.ToString()}");
                Console.WriteLine($"    Date of Event: {outing.DateOfEvent.ToString("MM/dd/yyyy")}");
                Console.WriteLine($"    Number of Attendees: {outing.NumAttendees}");
                Console.WriteLine($"    Ticket Cost: ${outing.TicketCost}");
                Console.WriteLine($"    Total Revenue: ${outing.TotalCost}");
                Console.WriteLine();
                counter++;
            }

            Input("Press enter/return when you're finished viewing this list");
        }

        private void GetOutingCosts() {
            double total_golf = 0;
            double total_bowling = 0;
            double total_park = 0;
            double total_concert = 0;

            foreach (Outing outing in outingrepo.GetList()) {
                if (outing.TypeOfEvent == EventType.Golf) {
                    total_golf += outing.TotalCost;

                }

                else if (outing.TypeOfEvent == EventType.Bowling) {
                    total_bowling += outing.TotalCost;

                }

                else if (outing.TypeOfEvent == EventType.AmusementPark) {
                    total_park += outing.TotalCost;

                }

                else if (outing.TypeOfEvent == EventType.Concert) {
                    total_concert += outing.TotalCost;

                }

            }

            total_golf = Math.Round(total_golf, 2);
            total_bowling = Math.Round(total_bowling, 2);
            total_park = Math.Round(total_park, 2);
            total_concert = Math.Round(total_concert, 2);
            double total_all = Math.Round(total_golf + total_bowling + total_park + total_concert, 2);

            Console.WriteLine("Here are the total revenues for all outings: ");
            Console.WriteLine($"    Golf: ${total_golf}");
            Console.WriteLine($"    Bowling: ${total_bowling}");
            Console.WriteLine($"    Amusement Park: ${total_park}");
            Console.WriteLine($"    Concert: ${total_concert}");
            Console.WriteLine($"Total: ${total_all}");
            Console.WriteLine();
            Input("Press enter/return when you're finished viewing this list");

        }
    }
}
