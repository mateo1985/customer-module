namespace Customer.Module
{
    using Microsoft.EntityFrameworkCore;
    using Customer = Common.Models.Customer;
    public class CustomerDbContext: DbContext, ICustomerDbContext
    {
        private CustomerDbContext context;
        public CustomerDbContext(DbContextOptions context) : base(context)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public void SaveChanges()
        {
            this.context?.SaveChanges();
        }

        public void Update(Customer customer)
        {
            this.context?.Update(customer);
        } 
    }
}
