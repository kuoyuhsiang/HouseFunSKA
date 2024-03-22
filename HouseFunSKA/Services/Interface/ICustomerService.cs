using HouseFunSKA.Models;

namespace HouseFunSKA.Services.Interface;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(string id);
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer, string id);
    Task<bool> DeleteCustomerAsync(string id);

}