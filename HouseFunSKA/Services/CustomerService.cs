using HouseFunSKA.Models;
using HouseFunSKA.Repositories.Interface;
using HouseFunSKA.Services.Interface;

namespace HouseFunSKA.Services;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _customerRepository;
    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public Task<List<Customer>> GetCustomer()
    {
        return _customerRepository.GetCustomerAsync();
    }

    public async Task<Customer> GetCustomerById(string id)
    {
        return await _customerRepository.GetCustomerByIdAsync(id);
    }

    public Task<Customer> CreateCustomer(Customer customer)
    {
        return _customerRepository.CreateCustomerAsync(customer);
    }

    public Task<Customer> UpdateCustomer(Customer customer, string id)
    {
        return _customerRepository.UpdateCustomerAsync(customer, id);
    }

    public Task<bool> DeleteCustomer(string id)
    {
        return _customerRepository.DeleteCustomerAsync(id);
    }
}