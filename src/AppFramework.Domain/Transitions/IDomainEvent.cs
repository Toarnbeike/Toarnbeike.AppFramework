namespace Toarnbeike.AppFramework.Domain.Transitions;

/// <summary>
/// Represents a domain event that captures a significant change or occurrence within the domain model.
/// </summary>
/// <remarks>
/// Domain events are used to signal that something of interest has happened within the domain, 
/// allowing other parts of the system to react or process the event as needed.
/// Implementations typically include additional contextual information relevant to the specific event.
/// </remarks>
public interface IDomainEvent
{
    /// <summary>
    /// Gets the unique identifier for the object.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    DateTimeOffset OccuredAt { get; }
}
