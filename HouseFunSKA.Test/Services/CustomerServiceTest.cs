using HouseFunSKA.Data;
using HouseFunSKA.Repositories;
using NSubstitute;
using NUnit.Framework;

namespace HouseFunSKA.Test.Services;

[TestFixture]
public class CustomerServiceTest
{
    [SetUp]
    public void SetUp()
    {
        _northwindContext = Substitute.For<NorthwindContext>();
    }

    private NorthwindContext _northwindContext;

    [Test]
    public void GetCustomer_Should_Call_GetCustomerAsync_Method_In_CustomerRepository_Once()
    {
        var customerRepository = new CustomerRepository(_northwindContext);
    }
}