using Toarnbeike.Example.Domain.Addresses;
using Toarnbeike.Example.Domain.Orders;
using Toarnbeike.Results.Extensions.Unsafe;
using Toarnbeike.Unions;

namespace Toarnbeike.Example.Domain.Tests;

public class OrderAddLineItemTests
{
    private readonly Order _order;

    public OrderAddLineItemTests()
    {
        var address = new Address(AddressId.New(), "Street", "City", "Cy");
        var lineItem1 = LineItem.Create("123", "ABC", 1, 20m, "EUR");
        _order = Order.Create(address, address, [lineItem1]).GetValueOrThrow();
    }

    [Test]
    public void AddLineItem_Should_ReturnFailure_WhenCurrenciesDoNotMatch()
    {
        var newItem = LineItem.Create("234", "BCD", 1, 10m, "USD");
        var result = _order.AddLineItem(newItem);
        result.IsFailure.ShouldBeTrue();
    }

    [Test]
    public void AddLineItem_Should_ReturnFailure_WhenLineItemIsNotUnique()
    {
        var newItem = LineItem.Create("123", "ABC", 2, 20m, "EUR");
        var result = _order.AddLineItem(newItem);
        result.IsFailure.ShouldBeTrue();
    }

    [Test]
    public void AddLineItem_Should_ReturnFailure_WhenOrderIsNotModifiable()
    {
        var confirmedOrder = _order with
        {
            OrderStatus = Union<Order.Draft, Order.Confirmed, Order.Shipped>.FromT2(new Order.Confirmed(DateTimeOffset.UtcNow))
        };

        var newItem = LineItem.Create("234", "BCD", 1, 10m, "EUR");
        var result = confirmedOrder.AddLineItem(newItem);
        result.IsFailure.ShouldBeTrue();
    }

    [Test]
    public void AddLineItem_Should_ReturnSuccess_WhenInputIsValid()
    {
        var newItem = LineItem.Create("234", "BCD", 1, 10m, "EUR");
        var result = _order.AddLineItem(newItem);
        result.IsSuccess.ShouldBeTrue();
    }
}
