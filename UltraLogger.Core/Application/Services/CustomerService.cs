using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Domain.Aggregates.Customers;

namespace UltraLogger.Core.Application.Services
{
    public class CustomerService(ICustomerRepository customerRepository)
    {
        private readonly ICustomerRepository _customerRepository = customerRepository;

        public Result CreateCustomer(CreateCustomerDTO createCustomerDTO)
        {
            Customer customerForCreate = new Customer(0, createCustomerDTO.CompanyName, createCustomerDTO.Description, true);
            _customerRepository.Add(customerForCreate);

            _customerRepository.UnitOfWork.SaveChanges();

            return Result.Success();
        }

        public Result UpdateCustomer(CustomerDTO customerDTO)
        {
            Customer? customerForUpdate = _customerRepository.GetById(customerDTO.Id);
            if (customerForUpdate == null)
                return Result.Failure(Error.None);

            customerForUpdate.ChangeCompanyName(customerDTO.CompanyName);
            customerForUpdate.ChangeDescription(customerDTO.Description);

            _customerRepository.UnitOfWork.SaveChanges();

            return Result.Success();
        }

        public Result DeleteCustomer(long customerId)
        {
            Customer? customerForDelete = _customerRepository.GetById(customerId);

            if (customerForDelete == null)
                return Result.Failure(Error.None);

            customerForDelete.Disable();
            _customerRepository.Update(customerForDelete);
            _customerRepository.UnitOfWork.SaveChanges();

            return Result.Success();
        }

        public IEnumerable<CustomerDTO> GetAll()
        {
            IEnumerable<Customer> customers = _customerRepository.GetAll();
            List<CustomerDTO> customerDTOs = new List<CustomerDTO>();

            foreach (Customer customer in customers)
            {
                customerDTOs.Add(new CustomerDTO { Id = customer.Id, CompanyName = customer.CompanyName, Description = customer.Description });
            }

            return customerDTOs;
        }
    }
}
