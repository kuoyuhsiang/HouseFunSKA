using HouseFunSKA.Models;
using HouseFunSKA.Repositories.Interface;
using HouseFunSKA.Services;
using HouseFunSKA.Services.Interface;
using NSubstitute;
using NUnit.Framework;

namespace HouseFunSKA.Test.Services;

[TestFixture]
public class CustomerServiceTest
{
    [SetUp]
    public void SetUp()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();
        _customerService = new CustomerService(_customerRepository);
    }

    private ICustomerRepository _customerRepository;
    private ICustomerService _customerService;

    [Test]
    public void GetCustomer_Should_Call_GetCustomerAsync_Method_In_CustomerRepository_Once()
    {
        _customerService.GetCustomer();
        _customerRepository.Received(1).GetCustomerAsync();
    }

    [Test]
    public void GetCustomerById_Should_Call_GetCustomerByIdAsync_Method_In_CustomerRepository_Once()
    {
        var customer = new Customer();
        _customerService.GetCustomerById(customer.CustomerID);
        _customerRepository.Received(1).GetCustomerByIdAsync(customer.CustomerID);
    }

    [Test]
    public void CreateCustomer_Should_Call_CreateCustomerAsync_Method_In_CustomerRepository_Once()
    {
        var customer = new Customer();
        _customerService.CreateCustomer(customer);
        _customerRepository.Received(1).CreateCustomerAsync(customer);
    }

    [Test]
    public void UpdateCustomer_Should_Call_UpdateCustomerAsync_Method_In_CustomerRepository_Once()
    {
        var customer = new Customer();
        _customerService.UpdateCustomer(customer, customer.CustomerID);
        _customerRepository.UpdateCustomerAsync(customer, customer.CustomerID);
    }

    [Test]
    public void DeleteCustomer_Should_Call_DeleteCustomerAsync_Method_In_CustomerRepository_Once()
    {
        var customer = new Customer();
        _customerService.DeleteCustomer(customer.CustomerID);
        _customerRepository.DeleteCustomerAsync(customer.CustomerID);
    }
}