using UltraLogger.Core.Domain.Common;

namespace UltraLogger.Core.Domain.Aggregates.Customers;

public class Customer : Entity, IAggregateRoot
{
    private Customer()
    {
        CompanyName = string.Empty;
    }

    public Customer(long id, string companyName, string? description, bool isActive)
    {
        Id = id;
        CompanyName = companyName;
        Description = description;
        IsActive = isActive;
    }

    public string CompanyName { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }

    public void ChangeCompanyName(string companyName)
    {
        CompanyName = companyName;
    }

    public void ChangeDescription(string? description)
    {
        Description = description;
    }

    public void Disable()
    {
        IsActive = false;
    }

    public void Enable()
    {
        IsActive = true;
    }
}
