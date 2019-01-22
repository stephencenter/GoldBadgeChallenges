using System;

namespace Challenge_4
{
    class ProgramUI
    {
        BadgeRepository badgerepo = new BadgeRepository();
        private readonly string divider = new string('-', 25);

        public void Run()
        {
            Console.WriteLine("Welcome to Komodo Security's Badge Management System!");
            ChooseAnOption();
        }

        public string Input(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private void ChooseAnOption()
        {
            while (true)
            {
                Console.WriteLine(divider);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("      [1] Create a new badge");
                Console.WriteLine("      [2] Add a door to a badge");
                Console.WriteLine("      [3] Remove a door from a badge");
                Console.WriteLine("      [4] Delete a badge");
                Console.WriteLine("      [5] View all badges");
                Console.WriteLine("      [6] Exit Program");

                while (true)
                {
                    string chosen = Input("Input [#]: ");

                    if (chosen == "1")
                    {
                        Console.WriteLine(divider);
                        CreateBadgeOption();
                        break;
                    }

                    else if (chosen == "2")
                    {
                        Console.WriteLine(divider);

                        if (badgerepo.DoesDictHaveKeys())
                        {
                            AddDoorToBadgeOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to create a badge first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "3")
                    {
                        Console.WriteLine(divider);

                        if (badgerepo.DoesDictHaveKeys())
                        {
                            RemoveDoorFromBadgeOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to create a badge first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "4")
                    {
                        Console.WriteLine(divider);

                        if (badgerepo.DoesDictHaveKeys())
                        {
                            DeleteBadgeOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to create a badge first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "5")
                    {
                        Console.WriteLine(divider);

                        if (badgerepo.DoesDictHaveKeys())
                        {
                            ViewAllBadgesOption();
                        }

                        else
                        {
                            Console.WriteLine("You need to create a badge first.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    else if (chosen == "6")
                    {
                        Environment.Exit(1);
                    }
                }
            }
        }

        // Lists all the available badges, asks the user to choose one, and returns the badge #.
        // Used by multiple methods.
        private int ChooseBadgeKey()
        {
            Console.WriteLine("Choose a badge #: ");

            foreach (int key in badgerepo.GetDictionary().Keys)
            {
                Console.WriteLine($"      [{key}]");
            }

            while (true)
            {
                int chosen = int.Parse(Input("Input [#]: "));

                if (badgerepo.GetDictionary().ContainsKey(chosen))
                {
                    return chosen;
                }
            }
        }

        // Create a new badge. This badge cannot open any doors until the user chooses to add a door to it.
        private void CreateBadgeOption()
        {
            int badge_id;

            while (true)
            {
                badge_id = int.Parse(Input("Give an ID# to this badge: "));

                if (badgerepo.GetDictionary().ContainsKey(badge_id))
                {
                    Console.WriteLine("\nA badge with that ID already exists.");
                    Input("Press enter/return ");
                    Console.WriteLine(divider);
                }

                else
                {
                    break;
                }
            }

            badgerepo.AddNewKeyToDict(badge_id);
            Console.WriteLine("\nYour badge has been created!");
            Input("Press enter/return ");
        }

        // Grants a badge the ability to open a specific door
        private void AddDoorToBadgeOption()
        {
            int current_key = ChooseBadgeKey();
            Console.WriteLine(divider);

            while (true)
            {
                string new_door = Input($"What new door# should badge #{current_key} be able to access? ");

                if (badgerepo.GetDictionary()[current_key].Contains(new_door))
                {
                    Console.WriteLine($"\nBadge #{current_key} can already open that door.");
                    Input("Press enter/return ");
                    Console.WriteLine(divider);
                }

                else
                {
                    badgerepo.AddValueToDict(current_key, new_door);
                    Console.WriteLine($"\nBadge #{current_key} can now open door #{new_door}.");
                    Input("Press enter/return ");
                    return;
                }
            }
        }

        // Takes away the ability for a badge to open a specific door
        private void RemoveDoorFromBadgeOption()
        {
            int current_key = ChooseBadgeKey();
            Console.WriteLine(divider);

            Console.WriteLine($"Doors unlockable by Badge #{current_key}: ");
            Console.WriteLine($"  {string.Join(", ", badgerepo.GetDictionary()[current_key])}");
            Console.WriteLine();

            while (true)
            {
                string to_remove = Input($"Which door# should badge #{current_key} not be able to access? ");

                if (badgerepo.GetDictionary()[current_key].Contains(to_remove))
                {
                    badgerepo.RemoveValueFromDict(current_key, to_remove);
                    Console.WriteLine($"\nBadge #{current_key} can no longer open door #{to_remove}.");
                    Input("Press enter/return ");
                    return;
                }

                else
                {
                    Console.WriteLine($"\nBadge #{current_key} already can't open that door.");
                    Input("Press enter/return ");
                    Console.WriteLine(divider);
                }
            }
        }

        // Deletes a badge permanently
        private void DeleteBadgeOption()
        {
            int current_key = ChooseBadgeKey();
            Console.WriteLine(divider);

            while (true)
            {
                string y_n = Input($"Are you sure you want to delete Badge #{current_key}? (y/n) ").ToLower();

                if (y_n.StartsWith("y"))
                {
                    badgerepo.RemoveKeyFromDict(current_key);
                    Console.WriteLine("\nYour badge has been deleted.");
                    Input("Press enter/return ");
                    return;
                }

                else if (y_n.StartsWith("n"))
                {
                    return;
                }
            }
        }

        // Displays a list of badges along with all doors they can open
        private void ViewAllBadgesOption()
        {
            foreach(int key in badgerepo.GetDictionary().Keys)
            {
                Console.WriteLine($"Badge #{key}:");

                if (badgerepo.GetDictionary()[key].Count > 0)
                {
                    Console.WriteLine($"  Can Unlock {string.Join(", ", badgerepo.GetDictionary()[key])}");
                }

                else
                {
                    Console.WriteLine("  Cannot Unlock Anything");
                }

                Console.WriteLine();
            }

            Input("Press enter/return when you're done viewing this list ");
        }
    }
}
