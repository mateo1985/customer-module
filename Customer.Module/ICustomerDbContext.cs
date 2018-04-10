namespace Customer.Module
{
    using Microsoft.EntityFrameworkCore;

    public interface ICustomerDbContext
    {
        DbSet<Common.Models.Customer> Customers { get; set; }

        void SaveChanges();

        void Update(Common.Models.Customer customer);
    }
}
