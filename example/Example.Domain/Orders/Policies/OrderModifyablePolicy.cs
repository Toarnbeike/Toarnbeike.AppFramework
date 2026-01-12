using Toarnbeike.AppFramework.Domain.Policies;

namespace Toarnbeike.Example.Domain.Orders.Policies;

/// <summary>
/// Represents a domain policy that determines whether an order can be modified based on its current status.
/// </summary>
public sealed class OrderModifyablePolicy : IDomainPolicy<Order>
{
    public Result Evaluate(Order candidate)
    {
        return candidate.OrderStatus.IsT1
            ? Result.Success()
            : new Failure("AddLineItem.WrongOrderStatus", $"Order {candidate.Id} can't be modified because it has status {candidate.OrderStatus}");
    }
}
