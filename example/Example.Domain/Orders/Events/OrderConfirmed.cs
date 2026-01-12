using Toarnbeike.AppFramework.Domain.Transitions;

namespace Toarnbeike.Example.Domain.Orders.Events;

/// <summary>
/// Represents a domain event indicating that an order has been confirmed.
/// </summary>
/// <remarks>
/// This event is published when an order transitions to a confirmed state in the domain.
/// Consumers can use this event to trigger downstream processes such as notifications or fulfillment.</remarks>
/// <param name="Id">The unique identifier for this event instance.</param>
/// <param name="OrderId">The identifier of the order that was confirmed.</param>
/// <param name="OccuredAt">The date and time, in UTC, when the order confirmation occurred.</param>
public sealed record OrderConfirmed(Guid Id, OrderId OrderId, DateTimeOffset OccuredAt) : IDomainEvent
{
    public static OrderConfirmed Create(Order order, DateTimeOffset occuredAt) =>
        new(Guid.CreateVersion7(), order.Id, occuredAt);
}
