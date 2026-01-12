using Toarnbeike.AppFramework.Domain.Objects;

namespace Toarnbeike.Example.Domain.Addresses;

/// <summary>
/// Represents a postal address, including street, city, and country information, uniquely identified by an address ID.
/// </summary>
/// <param name="Id">The unique identifier for the address.</param>
/// <param name="Street">The street component of the address. Cannot be null or empty.</param>
/// <param name="City">The city in which the address is located. Cannot be null or empty.</param>
public sealed record Address(AddressId Id, string Street, string City, string Country) : IAggregate<AddressId>;