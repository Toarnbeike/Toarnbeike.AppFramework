namespace Toarnbeike.AppFramework.Domain.Specifications;

/// <summary>
/// Represents a composite specification that is satisfied only when all contained specifications are satisfied by a candidate.
/// </summary>
/// <remarks>Use this class to combine multiple specifications into a single logical 'AND' operation. 
/// The composite is satisfied only if every individual specification in the collection is satisfied by the candidate. 
/// This is useful for building complex business rules from simpler, reusable specifications.</remarks>
/// <typeparam name="T">The type of object to which the specifications apply.</typeparam>
/// <param name="specifications">The collection of specifications that must all be satisfied for the composite specification to be satisfied.</param>
public class CompositeSpecification<T>(IEnumerable<ISpecification<T>> specifications) : ISpecification<T>
{
    /// <inheritdoc />
    public bool IsSatisfiedBy(T candidate) => 
        specifications.All(spec => spec.IsSatisfiedBy(candidate));
}
