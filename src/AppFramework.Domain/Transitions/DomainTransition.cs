using Toarnbeike.AppFramework.Domain.Objects.Markers;
using Toarnbeike.AppFramework.Domain.Transitions;

namespace Toarnbeike.AppFramework;

/// <summary>
/// Represents the result of a domain operation, containing the updated aggregate and the domain events produced by the
/// transition.
/// </summary>
/// <remarks>
/// Use this struct to encapsulate both the new aggregate state and the events that should be published
/// as a result of a domain operation.
/// This keeps the aggregates immutable, while allowing domain events to be fired after completion.</remarks>
/// <typeparam name="TAggregate">The type of the aggregate involved in the domain transition.</typeparam>
/// <param name="Aggregate">The aggregate instance resulting from the domain operation.</param>
/// <param name="Events">The collection of domain events generated during the transition.</param>
public readonly record struct DomainTransition<TAggregate>(
    TAggregate Aggregate, 
    IReadOnlyCollection<IDomainEvent> Events) where TAggregate : IAggregateMarker
{
    /// <summary>
    /// Creates a new domain transition representing the specified aggregate and the provided domain events.
    /// </summary>
    /// <param name="aggregate">The aggregate instance that is the subject of the domain transition.</param>
    /// <param name="events">One or more domain events that describe changes applied to the aggregate.</param>
    /// <returns>A new <see cref="DomainTransition{TAggregate}"/> containing the specified aggregate and domain events.</returns>
    public static DomainTransition<TAggregate> From(TAggregate aggregate, params IDomainEvent[] events) 
        => new(aggregate, events);
}
