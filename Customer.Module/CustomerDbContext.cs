namespace Customer.Module
{
    using Microsoft.EntityFrameworkCore;
    using Customer = Common.Models.Customer;
    public class CustomerDbContext: DbContext, ICustomerDbContext
    {
        public CustomerDbContext(DbContextOptions context) : base(context)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        
        public void Update(Customer customer)
        {
            this.Customers?.Update(customer);
        } 
    }
}
