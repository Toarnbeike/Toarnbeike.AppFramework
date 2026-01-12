# Toarnbeike.AppFramework
Optionated application framework

# AppFramework.Domain

This package provides a **minimal, opinionated domain abstraction layer** intended for applications built using **DDD, Clean Architecture, CQRS**, and **immutable domain models**.

The goal of this package is **not** to implement business logic for you, but to provide a **shared vocabulary, structure, and set of patterns** that make domain modeling:

- Explicit
- Immutable-first
- Testable
- Infrastructure-agnostic

This layer is designed to be usable with EF Core, JSON/file persistence, and in-memory application state, without leaking persistence or execution concerns into the domain.

---

## Design Philosophy

- **Immutability first**  
  Domain objects do not mutate. All state changes produce *new instances*.

- **Behavior over state**  
  Aggregates expose behavior that returns transitions, not setters.

- **Domain events are outputs, not state**  
  Events are produced by transitions, never stored inside aggregates.

- **No infrastructure dependencies**  
  No EF Core, no serialization attributes, no dispatching, no IO.

- **Explicitness over convenience**  
  All domain-relevant inputs are passed explicitly as parameters.

---

## Overview

The core abstractions provided by this package are:
- [Objects](#objects)
- [Transitions](#transitions)
- [Services](#services)
- [Policies](#policies)
- [Specifications](#specifications)
- [Summary](#summary)

---

## Objects

Domain objects represent the core entities and value objects of your domain.
They are immutable and expose behavior through methods that return transitions.
Strongly typed identities are used for entities, using the `IEntityId<T>` interface.
Domain objects are split into:
- **Entities**: Objects with a unique identity that can change state over time.
- **Aggregates**: Clusters of related entities and value objects treated as a single unit.
- **Value Objects**: Immutable objects defined by their attributes.

---

## Transitions

A domain transition represents a state change in a domain object.
Transitions are immutable and encapsulate:
- The new state of the domain object after the transition.
- Any domain events produced by the transition.

These from a clear separation between the behavior of domain objects and the effects of state changes.

Domain events are represented by the `IDomainEvent` interface.
These events capture significant occurrences within the domain that other parts of the system may need to react to.

---

## Services

An `IDateTimeProvider` interface is provided to abstract away date and time retrieval.
This allows domain logic to depend on time without coupling to system clocks, facilitating testing and consistency.

---

## Policies
Policies encapsulate business rules and constraints that govern the behavior of domain objects.
Policies answer questions like "Is this action allowed?" or "Is this transaction valid?".
Their return type is a `Result` (from [Toarnbeike.Results](https://github.com/Toarnbeike/Toarnbeike.Results)) indicating success or failure with an error message.

Concrete implementations of policies implement the `IPolicy<T>` interface, where `T` is the type of domain object the policy applies to.
These are defined in the domain layer, but enforced in the application layer.

For convenience, the `CompositePolicy<T>` class allows combining multiple policies using AND logic.

### Policy vs Specification

- **Policy**: decides *whether something may happen*, and can either be a success or a failure (**Result**)
- **Specification**: decides *whether something is true*, and can either be true or false (**bool**)

Policies are about **decisions**, while specifications are about **classification**.

---

## Specifications
Specifications encapsulate query logic for domain objects. 
Specifications answer questions like "Does this object meet certain criteria?" or "Which objects match these conditions?".

Concrete implementations of specifications implement the `ISpecification<T>` interface, where `T` is the type of domain object the specification applies to.
These are defined in the domain layer, but used in the application layer.

For convenience, the `CompositeSpecification<T>` class allows combining multiple specifications using AND logic.

---

## Exceptions

A generic abstract `DomainException` class is provided to represent unhandleable situations within the domain layer.
Concrete domain exceptions should inherit from this class to provide meaningful error handling.
- Domain exceptions should not be used to represent business rule violations; those should be handled through policies and specifications.
- Domain exceptions indicate critical issues that prevent normal operation within the domain.
- Domain exceptions typically indicate programming errors or unexpected states that should be fixed in code, rather than being recoverable at runtime.

---

## Summary

This domain layer abstraction library provides:

- A consistent DDD vocabulary
- Immutable-first modeling
- Explicit state transitions
- Clear separation of concerns
- A strong foundation for desktop applications

It is intentionally small, strict, and boring — so your domain logic does not have to be.