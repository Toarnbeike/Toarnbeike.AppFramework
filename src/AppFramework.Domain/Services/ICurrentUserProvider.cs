namespace Toarnbeike.AppFramework.Domain.Services;

/// <summary>
/// Defines an abstraction for obtaining information about the current user.
/// </summary>
public interface ICurrentUserProvider
{
    /// <summary>
    /// Gets the name of the current user.
    /// </summary>
    string UserName { get; }
}