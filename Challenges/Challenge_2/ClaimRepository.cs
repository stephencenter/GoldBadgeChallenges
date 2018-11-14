using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2 {
    class ClaimRepository {
        private List<Claim> claim_list = new List<Claim>();

        public void AddClaimToList(Claim new_claim) {
            claim_list.Add(new_claim);
        }

        public void RemoveClaimFromList(Claim old_claim) {
            claim_list.Remove(old_claim);
        }

        public List<Claim> GetList() {
            return claim_list;
        }
    }
}
