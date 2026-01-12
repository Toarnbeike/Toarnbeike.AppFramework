using Toarnbeike.AppFramework.Domain.Policies;

namespace Toarnbeike.Example.Domain.Orders.Policies;

/// <summary>
/// Represents a domain policy that enforces that all line items within an order have the same currency.
/// </summary>
/// <param name="itemToAdd">The line item to be evaluated for correct currency when adding to the order.</param>
public sealed class LineItemCurrencyPolicy : IDomainPolicy<Order>
{
    public Result Evaluate(Order candidate)
    {
        if (candidate.LineItems.Count <= 1)
        {
            return Result.Success();                // No need to check consistent currency if there's 0 or 1 item
        }

        var currency = candidate.LineItems[0].UnitPrice.Currency;

        foreach (var li in candidate.LineItems)
        {
            if (li.UnitPrice.Currency != currency)
            {
                return new Failure("LineItemCurrencyPolicy.Violation", $"LineItem {li.Sku.Name} has a price in {li.UnitPrice.Currency}, which is inconsistent with other line items in the order.");
            }
        }

        return Result.Success();
    }
}