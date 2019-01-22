using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1 {

    public class MenuRepository
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        public void AddMenuItem(MenuItem menu_item)
        {
            menuItems.Add(menu_item);
        }
        
        public void RemoveMenuItem(MenuItem menu_item)
        {
            menuItems.Remove(menu_item);
        }

        public List<MenuItem> GetList()
        {
            return menuItems;
        }
    }
}
