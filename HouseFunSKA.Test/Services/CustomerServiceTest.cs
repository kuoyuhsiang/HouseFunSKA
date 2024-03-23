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
}