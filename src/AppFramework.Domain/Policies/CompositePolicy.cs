using Toarnbeike.Results;
using Toarnbeike.Results.Collections;

namespace Toarnbeike.AppFramework.Domain.Policies;

/// <summary>
/// Represents a policy that is satisfied only when all contained domain policies are satisfied by a given candidate.
/// </summary>
/// <remarks>
/// CompositePolicy enables combining multiple domain policies into a single policy using logical AND semantics. 
/// This is useful for scenarios where an object must meet several independent criteria to be considered valid.
/// The policy is satisfied if and only if every contained policy is satisfied by the candidate.
/// </remarks>
/// <typeparam name="T">The type of object to which the policy applies.</typeparam>
public sealed class CompositePolicy<T>(params IEnumerable<IDomainPolicy<T>> policies) : IDomainPolicy<T>
{
    /// <inheritdoc />
    public Result Evaluate(T candidate) =>
        policies.Select(policy => policy.Evaluate(candidate)).Aggregate();
}