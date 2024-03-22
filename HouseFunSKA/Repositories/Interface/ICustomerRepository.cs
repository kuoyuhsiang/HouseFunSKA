using HouseFunSKA.Models;

namespace HouseFunSKA.Repositories.Interface;

public interface ICustomerRepository
{
    Task<List<Customer>> GetCustomerAsync();
    Task<Customer> GetCustomerByIdAsync(string id);
    Task<Customer> CreateCustomerAsync(Customer customer);
    Task<Customer> UpdateCustomerAsync(Customer customer, string id);
    Task<bool> DeleteCustomerAsync(string id);

}