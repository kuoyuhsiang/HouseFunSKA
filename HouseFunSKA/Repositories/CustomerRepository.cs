using HouseFunSKA.Data;
using HouseFunSKA.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseFunSKA.Repositories;

public class CustomerRepository
{
    private readonly NorthwindContext _context;
    
    public CustomerRepository(NorthwindContext context)
    {
        _context = context;
    }

    public async Task<List<Customer>> GetCustomerAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<Customer> GetCustomerByIdAsync(string id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomerAsync(Customer customer, string id)
    {
        try
        {
            if (_context.Customers.Any(x => x.CustomerID == id))
            {
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return customer;
            }
            else
            {
                return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured when updating customer: {e.Message}");
            throw;
        }

    }

    public async Task<bool> DeleteCustomerAsync(string id)
    {
        try
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return false;
            }
            else
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error occured when delete customer {e.Message}");
            throw;
        }
    }
}