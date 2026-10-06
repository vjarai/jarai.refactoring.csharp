# Martin Fowler — Refactoring Catalog (Before/After Examples)

This file provides concise C# before/after examples for all refactorings 

## 1) Combine Functions into Class
- Before: `decimal BaseCharge(Reading r)=>r.Qty*r.Rate; decimal Taxable(Reading r)=>Math.Max(0, BaseCharge(r)-100);`
- After: `class Reading { decimal BaseCharge()=>Qty*Rate; decimal Taxable()=>Math.Max(0, BaseCharge()-100); }`

## 2) Combine Functions into Transform
- Before: `var baseCharge = Base(r); var tax = Tax(baseCharge);`
- After: `var result = Enrich(r); // result.BaseCharge, result.Tax`

## 3) Encapsulate Variable
- Before: `public static decimal DiscountRate;`
- After: `private static decimal _discountRate; public static decimal DiscountRate => _discountRate;`

## 4) Extract Function
- Before: `var total = amount + amount * 0.2m - discount;`
- After: `var total = CalculateTotal(amount, discount);`

## 5) Extract Variable
- Before: `if (order.Total * (1 - order.DiscountRate) > limit) ...`
- After: `var discountedTotal = order.Total * (1 - order.DiscountRate); if (discountedTotal > limit) ...`

## 6) Inline Function
- Before: `bool IsFive() => value == 5; if (IsFive()) ...`
- After: `if (value == 5) ...`

## 7) Inline Variable
- Before: `var basePrice = qty * itemPrice; return basePrice > 1000;`
- After: `return qty * itemPrice > 1000;`

## 8) Introduce Parameter Object
- Before: `CreateBooking(string customer, DateOnly start, DateOnly end)`
- After: `CreateBooking(BookingPeriod period)`

## 9) Remove Dead Code
- Before: `if (false) LegacyPath();`
- After: `// LegacyPath removed`

## 10) Rename Variable
- Before: `var d = CalculateDiscount();`
- After: `var discount = CalculateDiscount();`

## 11) Replace Loop with Pipeline
- Before: `foreach(var o in orders) if(o.IsOpen) result.Add(o.Total);`
- After: `var result = orders.Where(o => o.IsOpen).Select(o => o.Total).ToList();`

## 12) Split Phase
- Before: `Process(string input){ /* parse + calculate + format in one method */ }`
- After: `var command = Parse(input); var result = Calculate(command); return Format(result);`

## 13) Encapsulate Collection
- Before: `public List<Order> Orders { get; set; }`
- After: `public IReadOnlyList<Order> Orders => _orders; public void AddOrder(Order o)=>_orders.Add(o);`

## 14) Encapsulate Record
- Before: `public class Person { public string Name; public int Age; }`
- After: `public class Person { public string Name { get; } public int Age { get; private set; } }`

## 15) Replace Primitive with Object
- Before: `decimal amount; string currencyCode;`
- After: `Money amount;`

## 16) Replace Temp with Query
- Before: `var basePrice = Quantity * ItemPrice; if (basePrice > 1000) ...`
- After: `if (BasePrice() > 1000) ...`

## 17) Extract Class
- Before: `class Person { string Name; string OfficeAreaCode; string OfficeNumber; }`
- After: `class Person { string Name; TelephoneNumber Office; }`

## 18) Inline Class
- Before: `person.TelephoneNumber.AreaCode`
- After: `person.OfficeAreaCode`

## 19) Move Field
- Before: `class Customer { decimal DiscountRate; } // only Order uses it`
- After: `class Order { decimal DiscountRate; }`

## 20) Move Function
- Before: `Account.OverdraftCharge(daysOverdrawn)`
- After: `AccountType.OverdraftCharge(daysOverdrawn)`

## 21) Move Statements into Function
- Before: `result = Price(o); ApplyRegionalTax(result);`
- After: `result = PriceWithRegionalTax(o);`

## 22) Move Statements to Callers
- Before: `Render() { PrintHeader(); PrintBody(); PrintFooter(); }`
- After: `RenderBody(); // callers decide header/footer`

## 23) Replace Inline Code with Function Call
- Before: `var baseCharge = reading.Quantity * reading.MonthlyRate;`
- After: `var baseCharge = BaseCharge(reading);`

## 24) Slide Statements
- Before: `var subtotal = CalcSubtotal(); Log(); var tax = CalcTax(subtotal);`
- After: `var subtotal = CalcSubtotal(); var tax = CalcTax(subtotal); Log();`

## 25) Split Loop
- Before: `foreach(var p in people){ if(p.Age>18) adults++; totalAge+=p.Age; }`
- After: `foreach(var p in people) if(p.Age>18) adults++; foreach(var p in people) totalAge+=p.Age;`

## 26) Change Reference to Value
- Before: `customerA.Address = sharedAddress; customerB.Address = sharedAddress;`
- After: `customerA.Address = new Address("Berlin"); customerB.Address = new Address("Berlin"); // immutable value`

## 27) Change Value to Reference
- Before: `var usd1 = new Currency("USD"); var usd2 = new Currency("USD");`
- After: `var usd1 = CurrencyCatalog.Get("USD"); var usd2 = CurrencyCatalog.Get("USD");`

## 28) Rename Field
- Before: `private string nm;`
- After: `private string name;`

## 29) Replace Derived Variable with Query
- Before: `private decimal _total; // manually updated everywhere`
- After: `public decimal Total => _lines.Sum(l => l.Amount);`

## 30) Split Variable
- Before: `var temp = input; temp = Normalize(temp); temp = Validate(temp);`
- After: `var normalized = Normalize(input); var validated = Validate(normalized);`

## 31) Consolidate Conditional Expression
- Before: `if (isSenior) return 0.1m; if (isVip) return 0.1m;`
- After: `if (isSenior || isVip) return 0.1m;`

## 32) Decompose Conditional
- Before: `if (date < summerStart || date > summerEnd) charge = qty*winterRate; else charge = qty*summerRate;`
- After: `charge = IsSummer(date) ? SummerCharge(qty) : WinterCharge(qty);`

## 33) Introduce Assertion
- Before: `return quantity * unitPrice;`
- After: `Debug.Assert(quantity >= 0); return quantity * unitPrice;`

## 34) Introduce Special Case
- Before: `if (customer == null) return "occupant";`
- After: `return customer.Name; // customer is NullCustomer when missing`

## 35) Replace Conditional with Polymorphism
- Before: `switch (bird.Type) { case Type.European: ... }`
- After: `bird.GetPlumage(); // each subtype implements its own logic`

## 36) Replace Nested Conditional with Guard Clauses
- Before: `if (!isDead) { if (!isSeparated) { if (!isRetired) return NormalPay(); } }`
- After: `if (isDead) return DeadPay(); if (isSeparated) return SeparatedPay(); if (isRetired) return RetiredPay(); return NormalPay();`

## 37) Change Function Declaration
- Before: `decimal Price(Order o, bool includeTax) => includeTax ? o.Subtotal * 1.2m : o.Subtotal;`
- After: `decimal CalculatePrice(Order o, TaxMode taxMode) => taxMode == TaxMode.Include ? o.Subtotal * 1.2m : o.Subtotal;`

## 38) Hide Delegate
- Before: `manager = person.Department.Manager;`
- After: `manager = person.Manager;`

## 39) Parameterize Function
- Before: `FivePercentRaise(e); TenPercentRaise(e);`
- After: `Raise(e, 0.05m); Raise(e, 0.10m);`

## 40) Preserve Whole Object
- Before: `WithinRange(plan.Low, plan.High)`
- After: `WithinRange(plan)`

## 41) Remove Flag Argument
- Before: `Book(customer, isPremium: true)`
- After: `BookPremium(customer)`

## 42) Remove Middle Man
- Before: `person.GetDepartmentManager()` forwarding to `person.Department.Manager`
- After: `person.Department.Manager`

## 43) Remove Setting Method
- Before: `order.SetCreatedAt(DateTime.UtcNow);`
- After: `var order = new Order(createdAt: DateTime.UtcNow);`

## 44) Replace Command with Function
- Before: `var command = new PriceCommand(order); command.Execute();`
- After: `var price = CalculatePrice(order);`

## 45) Replace Constructor with Factory Function
- Before: `var employee = new Employee(typeCode);`
- After: `var employee = Employee.Create(typeCode);`

## 46) Replace Function with Command
- Before: `var score = Rank(data);`
- After: `var score = new RankCommand(data).Execute();`

## 47) Replace Parameter with Query
- Before: `decimal DiscountedPrice(Order o, decimal customerDiscount)`
- After: `decimal DiscountedPrice(Order o) => o.Total * (1 - o.Customer.DiscountRate);`

## 48) Replace Query with Parameter
- Before: `var subtotal = GetCart().Subtotal;`
- After: `var subtotal = CalculateSubtotal(cart);`

## 49) Return Modified Value
- Before: `void ApplyDiscount(ref decimal total) { total *= 0.9m; }`
- After: `decimal ApplyDiscount(decimal total) => total * 0.9m;`

## 50) Separate Query from Modifier
- Before: `int GetAndIncrementCounter()`
- After: `int GetCounter(); void IncrementCounter();`

## 51) Collapse Hierarchy
- Before: `class SalariedEmployee : Employee { }`
- After: `// SalariedEmployee removed; use Employee directly`

## 52) Extract Superclass
- Before: `class Employee { Name... } class DepartmentHead { Name... }`
- After: `abstract class Party { Name... } class Employee : Party { } class DepartmentHead : Party { }`

## 53) Pull Up Constructor Body
- Before: `class Cat:Animal{ Cat(){ Id = NewId(); }} class Dog:Animal{ Dog(){ Id=NewId(); }}`
- After: `class Animal{ Animal(){ Id=NewId(); }}`

## 54) Pull Up Field
- Before: `class Cat:Animal{ int Legs=4; } class Dog:Animal{ int Legs=4; }`
- After: `class Animal{ int Legs=4; }`

## 55) Pull Up Method
- Before: `Cat.GetName(){...} Dog.GetName(){...}`
- After: `Animal.GetName(){...}`

## 56) Push Down Field
- Before: `class Animal { string WingSpan; } // only Bird uses`
- After: `class Bird : Animal { string WingSpan; }`

## 57) Push Down Method
- Before: `class Animal { Fly(){...} }`
- After: `class Bird : Animal { Fly(){...} }`

## 58) Remove Subclass
- Before: `class PreferredCustomer : Customer { }`
- After: `class Customer { CustomerTier Tier; }`

## 59) Replace Subclass with Delegate
- Before: `class PremiumBooking : Booking { ... }`
- After: `class Booking { PremiumBehavior? PremiumDelegate; }`

## 60) Replace Superclass with Delegate
- Before: `class ScrollView : BorderedElement { ... }`
- After: `class ScrollView { private readonly Border _border; }`

## 61) Replace Type Code with Subclasses
- Before: `class Employee { EmployeeType Type; decimal PayAmount(){ if(Type==EmployeeType.Engineer)... } }`
- After: `abstract class Employee { abstract decimal PayAmount(); } class Engineer : Employee { ... }`
