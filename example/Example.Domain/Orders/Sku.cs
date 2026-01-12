using Toarnbeike.AppFramework.Domain.Objects;

namespace Toarnbeike.Example.Domain.Shared;

/// <summary>
/// Represents a stock keeping unit (SKU) with a unique identifier and display name.
/// </summary>
/// <param name="Identifier">The unique code that identifies the SKU. Cannot be null or empty.</param>
/// <param name="Name">The display name of the SKU. Cannot be null or empty.</param>
public readonly record struct Sku(string Identifier, string Name) : IValueObject;