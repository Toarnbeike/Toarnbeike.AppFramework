using Toarnbeike.AppFramework.Domain.Objects;

namespace Toarnbeike.Example.Domain.Addresses;

/// <summary>
/// Represents a strongly typed identifier for an address entity.
/// </summary>
/// <param name="Value">The underlying <see cref="System.Guid"/> value that uniquely identifies the address.</param>
public readonly record struct AddressId(Guid Value) : IEntityId
{
    public static AddressId New() => new(Guid.CreateVersion7());
}
