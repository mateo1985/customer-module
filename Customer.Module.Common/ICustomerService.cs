namespace Customer.Module.Common
{
    using System.Collections.Generic;

    public interface ICustomerService
    {
        void Add(Models.Customer customer);

        void Remove(long id);

        void Update(Models.Customer customer);

        IList<Models.Customer> GetAll();
    }
}
