using System;

namespace Customer.Module
{
    using System.Collections.Generic;
    using System.Linq;
    using Customer.Module.Common;

    public class SqlCustomerData: ICustomerService
    {
        private ICustomerDbContext context;

        public SqlCustomerData(ICustomerDbContext context)
        {
            this.context = context;
        }

        public void Add(Common.Models.Customer customer)
        {
            this.context.Customers.Add(customer);
            this.context.SaveChanges();
        }

        public void Remove(long id)
        {
            var element = this.context.Customers.FirstOrDefault(x => x.Id == id);
            if (element != null)
            {
                this.context.Customers.Remove(element);
                this.context.SaveChanges();
            }
        }

        public void Update(Common.Models.Customer customer)
        {
            this.context.Update(customer);
            this.context.SaveChanges();
        }

        public IList<Common.Models.Customer> GetAll()
        {
            //TODO: should be IQueryable but for the demo purposes it is IList
            return this.context.Customers.OrderBy(x => x.Id).ToList();
        }
    }
}
