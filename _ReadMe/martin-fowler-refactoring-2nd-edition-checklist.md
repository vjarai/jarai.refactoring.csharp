# Martin Fowler — Refactoring 2nd Edition Checklist

**Source:** *Refactoring: Improving the Design of Existing Code*, 2nd Edition, Martin Fowler with Kent Beck, 2018.

| Done | Refactoring | Purpose / When to Use | Typical Code Smell / Signal |
|:---:|---|---|---|
| [ ] | **Change Function Declaration** | Change a function's name, parameters, or signature to better express its purpose. | Poorly named function; awkward or outdated parameters |
| [ ] | **Change Reference to Value** | Turn an object that should behave like a value into a value object. | Shared object where identity is not important |
| [ ] | **Change Value to Reference** | Make multiple copies of logically identical data refer to one shared object. | Duplicate objects representing the same entity |
| [ ] | **Collapse Hierarchy** | Remove a subclass or superclass when the inheritance relationship is no longer useful. | Nearly identical parent and child classes |
| [ ] | **Combine Functions into Class** | Group functions that operate on the same data into a class. | Related functions scattered across modules |
| [ ] | **Combine Functions into Transform** | Combine related calculations into one transformation of data. | Multiple functions repeatedly transforming the same data |
| [ ] | **Consolidate Conditional Expression** | Combine several conditional expressions that lead to the same result. | Repeated or logically equivalent conditions |
| [ ] | **Decompose Conditional** | Extract complex condition, then-branch, and else-branch logic into named functions. | Complex `if/else` logic |
| [ ] | **Encapsulate Collection** | Prevent direct manipulation of an object's internal collection. | Collection exposed directly to callers |
| [ ] | **Encapsulate Record** | Replace a freely accessible record with an object that controls access to its data. | Public record/object with uncontrolled fields |
| [ ] | **Encapsulate Variable** | Control access to a variable through functions or accessors. | Global or widely accessed mutable variable |
| [ ] | **Extract Class** | Move part of a class's responsibilities into a new class. | Large class; multiple unrelated responsibilities |
| [ ] | **Extract Function** | Move a coherent piece of code into a named function. | Long function; repeated or difficult-to-understand code |
| [ ] | **Extract Superclass** | Move common functionality from several classes into a superclass. | Duplicate functionality across subclasses |
| [ ] | **Extract Variable** | Give a complex expression a meaningful name. | Complicated expression repeated or hard to understand |
| [ ] | **Hide Delegate** | Hide an object's collaborator from callers by providing an appropriate interface. | Clients navigating through object chains |
| [ ] | **Inline Class** | Move a class's functionality into another class when the class no longer has enough responsibility. | Tiny or redundant class |
| [ ] | **Inline Function** | Replace a function call with the function's body. | Function adds little or no useful abstraction |
| [ ] | **Inline Variable** | Replace a variable with the expression it represents. | Variable adds no clarity |
| [ ] | **Introduce Assertion** | Explicitly state assumptions that should always be true. | Implicit assumptions or undocumented invariants |
| [ ] | **Introduce Parameter Object** | Group related parameters into a single object. | Long parameter list; recurring group of parameters |
| [ ] | **Introduce Special Case** | Represent a special or missing case with a dedicated object instead of repeated conditionals. | Repeated null/special-case checks |
| [ ] | **Move Field** | Move a field to the class that uses or owns it more appropriately. | Field used primarily by another class |
| [ ] | **Move Function** | Move a function to the module or class where it logically belongs. | Function depends more on another module's data |
| [ ] | **Move Statements into Function** | Move repeated setup or follow-up code into the function that conceptually owns it. | Repeated code around every function call |
| [ ] | **Move Statements to Callers** | Move caller-specific statements out of a function. | Function contains behavior needed by only some callers |
| [ ] | **Parameterize Function** | Combine similar functions by replacing differing values with parameters. | Several nearly identical functions |
| [ ] | **Preserve Whole Object** | Pass an entire object instead of extracting and passing several individual values. | Multiple parameters originate from the same object |
| [ ] | **Pull Up Constructor Body** | Move common constructor initialization into the superclass. | Duplicate constructor logic in subclasses |
| [ ] | **Pull Up Field** | Move a common field from subclasses into their superclass. | Same field declared in multiple subclasses |
| [ ] | **Pull Up Method** | Move identical or sufficiently similar methods into a superclass. | Duplicate methods in subclasses |
| [ ] | **Push Down Field** | Move a field from a superclass into the subclass that actually needs it. | Field used by only one subclass |
| [ ] | **Push Down Method** | Move a method from a superclass into the subclass that needs it. | Method relevant to only one subclass |
| [ ] | **Remove Dead Code** | Delete code that is no longer executed or needed. | Unreachable, unused, or obsolete code |
| [ ] | **Remove Flag Argument** | Replace a boolean or flag parameter with more explicit functions. | Function behavior controlled by a flag |
| [ ] | **Remove Middle Man** | Remove unnecessary delegation and let clients access the relevant object directly. | Excessive forwarding methods |
| [ ] | **Remove Setting Method** | Remove a setter when a field should not be changed after initialization. | Unnecessary mutable state |
| [ ] | **Remove Subclass** | Replace a subclass that only represents a variation with another representation. | Subclass adds little or no behavior |
| [ ] | **Rename Field** | Give a field a clearer and more accurate name. | Ambiguous, misleading, or outdated field name |
| [ ] | **Rename Variable** | Give a variable a clearer and more meaningful name. | Short, misleading, or ambiguous variable name |
| [ ] | **Replace Command with Function** | Replace a command object with a simpler function when the object provides no useful state. | Command class with little independent state |
| [ ] | **Replace Conditional with Polymorphism** | Move conditional behavior into polymorphic implementations. | Large type-based `switch`/`if` logic |
| [ ] | **Replace Constructor with Factory Function** | Use a factory function when object creation needs flexibility or clearer semantics. | Complex construction logic; varying object types |
| [ ] | **Replace Derived Variable with Query** | Calculate a value when needed instead of storing derived state. | Stored value can become inconsistent with source data |
| [ ] | **Replace Function with Command** | Turn a function into an object when explicit state or decomposition of the operation is useful. | Function with complex internal state |
| [ ] | **Replace Inline Code with Function Call** | Replace duplicated inline logic with a call to an existing function. | Inline implementation duplicates named function |
| [ ] | **Replace Loop with Pipeline** | Express collection processing as a sequence of transformations. | Complex loop performing filter/map/reduce operations |
| [ ] | **Replace Nested Conditional with Guard Clauses** | Handle exceptional or special cases early and keep the main path simple. | Deeply nested conditional logic |
| [ ] | **Replace Parameter with Query** | Let a function obtain a value itself instead of receiving it as a parameter. | Parameter can be derived from existing state |
| [ ] | **Replace Primitive with Object** | Replace a primitive value with an object that represents the domain concept. | Primitive obsession; repeated validation/behavior |
| [ ] | **Replace Query with Parameter** | Pass a value explicitly instead of obtaining it through a query. | Hidden dependency on global or object state |
| [ ] | **Replace Subclass with Delegate** | Replace inheritance-based variation with composition and delegation. | Inheritance used mainly for variation |
| [ ] | **Replace Superclass with Delegate** | Replace inheritance with an explicit delegate when the superclass relationship is inappropriate. | Misleading inheritance; unwanted inherited behavior |
| [ ] | **Replace Temp with Query** | Replace a temporary calculation with a function that performs the calculation. | Complex temporary variable |
| [ ] | **Replace Type Code with Subclasses** | Represent distinct type cases with subclasses. | Type field controlling substantial behavior |
| [ ] | **Return Modified Value** | Return a changed value instead of modifying an input variable or parameter in place. | Mutated parameter; unclear data flow |
| [ ] | **Separate Query from Modifier** | Separate a function that returns information from one that changes state. | Function both queries and mutates |
| [ ] | **Slide Statements** | Move related statements together to improve locality and prepare for further refactoring. | Related code separated by unrelated statements |
| [ ] | **Split Loop** | Separate a loop that performs multiple unrelated tasks into separate loops. | Loop with multiple responsibilities |
| [ ] | **Split Phase** | Separate code into distinct phases with a clear data flow between them. | Function mixing parsing, transformation, and processing |
| [ ] | **Split Variable** | Use separate variables when one variable is reused for different purposes. | Variable assigned repeatedly for different meanings |

**Total: 63 refactorings**

**Links:**
- [Refactoring Catalog (Martin Fowler)](https://refactoring.com/catalog/)
- [Refactoring Book (Martin Fowler)](https://martinfowler.com/books/refactoring.html)
- [Refactoring.guru (Website)](https://refactoring.guru/refactoring/catalog)