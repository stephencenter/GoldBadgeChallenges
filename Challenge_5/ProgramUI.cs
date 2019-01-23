using System;

namespace Challenge_5
{
    public static class ProgramUI
    {
        private static readonly string divider = new string('-', 25);

        public static void Run()
        {
            Console.WriteLine("Welcome to Komodo Insurance's telemarketing management system!");
            ChooseAnOption();
        }

        public static string Input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static void ChooseAnOption()
        {
            while (true)
            {
                Console.WriteLine(divider);
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("      [1] Add a new customer");
                Console.WriteLine("      [2] Remove a customer");
                Console.WriteLine("      [3] Update a customer");
                Console.WriteLine("      [4] View all customers");
                Console.WriteLine("      [5] Exit program");

                while (true)
                {
                    string chosen = Input("Input [#]: ");

                    if (chosen == "1")
                    {
                        Console.WriteLine(divider);
                        AddCustomerOption();
                        break;
                    }

                    else if (chosen == "2")
                    {
                        Console.WriteLine(divider);

                        if (CustomerRepository.GetList().Count > 0)
                        {
                            RemoveCustomerOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to add a customer first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "3")
                    {
                        Console.WriteLine(divider);

                        if (CustomerRepository.GetList().Count > 0)
                        {
                            UpdateCustomerOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to add a customer first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "4")
                    {
                        Console.WriteLine(divider);

                        if (CustomerRepository.GetList().Count > 0)
                        {
                            ViewCustomersOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to add a customer first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "5")
                    {
                        Environment.Exit(1);
                    }
                }
            }
        }

        private static Customer ChooseACustomer(string action_text)
        {
            Console.WriteLine($"Choose a customer to {action_text}: ");

            int counter = 1;
            foreach (Customer customer in CustomerRepository.GetList())
            {
                Console.WriteLine($"      [{counter}] {customer.FullName} ({customer.CustomerType})");
                counter++;
            }

            while (true)
            {
                int input = int.Parse(Input("Input [#]: "));

                if (!(input < 1) && !(input > CustomerRepository.GetList().Count))
                {
                    return CustomerRepository.GetList()[input - 1];
                }
            }
        }

        private static string ChooseCustomerType()
        {
            while (true)
            {
                string input = Input("Is this customer a (1) potential, (2) current, or (3) past customer? ");

                if (input == "1")
                {
                    return "Potential";
                }

                if (input == "2")
                {
                    return "Current";
                }

                if (input == "3")
                {
                    return "Past";
                }
            }
        }
        
        private static void AddCustomerOption()
        {
            string full_name = Input("What is the full name of this customer? ");
            string customer_type = ChooseCustomerType();

            Customer new_customer = new Customer(full_name, customer_type);

            new_customer.UpdateMessage();
            Console.WriteLine($"\nCustomer Email Message has been set to \"{new_customer.EmailMessage}\"");

            CustomerRepository.AddCustomerToList(new_customer);
            Console.WriteLine("\nYour customer has been added.");
            Input("Press enter/return ");
        }

        private static void RemoveCustomerOption()
        {
            CustomerRepository.RemoveCustomerFromList(ChooseACustomer("remove"));
            Console.WriteLine(divider);
            Console.WriteLine("Your customer has been removed.");
            Input("Press enter/return ");
        }
        
        private static void UpdateCustomerOption()
        {
            Customer update_customer = ChooseACustomer("update");
            Console.WriteLine(divider);

            Console.WriteLine($"Current Full Name: {update_customer.FullName}");
            update_customer.FullName = Input("What is the full name of this customer? ");
            Console.WriteLine();

            Console.WriteLine($"Current Customer Type: {update_customer.CustomerType}");
            update_customer.CustomerType = ChooseCustomerType();

            update_customer.UpdateMessage();
            Console.WriteLine($"\nCustomer Email Message has been set to \"{update_customer.EmailMessage}\"");

            Console.WriteLine("\nYour customer has been updated.");
            Input("Press enter/return ");
        }

        private static void ViewCustomersOption()
        {
            Console.WriteLine("List of customers: ");

            foreach (Customer customer in CustomerRepository.GetList())
            {
                Console.WriteLine($"  {customer.FullName} ({customer.CustomerType})");
                Console.WriteLine($"    Email Message: {customer.EmailMessage}");
                Console.WriteLine();
            }

            Input("Press enter/return when you're finished viewing this list ");
        }
    }
}
