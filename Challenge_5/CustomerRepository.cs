using System.Collections.Generic;

namespace Challenge_5
{
    class CustomerRepository
    {
        private List<Customer> list_of_customers = new List<Customer>();

        public List<Customer> GetList()
        {
            return list_of_customers;
        }

        public void AddCustomerToList(Customer new_customer)
        {
            list_of_customers.Add(new_customer);
        }

        public void RemoveCustomerFromList(Customer old_customer)
        {
            list_of_customers.Remove(old_customer);
        }
    }
}
