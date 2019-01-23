using System.Collections.Generic;

namespace Challenge_5
{
    static class CustomerRepository
    {
        private static List<Customer> list_of_customers = new List<Customer>();

        public static List<Customer> GetList()
        {
            return list_of_customers;
        }

        public static void AddCustomerToList(Customer new_customer)
        {
            list_of_customers.Add(new_customer);
        }

        public static void RemoveCustomerFromList(Customer old_customer)
        {
            list_of_customers.Remove(old_customer);
        }
    }
}
