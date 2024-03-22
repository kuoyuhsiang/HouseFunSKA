using HouseFunSKA.Models;

namespace HouseFunSKA.Services.Interface;

public interface ICustomerService
{
    Task<List<Customer>> GetCustomer();
    Task<Customer> GetCustomerById(string id);
    Task<Customer> CreateCustomer(Customer customer);
    Task<Customer> UpdateCustomer(Customer customer, string id);
    Task<bool> DeleteCustomer(string id);

}