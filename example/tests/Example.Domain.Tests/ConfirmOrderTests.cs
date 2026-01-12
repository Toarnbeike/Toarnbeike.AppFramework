using Toarnbeike.AppFramework.Domain.Services;
using Toarnbeike.Example.Domain.Addresses;
using Toarnbeike.Example.Domain.Orders;
using Toarnbeike.Results.Extensions.Unsafe;
using Toarnbeike.Unions;

namespace Toarnbeike.Example.Domain.Tests;

public class ConfirmOrderTests
{
    private readonly Order _order;
    private readonly IDateTimeProvider _dateTimeProvider = new MockDateTimeProvider();
    public ConfirmOrderTests()
    {
        var address = new Address(AddressId.New(), "Street", "City", "Cy");
        var lineItem1 = LineItem.Create("123", "ABC", 1, 20m, "EUR");
        _order = Order.Create(address, address, [lineItem1]).GetValueOrThrow();
    }

    [Test]
    public void Confirm_Should_ReturnFailure_WhenOrderIsNotInDraftStatus()
    {
        var confirmedOrder = _order with
        {
            OrderStatus = Union<Order.Draft, Order.Confirmed, Order.Shipped>.FromT2(new Order.Confirmed(DateTimeOffset.UtcNow))
        };
        var result = confirmedOrder.Confirm(_dateTimeProvider);
        result.IsFailure.ShouldBeTrue();
    }

    [Test]
    public void Confirm_Should_ReturnSuccess_WhenOrderIsInDraftStatus()
    {
        var result = _order.Confirm(_dateTimeProvider);
        result.IsSuccess.ShouldBeTrue();
    }

    private class MockDateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now => new(2026,1,1,12,0,0,TimeSpan.Zero);

        public DateOnly Today => new(2026,1,1);
    }
}