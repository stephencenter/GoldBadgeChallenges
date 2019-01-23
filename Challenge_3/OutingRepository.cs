using System.Collections.Generic;

namespace Challenge_3
{
    public static class OutingRepository
    {
        private static List<Outing> outing_list = new List<Outing>();

        public static List<Outing> GetList()
        {
            return outing_list;
        }

        public static void AddOutingToList(Outing new_outing)
        {
            outing_list.Add(new_outing);
        }
    }
}
