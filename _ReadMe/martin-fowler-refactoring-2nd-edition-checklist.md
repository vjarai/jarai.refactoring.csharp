# Martin Fowler — Refactoring 2nd Edition Checklist

**Source:** *Refactoring: Improving the Design of Existing Code*, 2nd Edition, Martin Fowler with Kent Beck, 2018.

| Done | Refactoring | Purpose / When to Use | Typical Code Smell / Signal | Category |
|:---:|---|---|---|---|
| [ ] | **Combine Functions into Class** | Group functions that operate on the same data into a class. | Related functions scattered across modules | A First Set |
| [ ] | **Combine Functions into Transform** | Combine related calculations into one transformation of data. | Multiple functions repeatedly transforming the same data | A First Set |
| [ ] | **Encapsulate Variable** | Control access to a variable through functions or accessors. | Global or widely accessed mutable variable | A First Set |
| [ ] | **Extract Function** | Move a coherent piece of code into a named function. | Long function; repeated or difficult-to-understand code | A First Set |
| [ ] | **Extract Variable** | Give a complex expression a meaningful name. | Complicated expression repeated or hard to understand | A First Set |
| [ ] | **Inline Function** | Replace a function call with the function's body. | Function adds little or no useful abstraction | A First Set |
| [ ] | **Inline Variable** | Replace a variable with the expression it represents. | Variable adds no clarity | A First Set |
| [ ] | **Introduce Parameter Object** | Group related parameters into a single object. | Long parameter list; recurring group of parameters | A First Set |
| [ ] | **Remove Dead Code** | Delete code that is no longer executed or needed. | Unreachable, unused, or obsolete code | A First Set |
| [ ] | **Rename Variable** | Give a variable a clearer and more meaningful name. | Short, misleading, or ambiguous variable name | A First Set |
| [ ] | **Replace Loop with Pipeline** | Express collection processing as a sequence of transformations. | Complex loop performing filter/map/reduce operations | A First Set |
| [ ] | **Split Phase** | Separate code into distinct phases with a clear data flow between them. | Function mixing parsing, transformation, and processing | A First Set |
| [ ] | **Encapsulate Collection** | Prevent direct manipulation of an object's internal collection. | Collection exposed directly to callers | Encapsulation |
| [ ] | **Encapsulate Record** | Replace a freely accessible record with an object that controls access to its data. | Public record/object with uncontrolled fields | Encapsulation |
| [ ] | **Replace Primitive with Object** | Replace a primitive value with an object that represents the domain concept. | Primitive obsession; repeated validation/behavior | Encapsulation |
| [ ] | **Replace Temp with Query** | Replace a temporary calculation with a function that performs the calculation. | Complex temporary variable | Encapsulation |
| [ ] | **Extract Class** | Move part of a class's responsibilities into a new class. | Large class; multiple unrelated responsibilities | Moving Features |
| [ ] | **Inline Class** | Move a class's functionality into another class when the class no longer has enough responsibility. | Tiny or redundant class | Moving Features |
| [ ] | **Move Field** | Move a field to the class that uses or owns it more appropriately. | Field used primarily by another class | Moving Features |
| [ ] | **Move Function** | Move a function to the module or class where it logically belongs. | Function depends more on another module's data | Moving Features |
| [ ] | **Move Statements into Function** | Move repeated setup or follow-up code into the function that conceptually owns it. | Repeated code around every function call | Moving Features |
| [ ] | **Move Statements to Callers** | Move caller-specific statements out of a function. | Function contains behavior needed by only some callers | Moving Features |
| [ ] | **Replace Inline Code with Function Call** | Replace duplicated inline logic with a call to an existing function. | Inline implementation duplicates named function | Moving Features |
| [ ] | **Slide Statements** | Move related statements together to improve locality and prepare for further refactoring. | Related code separated by unrelated statements | Moving Features |
| [ ] | **Split Loop** | Separate a loop that performs multiple unrelated tasks into separate loops. | Loop with multiple responsibilities | Moving Features |
| [ ] | **Change Reference to Value** | Turn an object that should behave like a value into a value object. | Shared object where identity is not important | Organizing Data |
| [ ] | **Change Value to Reference** | Make multiple copies of logically identical data refer to one shared object. | Duplicate objects representing the same entity | Organizing Data |
| [ ] | **Rename Field** | Give a field a clearer and more accurate name. | Ambiguous, misleading, or outdated field name | Organizing Data |
| [ ] | **Replace Derived Variable with Query** | Calculate a value when needed instead of storing derived state. | Stored value can become inconsistent with source data | Organizing Data |
| [ ] | **Split Variable** | Use separate variables when one variable is reused for different purposes. | Variable assigned repeatedly for different meanings | Organizing Data |
| [ ] | **Consolidate Conditional Expression** | Combine several conditional expressions that lead to the same result. | Repeated or logically equivalent conditions | Simplifying Conditional Logic |
| [ ] | **Decompose Conditional** | Extract complex condition, then-branch, and else-branch logic into named functions. | Complex `if/else` logic | Simplifying Conditional Logic |
| [ ] | **Introduce Assertion** | Explicitly state assumptions that should always be true. | Implicit assumptions or undocumented invariants | Simplifying Conditional Logic |
| [ ] | **Introduce Special Case** | Represent a special or missing case with a dedicated object instead of repeated conditionals. | Repeated null/special-case checks | Simplifying Conditional Logic |
| [ ] | **Replace Conditional with Polymorphism** | Move conditional behavior into polymorphic implementations. | Large type-based `switch`/`if` logic | Simplifying Conditional Logic |
| [ ] | **Replace Nested Conditional with Guard Clauses** | Handle exceptional or special cases early and keep the main path simple. | Deeply nested conditional logic | Simplifying Conditional Logic |
| [ ] | **Change Function Declaration** | Change a function's name, parameters, or signature to better express its purpose. | Poorly named function; awkward or outdated parameters | Refactoring APIs |
| [ ] | **Hide Delegate** | Hide an object's collaborator from callers by providing an appropriate interface. | Clients navigating through object chains | Refactoring APIs |
| [ ] | **Parameterize Function** | Combine similar functions by replacing differing values with parameters. | Several nearly identical functions | Refactoring APIs |
| [ ] | **Preserve Whole Object** | Pass an entire object instead of extracting and passing several individual values. | Multiple parameters originate from the same object | Refactoring APIs |
| [ ] | **Remove Flag Argument** | Replace a boolean or flag parameter with more explicit functions. | Function behavior controlled by a flag | Refactoring APIs |
| [ ] | **Remove Middle Man** | Remove unnecessary delegation and let clients access the relevant object directly. | Excessive forwarding methods | Refactoring APIs |
| [ ] | **Remove Setting Method** | Remove a setter when a field should not be changed after initialization. | Unnecessary mutable state | Refactoring APIs |
| [ ] | **Replace Command with Function** | Replace a command object with a simpler function when the object provides no useful state. | Command class with little independent state | Refactoring APIs |
| [ ] | **Replace Constructor with Factory Function** | Use a factory function when object creation needs flexibility or clearer semantics. | Complex construction logic; varying object types | Refactoring APIs |
| [ ] | **Replace Function with Command** | Turn a function into an object when explicit state or decomposition of the operation is useful. | Function with complex internal state | Refactoring APIs |
| [ ] | **Replace Parameter with Query** | Let a function obtain a value itself instead of receiving it as a parameter. | Parameter can be derived from existing state | Refactoring APIs |
| [ ] | **Replace Query with Parameter** | Pass a value explicitly instead of obtaining it through a query. | Hidden dependency on global or object state | Refactoring APIs |
| [ ] | **Return Modified Value** | Return a changed value instead of modifying an input variable or parameter in place. | Mutated parameter; unclear data flow | Refactoring APIs |
| [ ] | **Separate Query from Modifier** | Separate a function that returns information from one that changes state. | Function both queries and mutates | Refactoring APIs |
| [ ] | **Collapse Hierarchy** | Remove a subclass or superclass when the inheritance relationship is no longer useful. | Nearly identical parent and child classes | Dealing with Inheritance |
| [ ] | **Extract Superclass** | Move common functionality from several classes into a superclass. | Duplicate functionality across subclasses | Dealing with Inheritance |
| [ ] | **Pull Up Constructor Body** | Move common constructor initialization into the superclass. | Duplicate constructor logic in subclasses | Dealing with Inheritance |
| [ ] | **Pull Up Field** | Move a common field from subclasses into their superclass. | Same field declared in multiple subclasses | Dealing with Inheritance |
| [ ] | **Pull Up Method** | Move identical or sufficiently similar methods into a superclass. | Duplicate methods in subclasses | Dealing with Inheritance |
| [ ] | **Push Down Field** | Move a field from a superclass into the subclass that actually needs it. | Field used by only one subclass | Dealing with Inheritance |
| [ ] | **Push Down Method** | Move a method from a superclass into the subclass that needs it. | Method relevant to only one subclass | Dealing with Inheritance |
| [ ] | **Remove Subclass** | Replace a subclass that only represents a variation with another representation. | Subclass adds little or no behavior | Dealing with Inheritance |
| [ ] | **Replace Subclass with Delegate** | Replace inheritance-based variation with composition and delegation. | Inheritance used mainly for variation | Dealing with Inheritance |
| [ ] | **Replace Superclass with Delegate** | Replace inheritance with an explicit delegate when the superclass relationship is inappropriate. | Misleading inheritance; unwanted inherited behavior | Dealing with Inheritance |
| [ ] | **Replace Type Code with Subclasses** | Represent distinct type cases with subclasses. | Type field controlling substantial behavior | Dealing with Inheritance |

**Total: 63 refactorings**

**Links:**
- [Refactoring Catalog (Martin Fowler)](https://refactoring.com/catalog/)
- [Refactoring Book (Martin Fowler)](https://martinfowler.com/books/refactoring.html)
- [Refactoring.guru (Website)](https://refactoring.guru/refactoring/catalog)