using System.Collections.Generic;

namespace Challenge_5
{
    class Customer
    {
        public string FullName { get; set; }
        public string CustomerType { get; set; }
        public string EmailMessage { get; set; }

        public Customer(string fullname, string customertype)
        {
            FullName = fullname;
            CustomerType = customertype;
        }

        public void UpdateMessage()
        {
            Dictionary<string, string> email_list = new Dictionary<string, string>()
            {
                { "Potential", "We currently have the lowest rates on Helicopter Insurance!" },
                { "Current", "Thank you for your work with us. We appreciate your loyalty. Here's a coupon." },
                { "Past", "It's been a long time since we've heard from you, we want you back" }
            };

            EmailMessage = email_list[CustomerType];
        }
    }
}
