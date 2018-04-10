namespace Customer.Module
{
    using Microsoft.EntityFrameworkCore;

    public interface ICustomerDbContext
    {
        DbSet<Common.Models.Customer> Customers { get; set; }

        int SaveChanges();

        void Update(Common.Models.Customer customer);
    }
}
