using Toarnbeike.AppFramework.Domain.Objects.Markers;
using Toarnbeike.AppFramework.Domain.Transitions;

namespace Toarnbeike.AppFramework;

/// <summary>
/// Extensions for working with <see cref="DomainTransition{TAggregate}"/> instances.
/// </summary>
public static class DomainTransitionExtensions
{
    /// <summary>
    /// Creates a new domain transition by associating the specified domain event with the current aggregate state.
    /// </summary>
    /// <remarks>
    /// This method does not modify the original transition; instead, it returns a new instance with
    /// the event applied. Both parameters must be non-null.</remarks>
    /// <typeparam name="TAggregate">The type of the aggregate associated with the domain transition.</typeparam>
    /// <param name="transition">The existing domain transition containing the aggregate to associate with the event. Cannot be null.</param>
    /// <param name="domainEvent">The domain event to apply to the aggregate. Cannot be null.</param>
    /// <returns>A new <see cref="DomainTransition{TAggregate}" /> instance representing the aggregate and the specified domain event.</returns>
    public static DomainTransition<TAggregate> WithEvent<TAggregate>(
        this DomainTransition<TAggregate> transition,
        IDomainEvent domainEvent) where TAggregate : IAggregateMarker =>
            DomainTransition<TAggregate>.From(transition.Aggregate, domainEvent);

    /// <summary>
    /// Combines two domain transitions into a single transition by merging their aggregates and domain events.
    /// </summary>
    /// <typeparam name="TAggregate">The type of the aggregate involved in the domain transitions.</typeparam>
    /// <param name="first">The first domain transition.</param>
    /// <param name="second">The second domain transition.</param>
    /// <returns>
    /// A new <see cref="DomainTransition{TAggregate}"/> that contains the aggregate from the second transition
    /// and a combined list of domain events from both transitions.
    /// </returns>
    public static DomainTransition<TAggregate> CombineWith<TAggregate>(
        this DomainTransition<TAggregate> first,
        DomainTransition<TAggregate> second) where TAggregate : IAggregateMarker
    {
        var combinedEvents = first.Events.Concat(second.Events).ToArray();
        return new DomainTransition<TAggregate>(second.Aggregate, combinedEvents);
    }
}