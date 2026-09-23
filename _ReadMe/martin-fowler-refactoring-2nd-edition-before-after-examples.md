# Martin Fowler — Refactoring 2nd Edition (Before/After Examples)

This file provides concise C# before/after examples for all refactorings listed in `_ReadMe/martin-fowler-refactoring-2nd-edition-checklist.md`.

## 1) Change Function Declaration
- Before: `decimal Price(Order o, bool includeTax) => includeTax ? o.Subtotal * 1.2m : o.Subtotal;`
- After: `decimal CalculatePrice(Order o, TaxMode taxMode) => taxMode == TaxMode.Include ? o.Subtotal * 1.2m : o.Subtotal;`

## 2) Change Reference to Value
- Before: `customerA.Address = sharedAddress; customerB.Address = sharedAddress;`
- After: `customerA.Address = new Address("Berlin"); customerB.Address = new Address("Berlin"); // immutable value`

## 3) Change Value to Reference
- Before: `var usd1 = new Currency("USD"); var usd2 = new Currency("USD");`
- After: `var usd1 = CurrencyCatalog.Get("USD"); var usd2 = CurrencyCatalog.Get("USD");`

## 4) Collapse Hierarchy
- Before: `class SalariedEmployee : Employee { }`
- After: `// SalariedEmployee removed; use Employee directly`

## 5) Combine Functions into Class
- Before: `decimal BaseCharge(Reading r)=>r.Qty*r.Rate; decimal Taxable(Reading r)=>Math.Max(0, BaseCharge(r)-100);`
- After: `class Reading { decimal BaseCharge()=>Qty*Rate; decimal Taxable()=>Math.Max(0, BaseCharge()-100); }`

## 6) Combine Functions into Transform
- Before: `var baseCharge = Base(r); var tax = Tax(baseCharge);`
- After: `var result = Enrich(r); // result.BaseCharge, result.Tax`

## 7) Consolidate Conditional Expression
- Before: `if (isSenior) return 0.1m; if (isVip) return 0.1m;`
- After: `if (isSenior || isVip) return 0.1m;`

## 8) Decompose Conditional
- Before: `if (date < summerStart || date > summerEnd) charge = qty*winterRate; else charge = qty*summerRate;`
- After: `charge = IsSummer(date) ? SummerCharge(qty) : WinterCharge(qty);`

## 9) Encapsulate Collection
- Before: `public List<Order> Orders { get; set; }`
- After: `public IReadOnlyList<Order> Orders => _orders; public void AddOrder(Order o)=>_orders.Add(o);`

## 10) Encapsulate Record
- Before: `public class Person { public string Name; public int Age; }`
- After: `public class Person { public string Name { get; } public int Age { get; private set; } }`

## 11) Encapsulate Variable
- Before: `public static decimal DiscountRate;`
- After: `private static decimal _discountRate; public static decimal DiscountRate => _discountRate;`

## 12) Extract Class
- Before: `class Person { string Name; string OfficeAreaCode; string OfficeNumber; }`
- After: `class Person { string Name; TelephoneNumber Office; }`

## 13) Extract Function
- Before: `var total = amount + amount * 0.2m - discount;`
- After: `var total = CalculateTotal(amount, discount);`

## 14) Extract Superclass
- Before: `class Employee { Name... } class DepartmentHead { Name... }`
- After: `abstract class Party { Name... } class Employee : Party { } class DepartmentHead : Party { }`

## 15) Extract Variable
- Before: `if (order.Total * (1 - order.DiscountRate) > limit) ...`
- After: `var discountedTotal = order.Total * (1 - order.DiscountRate); if (discountedTotal > limit) ...`

## 16) Hide Delegate
- Before: `manager = person.Department.Manager;`
- After: `manager = person.Manager;`

## 17) Inline Class
- Before: `person.TelephoneNumber.AreaCode`
- After: `person.OfficeAreaCode`

## 18) Inline Function
- Before: `bool IsFive() => value == 5; if (IsFive()) ...`
- After: `if (value == 5) ...`

## 19) Inline Variable
- Before: `var basePrice = qty * itemPrice; return basePrice > 1000;`
- After: `return qty * itemPrice > 1000;`

## 20) Introduce Assertion
- Before: `return quantity * unitPrice;`
- After: `Debug.Assert(quantity >= 0); return quantity * unitPrice;`

## 21) Introduce Parameter Object
- Before: `CreateBooking(string customer, DateOnly start, DateOnly end)`
- After: `CreateBooking(BookingPeriod period)`

## 22) Introduce Special Case
- Before: `if (customer == null) return "occupant";`
- After: `return customer.Name; // customer is NullCustomer when missing`

## 23) Move Field
- Before: `class Customer { decimal DiscountRate; } // only Order uses it`
- After: `class Order { decimal DiscountRate; }`

## 24) Move Function
- Before: `Account.OverdraftCharge(daysOverdrawn)`
- After: `AccountType.OverdraftCharge(daysOverdrawn)`

## 25) Move Statements into Function
- Before: `result = Price(o); ApplyRegionalTax(result);`
- After: `result = PriceWithRegionalTax(o);`

## 26) Move Statements to Callers
- Before: `Render() { PrintHeader(); PrintBody(); PrintFooter(); }`
- After: `RenderBody(); // callers decide header/footer`

## 27) Parameterize Function
- Before: `FivePercentRaise(e); TenPercentRaise(e);`
- After: `Raise(e, 0.05m); Raise(e, 0.10m);`

## 28) Preserve Whole Object
- Before: `WithinRange(plan.Low, plan.High)`
- After: `WithinRange(plan)`

## 29) Pull Up Constructor Body
- Before: `class Cat:Animal{ Cat(){ Id = NewId(); }} class Dog:Animal{ Dog(){ Id=NewId(); }}`
- After: `class Animal{ Animal(){ Id=NewId(); }}`

## 30) Pull Up Field
- Before: `class Cat:Animal{ int Legs=4; } class Dog:Animal{ int Legs=4; }`
- After: `class Animal{ int Legs=4; }`

## 31) Pull Up Method
- Before: `Cat.GetName(){...} Dog.GetName(){...}`
- After: `Animal.GetName(){...}`

## 32) Push Down Field
- Before: `class Animal { string WingSpan; } // only Bird uses`
- After: `class Bird : Animal { string WingSpan; }`

## 33) Push Down Method
- Before: `class Animal { Fly(){...} }`
- After: `class Bird : Animal { Fly(){...} }`

## 34) Remove Dead Code
- Before: `if (false) LegacyPath();`
- After: `// LegacyPath removed`

## 35) Remove Flag Argument
- Before: `Book(customer, isPremium: true)`
- After: `BookPremium(customer)`

## 36) Remove Middle Man
- Before: `person.GetDepartmentManager()` forwarding to `person.Department.Manager`
- After: `person.Department.Manager`

## 37) Remove Setting Method
- Before: `order.SetCreatedAt(DateTime.UtcNow);`
- After: `var order = new Order(createdAt: DateTime.UtcNow);`

## 38) Remove Subclass
- Before: `class PreferredCustomer : Customer { }`
- After: `class Customer { CustomerTier Tier; }`

## 39) Rename Field
- Before: `private string nm;`
- After: `private string name;`

## 40) Rename Variable
- Before: `var d = CalculateDiscount();`
- After: `var discount = CalculateDiscount();`

## 41) Replace Command with Function
- Before: `var command = new PriceCommand(order); command.Execute();`
- After: `var price = CalculatePrice(order);`

## 42) Replace Conditional with Polymorphism
- Before: `switch (bird.Type) { case Type.European: ... }`
- After: `bird.GetPlumage(); // each subtype implements its own logic`

## 43) Replace Constructor with Factory Function
- Before: `var employee = new Employee(typeCode);`
- After: `var employee = Employee.Create(typeCode);`

## 44) Replace Derived Variable with Query
- Before: `private decimal _total; // manually updated everywhere`
- After: `public decimal Total => _lines.Sum(l => l.Amount);`

## 45) Replace Function with Command
- Before: `var score = Rank(data);`
- After: `var score = new RankCommand(data).Execute();`

## 46) Replace Inline Code with Function Call
- Before: `var baseCharge = reading.Quantity * reading.MonthlyRate;`
- After: `var baseCharge = BaseCharge(reading);`

## 47) Replace Loop with Pipeline
- Before: `foreach(var o in orders) if(o.IsOpen) result.Add(o.Total);`
- After: `var result = orders.Where(o => o.IsOpen).Select(o => o.Total).ToList();`

## 48) Replace Nested Conditional with Guard Clauses
- Before: `if (!isDead) { if (!isSeparated) { if (!isRetired) return NormalPay(); } }`
- After: `if (isDead) return DeadPay(); if (isSeparated) return SeparatedPay(); if (isRetired) return RetiredPay(); return NormalPay();`

## 49) Replace Parameter with Query
- Before: `decimal DiscountedPrice(Order o, decimal customerDiscount)`
- After: `decimal DiscountedPrice(Order o) => o.Total * (1 - o.Customer.DiscountRate);`

## 50) Replace Primitive with Object
- Before: `decimal amount; string currencyCode;`
- After: `Money amount;`

## 51) Replace Query with Parameter
- Before: `var subtotal = GetCart().Subtotal;`
- After: `var subtotal = CalculateSubtotal(cart);`

## 52) Replace Subclass with Delegate
- Before: `class PremiumBooking : Booking { ... }`
- After: `class Booking { PremiumBehavior? PremiumDelegate; }`

## 53) Replace Superclass with Delegate
- Before: `class ScrollView : BorderedElement { ... }`
- After: `class ScrollView { private readonly Border _border; }`

## 54) Replace Temp with Query
- Before: `var basePrice = Quantity * ItemPrice; if (basePrice > 1000) ...`
- After: `if (BasePrice() > 1000) ...`

## 55) Replace Type Code with Subclasses
- Before: `class Employee { EmployeeType Type; decimal PayAmount(){ if(Type==EmployeeType.Engineer)... } }`
- After: `abstract class Employee { abstract decimal PayAmount(); } class Engineer : Employee { ... }`

## 56) Return Modified Value
- Before: `void ApplyDiscount(ref decimal total) { total *= 0.9m; }`
- After: `decimal ApplyDiscount(decimal total) => total * 0.9m;`

## 57) Separate Query from Modifier
- Before: `int GetAndIncrementCounter()`
- After: `int GetCounter(); void IncrementCounter();`

## 58) Slide Statements
- Before: `var subtotal = CalcSubtotal(); Log(); var tax = CalcTax(subtotal);`
- After: `var subtotal = CalcSubtotal(); var tax = CalcTax(subtotal); Log();`

## 59) Split Loop
- Before: `foreach(var p in people){ if(p.Age>18) adults++; totalAge+=p.Age; }`
- After: `foreach(var p in people) if(p.Age>18) adults++; foreach(var p in people) totalAge+=p.Age;`

## 60) Split Phase
- Before: `Process(string input){ /* parse + calculate + format in one method */ }`
- After: `var command = Parse(input); var result = Calculate(command); return Format(result);`

## 61) Split Variable
- Before: `var temp = input; temp = Normalize(temp); temp = Validate(temp);`
- After: `var normalized = Normalize(input); var validated = Validate(normalized);`
