using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2 {
    class ProgramUI {
        ClaimRepository claimrepo = new ClaimRepository();
        private string divider = new String('-', 25);

        public void Run() {
            Console.WriteLine("Welcome to the Komodo Claims Department!");
            ChooseAnOption();
        }

        public string Input(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public int GetMax(int a, int b) {
            if (a > b) {
                return a;
            }

            return b;
        }

        public void ChooseAnOption() {
            while (true) {
                Console.WriteLine(divider);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("      [1] Enter a new Claim");
                Console.WriteLine("      [2] Address a Claim");
                Console.WriteLine("      [3] View Claims");
                Console.WriteLine("      [4] Exit program");

                while (true) {
                    string choice = Input("Input [#]: ");

                    if (choice == "1") {
                        Console.WriteLine(divider);
                        EnterNewClaimOption();
                        break;
                    }

                    if (choice == "2") {
                        Console.WriteLine(divider);
                        if (claimrepo.GetList().Count > 0) {
                            AddressClaimOption();
                        }

                        else {
                            Console.WriteLine("You don't have any claims to address.");
                            Input("Press enter/return");
                        }

                        break;
                    }

                    if (choice == "3") {
                        Console.WriteLine(divider);
                        if (claimrepo.GetList().Count > 0) {
                            ViewClaimOption();
                        }

                        else {
                            Console.WriteLine("You don't have any claims to view.");
                            Input("Press enter/return");
                        }

                        break;
                    }

                    if (choice == "4") {
                        System.Environment.Exit(1);
                        break;
                    }
                }
            }
        }


        private void EnterNewClaimOption() {
            // Gather information from user
            int ClaimID = int.Parse(Input("Give this Claim an ID#: "));
            string ClaimType = Input("What is the claim type (car, house, theft): ");
            string Description = Input("Give a description of the claim: ");
            double ClaimAmount = double.Parse(Input("How much is the claim for (no dollar signs): "));
            DateTime DateOfIncident = DateTime.Parse(Input("What was the date of the incident (MM/DD/YYYY): "));
            DateTime DateOfClaim = DateTime.Parse(Input("What was the date of the claim (MM/DD/YYYY): "));

            // Create a new claim object using user input and add it to the claim list
            Claim new_claim = new Claim(ClaimID, ClaimType, Description, ClaimAmount, DateOfIncident, DateOfClaim);
            claimrepo.AddClaimToList(new_claim);

            Console.WriteLine($"This claim is {(new_claim.IsValid ? "" : "not ")}valid.");

            Console.WriteLine();
            Console.WriteLine("The new claim has been added!");
            Input("Press enter/return ");
        }

        private void AddressClaimOption() {
            Claim current_claim = claimrepo.GetList()[0];
            Console.WriteLine($"The next claim in the queue is claim #{current_claim.ClaimID}.");
            Console.WriteLine("Here are the details for this claim:");
            Console.WriteLine($"Claim Type: {current_claim.ClaimType}");
            Console.WriteLine($"Description: {current_claim.Description}");
            Console.WriteLine($"Claim Amount: {current_claim.ClaimAmount}");
            Console.WriteLine($"Date of Incident: {current_claim.DateOfIncident.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Date of Claim: {current_claim.DateOfClaim.ToString("MM/dd/yyyy")}");
            Console.WriteLine($"Is Valid: {current_claim.IsValid}");
            Console.WriteLine();

            while (true) {
                string input = Input("Do you want to deal with this claim now? (y/n): ").ToLower();

                if (input.StartsWith("y")) {
                    claimrepo.RemoveClaimFromList(current_claim);
                    Console.WriteLine("Your claim has been dealt with!");
                    Input("Press enter/return ");
                    return;
                }

                else if (input.StartsWith("n")) {
                    return;
                }
            }
        }

        private void ViewClaimOption() {
            // Most of this is just setup so the text is all aligned properly. I couldn't find a simple way to do this so here's what I went with.
            string header1 = "Claim ID#";
            string header2 = "Claim Type";
            string header3 = "Description";
            string header4 = "Date of Incident";
            string header5 = "Date of Claim";

            // Get the number of spaces to pad each item with
            int padding_1 = GetMax(claimrepo.GetList().Max(t => t.ClaimID.ToString().Count()), header1.Count());
            int padding_2 = GetMax(claimrepo.GetList().Max(t => t.ClaimType.Count()), header2.Count());
            int padding_3 = GetMax(claimrepo.GetList().Max(t => t.Description.Count()), header3.Count());
            int padding_4 = GetMax(claimrepo.GetList().Max(t => t.DateOfIncident.ToString("MM/dd/yyyy").Count()), header4.Count());
            int padding_5 = GetMax(claimrepo.GetList().Max(t => t.DateOfClaim.ToString("MM/dd/yyyy").Count()), header5.Count());

            // Print the header
            Console.Write(header1);
            Console.Write(new String(' ', padding_1 - header1.Count()));
            Console.Write(" | ");

            Console.Write(header2);
            Console.Write(new String(' ', padding_2 - header2.Count()));
            Console.Write(" | ");

            Console.Write(header3);
            Console.Write(new String(' ', padding_3 - header3.Count()));
            Console.Write(" | ");

            Console.Write(header4);
            Console.Write(new String(' ', padding_4 - header4.Count()));
            Console.Write(" | ");

            Console.Write(header5);
            Console.Write(new String(' ', padding_5 - header5.Count()));
            Console.Write(" | ");

            Console.WriteLine("Valid?");

            // Print the claims
            foreach (Claim claim in claimrepo.GetList()) {
                Console.Write(claim.ClaimID);
                Console.Write(new String(' ', padding_1 - claim.ClaimID.ToString().Count()));
                Console.Write(" | ");

                Console.Write(claim.ClaimType);
                Console.Write(new String(' ', padding_2 - claim.ClaimType.Count()));
                Console.Write(" | ");

                Console.Write(claim.Description);
                Console.Write(new String(' ', padding_3 - claim.Description.Count()));
                Console.Write(" | ");

                Console.Write(claim.DateOfIncident.ToString("MM/dd/yyyy"));
                Console.Write(new String(' ', padding_4 - claim.DateOfIncident.ToString("MM/dd/yyyy").Count()));
                Console.Write(" | ");

                Console.Write(claim.DateOfClaim.ToString("MM/dd/yyyy"));
                Console.Write(new String(' ', padding_5 - claim.DateOfClaim.ToString("MM/dd/yyyy").Count()));
                Console.Write(" | ");

                Console.WriteLine(claim.IsValid);
            }
            Console.WriteLine();
            Input("Press enter/return when you're finished viewing this list");
            

        }

    }
}
