using System.Collections.Generic;

namespace Challenge_2
{
    public static class ClaimRepository
    {
        private static List<Claim> claim_list = new List<Claim>();

        public static void AddClaimToList(Claim new_claim)
        {
            claim_list.Add(new_claim);
        }

        public static void RemoveClaimFromList(Claim old_claim)
        {
            claim_list.Remove(old_claim);
        }

        public static List<Claim> GetList()
        {
            return claim_list;
        }
    }
}
