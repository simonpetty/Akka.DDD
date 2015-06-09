# Akka.DDD
Example of DDD in Akka - where an Aggregate Root is an Actor

Domain Driven Design is a way of writing application logic in the languag of your business domain.

DDD relies on the concept of aggregates roots which define a consistency boundary, which accepts commands and publishes events.

Communication between aggregates is driven by these events and in separate transactions.

This currently uses my own implementation of Akka.Persistence.EventStore which uses https://geteventstore.com/

There are implementations for SQL etc.. but Event Sourcing is what EventStore was created for.
