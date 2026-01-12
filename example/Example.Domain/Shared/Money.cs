using Toarnbeike.AppFramework.Domain.Objects;
using Toarnbeike.Example.Domain.Exceptions;

namespace Toarnbeike.Example.Domain.Shared;

/// <summary>
/// Represents a monetary value in a specific currency as an immutable value object.
/// </summary>
/// <remarks>Use this type to model monetary values in a type-safe manner, ensuring that currency is always
/// specified alongside the amount. Instances of this type are immutable and support value-based equality. Operations
/// involving multiple Money instances require matching currencies.</remarks>
/// <param name="Amount">The numeric amount of money represented by this instance.</param>
/// <param name="Currency">The ISO currency code (such as "USD" or "EUR") that specifies the currency of the amount.</param>
public readonly record struct Money(decimal Amount, string Currency) : IValueObject
{
    public static Money Zero(string currency) => new(0m, currency);

    public Money Add(Money other)
    {
        if (Currency != other.Currency)
        {
            throw new CurrencyMismatchException(Currency, other.Currency);
        }

        return new Money(Amount + other.Amount, other.Currency);
    }
}
