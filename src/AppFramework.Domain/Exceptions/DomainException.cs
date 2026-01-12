namespace Toarnbeike.AppFramework.Domain.Exceptions;

/// <summary>
/// Represents errors that occur when a business rule or domain constraint is violated within the application domain.
/// </summary>
/// <remarks>
/// Domain exceptions are used to signal violations of invariants in domain-driven design.
/// This exception type indicates that an operation could not be completed because it would result in an invalid state according to the business rules.
/// Use this exception type as a base class for more specific domain-related exceptions to provide meaningful error handling and reporting.
/// </remarks>
/// <param name="Message">The message that describes the error. This value is intended to provide a human-readable explanation of the domain violation.</param>
public abstract class DomainException(string Message) : Exception(Message);
