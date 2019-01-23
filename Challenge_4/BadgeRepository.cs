using System.Collections.Generic;

namespace Challenge_4
{
    public static class BadgeRepository
    {
        private static Dictionary<int, List<string>> badge_dict = new Dictionary<int, List<string>>();

        public static void AddNewKeyToDict(int key)
        {
            badge_dict[key] = new List<string>();
        }

        public static void RemoveKeyFromDict(int key)
        {
            badge_dict.Remove(key);
        }

        public static void AddValueToDict(int key, string doornum)
        {
            badge_dict[key].Add(doornum);
        }

        public static void RemoveValueFromDict(int key, string doornum)
        {
            badge_dict[key].Remove(doornum);
        }

        public static Dictionary<int, List<string>> GetDictionary()
        {
            return badge_dict;
        }

        public static bool DoesDictHaveKeys()
        {
            return badge_dict.Count > 0;
        }
    }
}
