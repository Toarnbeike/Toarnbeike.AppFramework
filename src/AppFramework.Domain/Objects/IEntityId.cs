namespace Toarnbeike.AppFramework.Domain.Objects;

/// <summary>
/// Represents a strongly-typed identifier for an entity.
/// </summary>
/// <remarks>
/// Implementations of this interface provide a type-safe way to reference entities by their unique identifier.
/// This pattern helps prevent accidental misuse of identifiers across different entity types.
/// </remarks>
public interface IEntityId
{
    /// <summary>
    /// The underlying GUID value of the entity identifier.
    /// </summary>
    Guid Value { get; }
}
