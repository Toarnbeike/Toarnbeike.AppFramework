using Toarnbeike.AppFramework.Domain.Objects.Markers;

namespace Toarnbeike.AppFramework.Domain.Objects;

/// <summary>
/// Represents an aggregate root entity in a domain-driven design context, which serves as the entry point
/// for modifying and accessing the aggregate's state.
/// </summary>
/// <remarks>
/// Aggregate roots are responsible for maintaining the consistency of changes within the aggregate. 
/// This interface is used to enforce aggregate boundaries and event tracking in domain models.
/// </remarks>
/// <typeparam name="TId">The type of the unique identifier for the aggregate root.</typeparam>
public interface IAggregate<out TId> : IEntity<TId>, IAggregateMarker where TId : IEntityId;
