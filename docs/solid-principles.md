# SOLID Principles
## Single Responsibility
"A class should have one, and only one **reason to change**."  

What is the responsibility of your class/component/service/specification/framework?

The answer can/should still be multi-tiered. Here's one example of digging deeper into one's responsibility by describing subcomponents' single responsibilities as well:

* The service *SetResolver*'s only responsibility is to provide solutions to any combination of cards in the card game *Set*. To achieve that, you need to break it down into multiple pieces. 

* The *Board* class is responsible to manage the board of the game, with its cards.

* The *Card* class represents each individual card of the game, including its properties and the inherent capabilities of comparing itself to other instances of the same type. 


## Open/Close

"**OPEN** for extension, **CLOSED** for modification."

Interfaces are by definition closed for modification and require you to provide new implementations.

## Liskov Substitution

"Instances of a superclass shall be replaceable with instnces of its subclasses without breaking the application."

* Don’t implement any stricter validation rules on input parameters than implemented by the parent class.

* Apply at the least the same rules to all output parameters as applied by the parent class.

## Interface Segregation

"Clients should not be forced to depend upon interfaces that they do not use."

A symptom of breaking this principle is when you see subtypes forced to implement methods or properties of the superclasses that they don't use. Some times it manifests itself as empty methods, *Invalid Operation Exceptions* or *Not Implemented Exceptions*.

## Dependency Inversion

"High-level **and** low-level modules depend on abstractions. High-level modules "