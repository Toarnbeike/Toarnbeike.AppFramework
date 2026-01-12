namespace Toarnbeike.AppFramework.Domain.Specifications;

/// <summary>
/// Defines a contract for evaluating whether a candidate object satisfies a specified criterium.
/// </summary>
/// <remarks>
/// Implementations of this interface encapsulate business rules or filtering logic that can be reused and combined.
/// Specifications are commonly used to separate validation or selection logic from business objects,
/// supporting patterns such as querying, validation, or rule enforcement.</remarks>
/// <typeparam name="T">The type of object to which the specification is applied.</typeparam>
public interface ISpecification<T>
{
    /// <summary>
    /// Determines whether the specified candidate satisfies the criteria defined by the specification.
    /// </summary>
    /// <param name="candidate">The object to evaluate against the specification criteria.</param>
    /// <returns>true if the candidate satisfies the specification; otherwise, false.</returns>
    bool IsSatisfiedBy(T candidate);
}
