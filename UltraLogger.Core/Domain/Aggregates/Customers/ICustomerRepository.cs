using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Customers
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Customer Add(Customer customer);
        void Update(Customer customer);
        Customer? GetById(long id);
        IEnumerable<Customer> GetAll();
    }
}
