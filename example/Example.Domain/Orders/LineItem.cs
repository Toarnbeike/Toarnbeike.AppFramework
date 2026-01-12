using Toarnbeike.AppFramework.Domain.Objects;
using Toarnbeike.Example.Domain.Shared;

namespace Toarnbeike.Example.Domain.Orders;

/// <summary>
/// Represents an item within an order, including its identifier, product SKU, quantity, and unit price.
/// </summary>
/// <param name="Id">The unique identifier for the line item.</param>
/// <param name="Sku">The stock keeping unit (SKU) that identifies the product associated with this line item.</param>
/// <param name="Quantity">The number of units of the product included in this line item. Must be greater than zero.</param>
/// <param name="UnitPrice">The price per single unit of the product, including currency information.</param>
public sealed record LineItem(LineItemId Id, Sku Sku, int Quantity, Money UnitPrice) : IEntity<LineItemId>
{
    /// <summary>
    /// Gets the total price for the item, calculated as the unit price multiplied by the quantity.
    /// </summary>
    public Money TotalPrice => new(UnitPrice.Amount * Quantity, UnitPrice.Currency);

    public static LineItem Create(string skuIdentifier, string skuName, int quantity, decimal price, string currency = "EUR")
    {
        var unitPrice = new Money(price, currency);
        var sku = new Sku(skuIdentifier, skuName);

        return new LineItem(LineItemId.New(), sku, quantity, unitPrice);
    }
}