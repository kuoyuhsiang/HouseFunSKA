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

    private ICustomerRepository _customerRepository = null!;
    private ICustomerService _customerService = null!;
    private readonly string _customerId = "ALFKI";
    private readonly Customer _customer = null!;

    [Test]
    public void GetCustomer_Should_Call_GetCustomerAsync_Method_In_CustomerRepository_Once()
    {
        _customerService.GetCustomer();
        _customerRepository.Received(1).GetCustomerAsync();
    }

    [Test]
    public void GetCustomerById_Should_Call_GetCustomerByIdAsync_Method_In_CustomerRepository_Once()
    {
        _customerService.GetCustomerById(_customerId);
        _customerRepository.Received(1).GetCustomerByIdAsync(Arg.Any<string>());
    }

    [Test]
    public void CreateCustomer_Should_Call_CreateCustomerAsync_Method_In_CustomerRepository_Once()
    {
        _customerService.CreateCustomer(_customer);
        _customerRepository.Received(1).CreateCustomerAsync(_customer);
    }

    [Test]
    public void UpdateCustomer_Should_Call_UpdateCustomerAsync_Method_In_CustomerRepository_Once()
    {
        _customerService.UpdateCustomer(_customer, _customerId);
        _customerRepository.UpdateCustomerAsync(_customer, _customerId);
    }

    [Test]
    public void DeleteCustomer_Should_Call_DeleteCustomerAsync_Method_In_CustomerRepository_Once()
    {
        _customerService.DeleteCustomer(_customerId);
        _customerRepository.DeleteCustomerAsync(Arg.Any<string>());
    }
}