namespace Toarnbeike.AppFramework.Domain.Objects.Markers;

/// <summary>
/// Represents a marker interface used to denote aggregate roots.
/// </summary>
/// <remarks>
/// This interface does not define any members and is intended to be used as a tagging mechanism.
/// Implementing this interface allows frameworks or libraries to recognize aggregate roots for purposes such as
/// persistence, validation, or event sourcing, without requiring strongly typed Id <see cref="IEntityId"/> info.
/// </remarks>
public interface IAggregateMarker;
