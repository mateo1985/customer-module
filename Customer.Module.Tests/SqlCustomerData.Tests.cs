namespace Customer.Module.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Customer = Customer.Module.Common.Models.Customer;

    [TestClass]
    public class SqlCustomerDataTests
    {
        private SqlCustomerData cut;
        private Mock<ICustomerDbContext> dbContext;
        private List<Customer> list;
        private Mock<DbSet<Customer>> dbSet;
        private Mock<Customer> lockedUser;

        [TestInitialize]
        public void Initialize()
        {
            this.lockedUser = new Mock<Customer>();
            lockedUser.Object.Id = 1;
            IList<Customer> users = new List<Customer>
            {
                lockedUser.Object
            };

            this.dbSet = CreateDbSetMock(users);
            this.dbContext = new Mock<ICustomerDbContext>();
            dbContext.Setup(x => x.Customers).Returns(this.dbSet.Object);

            this.cut = new SqlCustomerData(this.dbContext.Object);
        }

        [TestMethod]
        public void ShouldAddObject()
        {
            //Arrange
            Mock<Common.Models.Customer> expectedObject = new Mock<Customer>();

            //Action
            this.cut.Add(expectedObject.Object);

            //Asserts
            this.dbSet.Verify(x => x.Add(expectedObject.Object), Times.Once);
            this.dbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ShouldUpdateObject()
        {
            // Act
            this.cut.Update(lockedUser.Object);

            // Assert
            this.dbContext.Verify(x => x.Update(lockedUser.Object), Times.Once);
            this.dbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ShouldRemoveUer()
        {
            //Arrange
            const int expectedId = 1;

            // Act
            this.cut.Remove(expectedId);

            // Assert
            this.dbSet.Verify(x => x.Remove(lockedUser.Object), Times.Once);
            this.dbContext.Verify(x => x.SaveChanges(), Times.Once);
        }

        private static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }

    }
}
