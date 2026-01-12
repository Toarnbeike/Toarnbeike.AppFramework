namespace Toarnbeike.AppFramework.Domain.Objects.Markers;

/// <summary>
/// Marker interface to denote domain entities.
/// </summary>
/// <remarks>
/// This interface does not define any members and is intended to be used as a tagging mechanism.
/// Implementing this interface allows frameworks or libraries to recognize entities for purposes such as
/// persistence, validation, or event sourcing, without requiring strongly typed Id <see cref="IEntityId"/> info.
/// </remarks>
public interface IEntityMarker;
