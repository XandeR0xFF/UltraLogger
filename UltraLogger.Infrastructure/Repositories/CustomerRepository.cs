using UltraLogger.Core.Domain.Aggregates.Customers;
using UltraLogger.Core.Domain.Common;
using UltraLogger.Infrastructure.Data;

namespace UltraLogger.Infrastructure.Repositories;

public class CustomerRepository(UnitOfWork uow) : ICustomerRepository
{
    private readonly UnitOfWork _uow = uow;

    public IUnitOfWork UnitOfWork => _uow;

    public Customer Add(Customer customer)
    {
        Customer addedCustomer = customer;

        if (customer.IsTransient())
        {
            long newId = _uow.GetNewId("Customers");
            addedCustomer = new Customer(newId, customer.CompanyName, customer.Description, customer.IsActive);
        }

        _uow.Execute(@"INSERT INTO Customers(Id, CompanyName, Description, IsActive)
                       VALUES(@Id, @CompanyName, @Description, @IsActive)", addedCustomer);

        return addedCustomer;
    }

    public void Update(Customer customer)
    {
        if (customer.IsTransient())
            throw new InvalidOperationException("Updated customer is transient.");

        _uow.Execute(@"UPDATE Customers
                     SET
                        CompanyName = @CompanyName,
                        Description = @Description,
                        IsActive = @IsActive
                     WHERE Id = @Id", customer);
    }

    public Customer? GetById(long id)
    {
        return _uow.QuerySingleOrDefault<Customer>("SELECT * FROM Customers WHERE Id = @Id", new { Id = id });
    }

    public IEnumerable<Customer> GetAll()
    {
        return _uow.Query<Customer>("SELECT * FROM Customers WHERE IsActive = TRUE ORDER BY CompanyName");
    }
}
