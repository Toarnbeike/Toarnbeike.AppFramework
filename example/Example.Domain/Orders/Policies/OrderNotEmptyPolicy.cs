using Toarnbeike.AppFramework.Domain.Policies;

namespace Toarnbeike.Example.Domain.Orders.Policies;

/// <summary>
/// Represents a domain policy that determines whether an order contains at least one line item.
/// </summary>
internal sealed class OrderNotEmptyPolicy : IDomainPolicy<Order>
{
    public Result Evaluate(Order candidate)
    {
        if (candidate.LineItems.IsEmpty)
        {
            return new Failure("ConfirmOrder.Empty", $"Can't confirm an order without any line items.");
        }

        return Result.Success();
    }
}
