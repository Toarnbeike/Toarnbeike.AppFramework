using Toarnbeike.AppFramework.Domain.Objects;

namespace Toarnbeike.Example.Domain.Orders;

/// <summary>
/// Represents a strongly typed identifier for an order.
/// </summary>
/// <param name="Value">The underlying <see cref="System.Guid"/> value that uniquely identifies the order.</param>
public readonly record struct OrderId(Guid Value) : IEntityId
{
    public static OrderId New() => new(Guid.CreateVersion7());
}