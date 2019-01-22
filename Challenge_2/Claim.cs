using System;

namespace Challenge_2 {

    class Claim {
        public int ClaimID { get; set; }
        public string ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        public bool IsValid { get; set; }

        public Claim(int claim_id, string claim_type, string desc, double claim_amount, DateTime doi, DateTime doc)
        {
            ClaimID = claim_id;
            ClaimType = claim_type;
            Description = desc;
            ClaimAmount = claim_amount;
            DateOfIncident = doi;
            DateOfClaim = doc;

            // Figure out the value of IsValid by comparing the date of incident and date of claim
            int delta_time = (DateOfClaim - DateOfIncident).Days;

            if (delta_time > 30 || delta_time < 0)
            {
                IsValid = false;
            }

            else
            {
                IsValid = true;
            }
        }
    }
}
