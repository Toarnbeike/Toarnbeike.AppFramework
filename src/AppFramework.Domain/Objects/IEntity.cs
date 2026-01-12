using Toarnbeike.AppFramework.Domain.Objects.Markers;

namespace Toarnbeike.AppFramework.Domain.Objects;

/// <summary>
/// Represents a domain entity with a strongly-typed identifier.
/// </summary>
/// <typeparam name="TId">The type of the unique identifier for the entity.</typeparam>
public interface IEntity<out TId> : IEntityMarker where TId : IEntityId
{
    /// <summary>
    /// Strongly-typed identifier of the entity.
    /// </summary>
    TId Id { get; }
}
