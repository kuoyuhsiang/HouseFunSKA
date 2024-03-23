using HouseFunSKA.Repositories;
using NUnit.Framework;

namespace HouseFunSKA.Test.Services;

[TestFixture]
public class CustomerServiceTest
{
    [Test]
    public void GetCustomer_Should_Call_GetCustomerAsync_Method_In_CustomerRepository_Once()
    {
        var customerRepository = new CustomerRepository();
    }






}