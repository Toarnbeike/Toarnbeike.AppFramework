using Toarnbeike.Example.Domain.Addresses;
using Toarnbeike.Example.Domain.Orders;

namespace Toarnbeike.Example.Domain.Tests;

public class OrderCreateTests
{
    [Test]
    public void Create_Should_ReturnFailure_WhenCurrenciesDoNotMatch()
    {
        var address = new Address(AddressId.New(), "Street", "City", "Cy");
        var lineItem1 = LineItem.Create("123", "ABC", 1, 20m, "EUR");
        var lineItem2 = LineItem.Create("234", "BCD", 1, 10m, "USD");

        var creationResult = Order.Create(address, address, [lineItem1, lineItem2]);
        creationResult.IsFailure.ShouldBeTrue();
    }

    [Test]
    public void Create_Should_ReturnFailure_WhenLineItemIsNotUnique()
    {
        var address = new Address(AddressId.New(), "Street", "City", "Cy");
        var lineItem1 = LineItem.Create("123", "ABC", 1, 20m, "EUR");
        var lineItem2 = LineItem.Create("123", "ABC", 3, 20m, "EUR");

        var creationResult = Order.Create(address, address, [lineItem1, lineItem2]);
        creationResult.IsFailure.ShouldBeTrue();
    }

    [Test]
    public void Create_Should_ReturnSuccess_WhenInputIsValid()
    {
        var address = new Address(AddressId.New(), "Street", "City", "Cy");
        var lineItem1 = LineItem.Create("123", "ABC", 1, 20m, "EUR");
        var lineItem2 = LineItem.Create("234", "BCD", 1, 10m, "EUR");

        var creationResult = Order.Create(address, address, [lineItem1, lineItem2]);
        creationResult.IsSuccess.ShouldBeTrue();
    }
}
