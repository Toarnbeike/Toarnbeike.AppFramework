using Toarnbeike.Results;

namespace Toarnbeike.AppFramework.Domain.Policies;

/// <summary>
/// Defines a contract for evaluating whether a candidate object satisfies a specific domain policy.
/// </summary>
/// <remarks>
/// Implementations of this interface encapsulate business rules or validation logic that determine if a given candidate meets certain criteria. 
/// This pattern is commonly used to separate policy logic from domain entities, promoting reusability and testability.
/// </remarks>
/// <typeparam name="T">The type of object to which the policy is applied.</typeparam>
public interface IDomainPolicy<in T>
{
    /// <summary>
    /// Determines whether the specified candidate satisfies the criteria defined by the specification.
    /// </summary>
    /// <param name="candidate">The object to evaluate against the specification criteria.</param>
    /// <returns>true if the candidate meets the specification; otherwise, false.</returns>
    Result Evaluate(T candidate);
}
