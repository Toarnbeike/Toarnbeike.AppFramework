using Toarnbeike.AppFramework.Domain.Exceptions;

namespace Toarnbeike.Example.Domain.Exceptions;

/// <summary>
/// The exception that is thrown when an operation attempts to combine or compare monetary values with different
/// currencies.
/// </summary>
/// <remarks>
/// This exception typically indicates a logic error where monetary values of different currencies are
/// used together in an unsupported operation.
/// This is a typical example of an invariant violation in domain-driven design.
/// If this exception is thrown, it indicates that the code must be corrected to ensure currency consistency.
/// </remarks>
/// <param name="ExpectedCurrency">The currency code that was expected by the operation.</param>
/// <param name="ActualCurrency">The currency code that was actually provided.</param>
public class CurrencyMismatchException(string ExpectedCurrency, string ActualCurrency)
    : DomainException($"Currency mismatch: cannot combine money with different currencies. Expected '{ExpectedCurrency}', but got '{ActualCurrency}'.");
