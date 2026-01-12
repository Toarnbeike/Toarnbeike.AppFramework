using Toarnbeike.AppFramework.Domain.Policies;
using Toarnbeike.Example.Domain.Shared;
using Toarnbeike.Results.Failures;

namespace Toarnbeike.Example.Domain.Orders.Policies;

/// <summary>
/// Represents a domain policy that enforces uniqueness of a line items within an order based on SKU.
/// </summary>
public sealed class LineItemUniquenessPolicy : IDomainPolicy<Order>
{
    public Result Evaluate(Order candidate)
    {
        var duplicates = candidate.LineItems.GroupBy(li => li.Sku)
            .Where(g => g.Count() > 1)
            .Select(g => g.Key)
            .ToList();

        return duplicates.Count switch
        {
            0 => Result.Success(),
            1 => CreateDuplicateFailure(duplicates[0]),
            _ => new AggregateFailure(duplicates.Select(CreateDuplicateFailure))
        };
    }

    private static Failure CreateDuplicateFailure(Sku sku) =>
        new("UniqueLineItemPolicy.DuplicateItem", $"LineItem {sku.Name} is duplicated in this Order.");
}
