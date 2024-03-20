using HouseFunSKA.Data;
using HouseFunSKA.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseFunSKA.Services;

public class CustomerService
{
    private readonly NorthwindContext _context;

    public CustomerService(NorthwindContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetCustomerAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerIdAsync(string id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(string id, Customer customer)
    {
        if (_context.Customers.Any(x => x.CustomerID == id))
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return customer;
        }

        return null;
    }

    public async Task<bool> DeleteCustomerAsync(string id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return false;
        }

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();
        return true;
    }
}