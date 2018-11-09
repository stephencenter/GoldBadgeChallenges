using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {

    class ProgramUI {
        MethodRepository mrep = new MethodRepository();
        private const string divider = "-------------------------";

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
                Console.WriteLine("      [3] View the full menu");
                Console.WriteLine("      [4] Exit program");

                while (true) {
                    string choice = Input("Input [#]: ");

                    if (choice == "1") {
                        AddOption();
                    }

                    if (choice == "2") {
                        RemoveOption();
                    }

                    if (choice == "3") {
                        ViewOption();
                    }

                    if (choice == "4") {
                        System.Environment.Exit(1);
                    }
                }
            }
        }

        public void AddOption() {

        }

        public void RemoveOption() {

        }

        public void ViewOption() {

        }
    }
}
