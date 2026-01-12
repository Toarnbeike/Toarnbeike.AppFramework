# Orders Example domain

This example demonstrates how to model a small but realistic domain using the concepts provided by **Toarnbeike.AppFramework.Domain**.

The goal of this example is not to build a production-ready order system, but to illustrate how the framework supports:
- Immutable domain models
- Explicit domain transitions
- Result-based failure handling
- Domain policies for invariants
- Clear aggregate boundaries
- Derived (non-persisted) state

The domain is intentionally familiar to reduce cognitive load and keep the focus on how the framework is used.

---

## Overview

The example consists of two aggregates:

- [Order](#order-aggregate) - a behavior-rich aggregate enforcing multiple invariants
- [Address](#address-aggregate) - a simple aggregate used as a reference

Supporting concepts include:
- Entities ([LineItem](#lineitem-entity))
- Value Objects ([Money](#money-valueobject), [Sku](#sku-valueobject))
- [Domain Policies](#domain-policies) (currency and uniqueness rules)
- [Domain events](#domain-events)
- Explicit [creation](#creation) and mutation via [domain transitions](#domain-transitions)

---

## Order Aggregate

`Order` is the primary aggregate in this example.

Characteristics
- Immutable
- Behavior-rich
- Enforces all invariants internally
- Can only change state through explicit methods
- Uses Result to model expected failure

### State

An Order consists of:
- `OrderId`
- `ShippingAddress`
- `BillingAddress`
- `ImmutableList<LineItem>`
- `OrderStatus` (modeled as a union)

No derived data (such as totals) is persisted.

### Creation

Orders are created via a static factory method:

```csharp
Order.Create(...)
```

Creation is **not** treated as a domain transition, since the aggregate does not exist before the creation.
It does enforce the following invariants:
- All LineItems must use the same currency
- LineItems must be unique by Sku

This prevents invalid orders from ever exisiting in the system.

### Domain Transitions

The Order aggregate exposes explicit methods to change its state:

- `AddLineItem(...)`
- `Confirm(...)`

Each method returns a `Result<DomainTransition<Order>>` indicating success or failure.
This makes it explicit that the aggregate can only change state through these methods, and that failures are expected and must be handled.

Each method enforces the same invariants as creation, ensuring that the Order remains valid throughout its lifecycle.

### Derived State

The Order aggregate exposes derived state via read-only properties:

```csharp
public Money TotalAmount => LineItems.Sum(item => item.TotalPrice);
```

This value is:
- Derived from the current state
- Not persisted
- Guaranteed to be consistent with the aggregate state

All currency conversions and calculations are handled via domain policies to ensure correctness.

---

## LineItem Entity

`LineItem` is an entity within the Order aggregate.

### Characteristics

- Has a identity (`LineItemId`)
- Immutable
- Represents a single (unique by SKU) item in the order

A LineItem consists of:
- `SKU`
- `Quantity`
- `UnitPrice` (Money)

The total price for a LineItem is derived (not presisted) from its quantity multiplied by the unit price.

---

## Money ValueObject

`Money` is a value object representing a monetary amount in a specific currency.

Currency mismatches during internal calculations are prevented via domain policies.
If a mismatch occurs, the operation fails with a descriptive [exception](#error-handling-strategy).

---

## Sku ValueObject

`Sku` is a value object representing a stock-keeping unit identifier.

---

## Address Aggregate

`Address` is a simple aggregate used as a reference in the Order aggregate. It is intensionally kept minimal for this example.

---

## Domain policies

This example includes a couple of domain policies to enforce invariants:

- `LineItemCurrencyPolicy` 
  Ensures all LineItems in an Order use the same currency.
- `LineItemUniquenessPolicy`
  Ensures that all LineItems in an Order are unique by SKU.
- `OrderModifyablePolicy`
  Ensures that LineItems can only be added to Orders in the `Draft` status. Also ensures that only `Draft` orders can be confirmed.
- `OrderNotEmptyPolicy`
  Ensures that an Order has at least one LineItem before it can be confirmed.

These policies are applied during Order creation and mutation to maintain the integrity of the aggregate.
Violations of these policies result in failure results from the relevant methods.

---

## Domain Events

Domain events are produced as part of a `DomainTransition`. In this example, the `OrderConfirmed` event is produced when an Order is successfully confirmed.
This allows other parts of the system to react to significant state changes in the domain.

---

## Error handling Strategy

This example follows a strict rule:
- Expected business rule failures → Result
- Invariant violations (impossible states) → DomainException

As a result:
- Reads never return Result
- Transitions are the only failure points
- Exceptions indicate programmer errors, not user errors

---

## Design Principles Demonstrated

This example intentionally demonstrates the following principles:
- Immutable domain model
- Explicit domain transitions
- Policies enforce invariants, not aggregates
- Derived data is never persisted
- The domain enforces its own rules
- The application layer cannot bypass domain invariants

---

## Scope and Limitations

This example does not demonstrate:

- Persistence
- Repositories
- Application services
- UI concerns
- Infrastructure

These topics are (going to be) addressed in other examples or layers.

---

## Summary

This example domain is intentionally small, explicit, and familiar.
Its purpose is to show *how* to model a domain using `Toarnbeike.AppFramework.Domain`, not to serve as a complete order management solution.