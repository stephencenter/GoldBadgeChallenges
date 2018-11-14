using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {

    public class MenuItem {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public List<string> Ingredients { get; set; }

        public MenuItem(string name, string description, double price, List<string> ingredients) {
            Name = name;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }

        public MenuItem() {

        }

    }

}
