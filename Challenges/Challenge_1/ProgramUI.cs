using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {

    class ProgramUI {
        MenuRepository menurepo = new MenuRepository();
        private string divider = new String('-', 25);

        public void Run() {
            Console.WriteLine("Welcome to Komodo Cafe's patented Menu Management System!");
            ChooseAnOption();
        }

        public string Input(string prompt) {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public void ChooseAnOption() {
            while (true) {
                Console.WriteLine(divider);
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("      [1] Add a menu item");
                Console.WriteLine("      [2] Remove a menu item");
                Console.WriteLine("      [3] View menu");
                Console.WriteLine("      [4] View menu (verbose)");
                Console.WriteLine("      [5] Exit program");

                while (true) {
                    string choice = Input("Input [#]: ");

                    if (choice == "1") {
                        AddOption();
                        break;
                    }

                    if (choice == "2") {
                        if (menurepo.GetList().Count > 0) {
                            RemoveOption();
                        }

                        else {
                            Console.WriteLine(divider);
                            Console.WriteLine("You have no menu items yet.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    if (choice == "3") {
                        if (menurepo.GetList().Count > 0) {
                            ViewOptionSimple();
                        }

                        else {
                            Console.WriteLine(divider);
                            Console.WriteLine("You have no menu items yet.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    if (choice == "4") {
                        if (menurepo.GetList().Count > 0) {
                            ViewOptionVerbose();
                        }

                        else {
                            Console.WriteLine(divider);
                            Console.WriteLine("You have no menu items yet.");
                            Input("Press enter/return ");
                        }

                        break;
                    }

                    if (choice == "5") {
                        System.Environment.Exit(1);
                    }
                }
            }
        }

        public void AddOption() {
            Console.WriteLine(divider);
            Console.WriteLine("Let's add a menu item.");
            string name = Input("Give the menu item a name: ");
            string desc = Input("Give the menu item a short description: ");
            double price = Math.Round(double.Parse(Input("Give the menu item a price (no dollar signs!): ")), 2);

            Console.WriteLine(divider);
            List<string> ingredients = AddIngredients();
            Console.WriteLine(divider);

            menurepo.AddMenuItem(new MenuItem(name, desc, price, ingredients));

            Console.WriteLine($"{name} has been added to the menu.");
            Input("Press enter/return ");
        }

        public void RemoveOption() {
            Console.WriteLine(divider);
            Console.WriteLine("Choose a menu item: ");

            int counter = 1;
            foreach (MenuItem menu_item in menurepo.GetList()) {
                Console.WriteLine($"      [{counter}] {menu_item.Name}");
                counter++;
            }

            Console.WriteLine($"      [{counter}] Cancel");

            while (true) {
                int chosen_num = int.Parse(Input("Input [#]: ")) - 1;

                if (chosen_num + 1 == counter) {
                    return;
                }

                if (chosen_num > menurepo.GetList().Count || chosen_num < 0) {
                    continue;
                }

                MenuItem removed_item = menurepo.GetList()[chosen_num];
                menurepo.RemoveMenuItem(removed_item);

                Console.WriteLine(divider);
                Console.WriteLine($"{removed_item.Name} has been removed.");
                Input("Press enter/return ");
                return;
            }

        }
        
        public void ViewOptionSimple() {
            Console.WriteLine(divider);
            Console.WriteLine("Komodo Cafe Menu: ");

            int counter = 1;
            foreach (MenuItem menu_item in menurepo.GetList()) {
                Console.WriteLine($"  #{counter}: {menu_item.Name} | 1 @ ${menu_item.Price}");
                counter++;
            }

            Input("\nPress enter/return when you're done reading the menu ");
        }

        public void ViewOptionVerbose() {
            Console.WriteLine(divider);
            Console.WriteLine("Komodo Cafe Menu: ");

            int counter = 1;
            foreach (MenuItem menu_item in menurepo.GetList()) {
                Console.WriteLine($"  #{counter}: {menu_item.Name} | 1 @ ${menu_item.Price}");
                Console.WriteLine($"    \"{menu_item.Description}\"");
                Console.WriteLine($"\n    Ingredients: ");

                foreach (string ingredient in menu_item.Ingredients) {
                    Console.WriteLine($"      {ingredient}");
                }

                Console.WriteLine();
                counter++;
            }

            Input("\nPress enter/return when you're done reading the menu ");

        }

        public List<string> AddIngredients() { 
            List<string> ingredient_list = new List<string>();

            Console.WriteLine("It's time to add ingredients.");
            while (true) {
                string ingredient = Input("Type an ingredient for this item, or type \"done\": ");

                if (string.IsNullOrWhiteSpace(ingredient)) {
                    continue;
                }

                else if (ingredient.ToLower() == "done" && ingredient_list.Count() > 0) {
                    return ingredient_list;
                }

                else if (ingredient.ToLower() == "done" && ingredient_list.Count() == 0) {
                    Console.WriteLine();
                    Console.WriteLine("You need at least one ingredient.");
                    Console.WriteLine();
                }

                else if (ingredient_list.Contains(ingredient)) {
                    Console.WriteLine();
                    Console.WriteLine("That ingredients already in the ingredient list.");
                    Console.WriteLine();
                }

                else {
                    ingredient_list.Add(ingredient);
                    Console.WriteLine();
                    Console.WriteLine($"{ingredient} has been added to the ingredient list.");
                    Console.WriteLine();
                }
            }
        }
    }
}
