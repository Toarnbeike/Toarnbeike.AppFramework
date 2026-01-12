namespace Toarnbeike.AppFramework.Domain.Services;

/// <summary>
/// Defines an abstraction for obtaining the current date and time values.
/// </summary>
/// <remarks>
/// Implementations of this interface provide access to the current system date and time. 
/// This can be useful for testing or for decoupling application logic from direct system clock access.
/// </remarks>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current date and time, with an offset from Coordinated Universal Time (UTC).
    /// </summary>
    DateTimeOffset Now { get; }

    /// <summary>
    /// Gets the current date, with the time component set to midnight.
    /// </summary>
    DateOnly Today { get; }
}
