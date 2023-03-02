# Design Steps

This general recommendation for a sequence of initial steps is arranged in such order so it builds up on information acquired on previous steps and each step forward makes it for easier execution of subsequent steps. It should be obvious that this is not a serialized, or waterfall-style approach. While designing a system, you are constantly and consistently detailing and enriching all aspects of the design.

## 1. Requirements, clarifications, understanding the problem

Read through whatever information is available, ask questions to fill gaps, add details or clarify ambiguity. Thinking about the next steps should also give you some important questions to ask right off the gate. Tailor the questions to what the problem is, obviously. For example:

- Is there a need for the system to be open for anybody to access it anonymously without any kind of checks or authentication?
- Do you need an administration interface/API/portal?
- Will there be third-parties consuming our API, or only the user interfaces?

It may be helpful to break requirements down into the typical categories of functional and non-functional, but often there will be requirements that don't really fit on these two. Don't ignore those, just list them as "others" or whatever makes sense for the context of the system being designed.

## 2. Make quick but meaningful estimations of scale

The main important estimation to do really early is the scale of the system being created. Even (or specially) if the estimations point to a very small scale. These estimates will drive and ease a lot of the decisions ahead.

When estimating the scale, the main aspects to consider are related to capacity and constraints. Here are a few topics to remember, but don't be limited to those:

- Expected number of transactions
- Share/ratio/proportion of different types of transactions
- Network or traffic resource capacity
- Bandwidth needs or constraints
- Storage needs
- Caching and memory

## 3. Define an interface

The interface should explicitly address the requirements defined earlier. Spend some time listing all the operations that would achieve that goal. This interface establishes the contracts between the system and the external agents.

There might be a need for more than one of those contracts, depending on what was discovered during the requirements clarification step.

## 4. Define a data model

Understanding data and a high level idea of a persistence model brings instant insights for what data is important, and greatly improves and facilitates the discovery and definition of data flow between components of the system, as well as early detection of the potential need for partitioning, storage, retrieval and management data.

Yes, data model does mean database schema. Use the schema as the reference point for your data model considerations.

It is natural and very common to come out of this step already knowing what kind of database systems will be required, such as NoSQL *vs.* SQL, blob storage, memory caches, etc.

## 5. High-level design

Get to the boxes and arrows. Represent the core components of the system at a level that is enough for describing the solution to the problem from end to end. Typically you'll have the different clients, servers, load balancers, storage points, database systems, etc. And their relationship to each other.

## 6. Refine design details

Having the big picture for the end to end system, dig deeper at least into a few of the components already identified. Most or all of the times you add details to the design of any component or systems, you'll be making decisions and choosing between multiple alternatives or options. Make sure you consider those options. If you have trouble picturing more than one obvious solution, try a little harder, dig deeper for those alternatives. Consider tha advantages and disadvantages of the solutions considered to pick one (or more) options to be explored.

These examples could be good source of inspiration:

- Is the amount of data being stored large enough to consider partitioning? How would you go about that?
- Do you need different data storages for different data?
- What kind of constraints and limits should be enforced? How do you prevent abuse?
- Where are the risks for runaway components or single points of failure?
- Would caching be useful? At what level? Between which components?
- Now that you know how each component interacts with each other, and how the data flows between then, would you change how data is stored at any component or overall?
- Do you need to change your mind on load balancers? Add some, move some?

## 7. Identify bottlenecks

Although by now you've already thought a lot about bottlenecks and inefficiencies, dedicate some time to focus only on that. As with the previous step, strive to identify multiple alternatives to mitigate the problem. Remember to consider side effects, pros and cons. Revisit your previous findings and verify your assumptions. For example:

- Have you thought about all the single points of failure?
- Will the redundant components always have access to the data they need, in other words, did you design for enough replication and distribution of data?
- When failure does occur, how do you mitigate those scenarios?
- What will you monitor to identify runtime performance trends before it's too late? Who/what will be alerted, and what would they do when alerts come?
