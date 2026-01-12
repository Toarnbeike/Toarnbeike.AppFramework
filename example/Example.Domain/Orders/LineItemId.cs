using Toarnbeike.AppFramework.Domain.Objects;

namespace Toarnbeike.Example.Domain.Orders;

/// <summary>
/// Represents the unique identifier for a line item.
/// </summary>
/// <param name="Value">The underlying <see cref="System.Guid"/> value that uniquely identifies the line item.</param>
public readonly record struct LineItemId(Guid Value) : IEntityId
{
    public static LineItemId New() => new(Guid.CreateVersion7());
}