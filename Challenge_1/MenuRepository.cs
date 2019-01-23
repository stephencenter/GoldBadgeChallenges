using System.Collections.Generic;

namespace Challenge_1 {

    public static class MenuRepository
    {
        private static List<MenuItem> menuItems = new List<MenuItem>();

        public static void AddMenuItem(MenuItem menu_item)
        {
            menuItems.Add(menu_item);
        }
        
        public static void RemoveMenuItem(MenuItem menu_item)
        {
            menuItems.Remove(menu_item);
        }

        public static List<MenuItem> GetList()
        {
            return menuItems;
        }
    }
}
