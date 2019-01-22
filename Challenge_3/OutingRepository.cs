using System.Collections.Generic;

namespace Challenge_3
{
    class OutingRepository
    {
        private List<Outing> outing_list = new List<Outing>();

        public List<Outing> GetList()
        {
            return outing_list;
        }

        public void AddOutingToList(Outing new_outing)
        {
            outing_list.Add(new_outing);
        }
    }
}
