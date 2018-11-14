using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4 {
    class BadgeRepository {
        private Dictionary<int, List<string>> badge_dict = new Dictionary<int, List<string>>();

        public void AddNewKeyToDict(int key) {
            badge_dict[key] = new List<string>();
        }

        public void RemoveKeyFromDict(int key) {
            badge_dict.Remove(key);

        }

        public void AddValueToDict(int key, string doornum) {
            badge_dict[key].Add(doornum);

        }

        public void RemoveValueFromDict(int key, string doornum) {
            badge_dict[key].Remove(doornum);

        }

        public Dictionary<int, List<string>> GetDictionary() {
            return badge_dict;
        }

        public bool DoesDictHaveKeys() {
            return badge_dict.Count > 0;
        }
    }
}
