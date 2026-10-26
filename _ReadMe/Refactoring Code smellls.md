# Code Smells und passende Refactorings nach Martin Fowler

Die Übersicht orientiert sich an Martin Fowlers *Refactoring*, **2. Auflage**. Die englischen Originalnamen erleichtern das Nachschlagen. Die Zuordnungen sind typische Ansatzpunkte, keine starren Regeln. Die ausgewählten Smells stammen aus Kapitel 3; die Refactoringnamen entsprechen Fowlers Katalog.

| Bad Smell | Woran erkennbar? | Passende Refactorings | Ziel |
|---|---|---|---|
| **Mysterious Name** – unklarer Name | Namen verschleiern Zweck oder Bedeutung. | Rename Variable; Change Function Declaration | Absicht verständlich machen |
| **Duplicated Code** – duplizierter Code | Dieselbe Logik steht an mehreren Stellen. | Extract Function; Pull Up Method | Gemeinsame Logik zentralisieren |
| **Long Function** – lange Funktion | Eine Funktion vermischt viele Arbeitsschritte und Abstraktionsebenen. | Extract Function; Replace Temp with Query | Verständliche Teilaufgaben bilden |
| **Long Parameter List** – lange Parameterliste | Viele Argumente, häufig gemeinsam übergebene Werte oder Steuerungsflags. | Introduce Parameter Object; Preserve Whole Object; Remove Flag Argument | Schnittstelle vereinfachen |
| **Global Data** – globale Daten | Viele Programmteile können auf denselben Zustand zugreifen und ihn verändern. | Encapsulate Variable | Zugriff und Änderungen kontrollieren |
| **Mutable Data** – veränderliche Daten | Zustandsänderungen erzeugen schwer nachvollziehbare Wechselwirkungen. | Separate Query from Modifier; Remove Setting Method | Änderungen begrenzen und sichtbar machen |
| **Divergent Change** – unterschiedliche Änderungsgründe | Ein Modul muss wegen verschiedener fachlicher Anliegen geändert werden. | Extract Class; Split Phase | Verantwortlichkeiten trennen |
| **Shotgun Surgery** – verstreute Änderungen | Eine fachliche Änderung erfordert kleine Anpassungen in vielen Modulen. | Move Function; Move Field | Zusammengehörige Verantwortung bündeln |
| **Feature Envy** – Interesse an fremden Daten | Eine Funktion arbeitet überwiegend mit Daten eines anderen Moduls. | Move Function; Extract Function | Verhalten näher zu seinen Daten bringen |
| **Data Clumps** – Datengruppen | Dieselben zusammengehörigen Werte treten wiederholt gemeinsam auf. | Introduce Parameter Object; Extract Class | Fachlichen Zusammenhang ausdrücken |
| **Primitive Obsession** – übermäßiger Einsatz primitiver Typen | Fachliche Konzepte wie Geld oder Telefonnummern werden nur als Zahlen oder Strings modelliert. | Replace Primitive with Object | Regeln und Validierung bündeln |
| **Repeated Switches** – wiederholte Fallunterscheidungen | Dieselbe Typunterscheidung taucht an mehreren Stellen auf. | Replace Conditional with Polymorphism | Variantenverhalten zusammenführen |
| **Large Class** – große Klasse | Eine Klasse vereint zu viele Daten und Aufgaben. | Extract Class; Extract Superclass | Kohäsive Verantwortlichkeiten bilden |
| **Message Chains** – Aufrufketten | Zugriffe wie `a.b().c().d()` machen interne Objektstrukturen sichtbar. | Hide Delegate; Extract Function | Abhängigkeit von Objektstrukturen reduzieren |
| **Middle Man** – bloßer Vermittler | Eine Klasse reicht fast alle Aufrufe nur weiter. | Remove Middle Man; Inline Function | Unnötige Indirektion abbauen |
| **Speculative Generality** – vorsorgliche Abstraktion | Erweiterungspunkte und Hierarchien existieren für bislang ungenutzte Möglichkeiten. | Collapse Hierarchy; Inline Class | Auf tatsächlich benötigte Flexibilität reduzieren |
| **Refused Bequest** – abgelehntes Erbe | Eine Unterklasse benötigt oder unterstützt wesentliche Teile der geerbten Schnittstelle nicht. | Replace Superclass with Delegate; Push Down Method | Vererbung passend zuschneiden oder ersetzen |
| **Comments** – erklärungsbedürftiger Code | Kommentare müssen komplizierten Ablauf oder unklare Ausdrücke erklären. | Extract Function; Change Function Declaration; Introduce Assertion | Absicht im Code ausdrücken und Annahmen prüfen |

**Ein Smell ist kein Fehlernachweis.** Fowler betont, dass beispielsweise eine lange Funktion durchaus angemessen sein kann. Auch Kommentare, die fachliche Gründe erklären, sind sinnvoll. Entscheidend ist das zugrunde liegende Verständlichkeits- oder Änderungsproblem.

## Kompakte Beispiele in C#

Die Ausschnitte sind schematisch und zeigen jeweils einen möglichen Ansatz. Typen und Hilfsmethoden werden vorausgesetzt; die Zeilen sind keine vollständigen Programme. Refactorings erfolgen in kleinen Schritten, wobei das beobachtbare Verhalten erhalten bleibt.

| Bad Smell | Vorher (C#) | Nachher (C#) | Refactoring |
|---|---|---|---|
| **Mysterious Name** | `int d = 86400;` | `int secondsPerDay = 86400;` | Rename Variable |
| **Duplicated Code** | Mehrfach: `price * (1m - discount)` | Gemeinsam: `DiscountedPrice(price, discount)` | Extract Function |
| **Long Function** | `Checkout(order)` enthält Validierung, Berechnung und Speicherung. | Im Methodenrumpf: `Validate(order); var total = CalculateTotal(order); Save(order, total);` | Extract Function |
| **Long Parameter List** | `Search(city, zip, street, radius);` | `Search(new SearchArea(city, zip, street, radius));` | Introduce Parameter Object |
| **Global Data** | `public static decimal TaxRate;` | `private static decimal taxRate;` mit `public static decimal TaxRate { get => taxRate; set => taxRate = value; }`; anschließend Zugriffe und Änderungsregeln bündeln. | Encapsulate Variable |
| **Mutable Data** | `decimal GetTotal() { status = Status.Calculated; return CalculateTotal(); }` | `decimal GetTotal() => CalculateTotal();` und `void MarkCalculated() => status = Status.Calculated;`; bisherige Aufrufer führen weiterhin beide Schritte in derselben Reihenfolge aus. | Separate Query from Modifier |
| **Divergent Change** | `Invoice` enthält `CalculateTax()` und das Drucklayout in `Print()`. | `Invoice` behält die Berechnung; `InvoicePrinter.Print(invoice)` übernimmt die Darstellung. | Extract Class |
| **Shotgun Surgery** | Dieselbe Rabattregel wird in `Cart`, `Invoice` und `Checkout` geändert. | Alle verwenden `discountPolicy.Calculate(order)`. | Move Function |
| **Feature Envy** | `decimal Overdraft(Account a) => Math.Max(0m, -a.Balance);` liegt in `Report`. | In `Account`: `public decimal OverdraftAmount() => Math.Max(0m, -Balance);`; der Report ruft diese Methode auf. | Move Function |
| **Data Clumps** | `Load(start, end);` und `Export(start, end);` | `var range = new DateRange(start, end);` und `Load(range); Export(range);` | Introduce Parameter Object |
| **Primitive Obsession** | `string phone;`; dieselben Prüf- und Formatierungsregeln sind verstreut. | `PhoneNumber phone;`; das Objekt bündelt die bisherigen Regeln. | Replace Primitive with Object |
| **Repeated Switches** | An mehreren Stellen: `switch (shippingType)` zur Berechnung der Versandkosten. | `shipping.Cost(order)`; z. B. `StandardShipping` und `ExpressShipping` implementieren `IShipping`. | Replace Conditional with Polymorphism |
| **Large Class** | `Customer` enthält Stammdaten, Bonitätsregeln und Zahlungshistorie. | `Customer` verwendet separate Klassen `CreditProfile` und `PaymentHistory`. | Extract Class |
| **Message Chains** | `employee.Department.Manager.Name` | `employee.ManagerName`; intern delegiert die Property an `Department.Manager.Name`. | Hide Delegate |
| **Middle Man** | `Customer Find(int id) => repository.Find(id);` ist eine reine Weiterleitung ohne zusätzliche Verantwortung. | Der Aufrufer verwendet `repository.Find(id)` direkt. | Remove Middle Man |
| **Speculative Generality** | `BaseFormatter → AbstractFormatter → TextFormatter`; die Zwischenstufen haben keine benötigte eigene Aufgabe. | Benötigte Implementierung in `TextFormatter` zusammenführen. | Collapse Hierarchy |
| **Refused Bequest** | `ReadOnlyItems : MutableItems` überschreibt `Add()` nur mit `throw new NotSupportedException();`. | `ReadOnlyItems` kapselt die Sammlung und bietet z. B. `IReadOnlyList<Item>` an; Aufrufer und Typverträge prüfen und anpassen. | Replace Superclass with Delegate |
| **Comments** | `// Kunde darf bestellen` vor `if (customer.IsActive && !customer.IsBlocked)` | `if (customer.CanPlaceOrder())`; die extrahierte Methode enthält unverändert dieselbe Bedingung. | Extract Function |

**Hinweise:** Das Kapseln globaler Daten beseitigt deren globale Reichweite zunächst nicht. Beim Trennen von Abfragen und Änderungen müssen bestehende Seiteneffekte an den Aufrufstellen erhalten bleiben. Der Wechsel von Vererbung zu Delegation erfordert besondere Prüfung der Typverträge und Aufrufer. Kommentare über fachliche Gründe bleiben sinnvoll.


## Quellen

- Martin Fowler: *Refactoring: Improving the Design of Existing Code*, 2. Auflage, Addison-Wesley, 2018; insbesondere Kapitel 3 „Bad Smells in Code“. [Verlagsseite und Inhaltsverzeichnis](https://www.informit.com/store/refactoring-improving-the-design-of-existing-code-9780134757711)
- Martin Fowler: [Catalog of Refactorings](https://refactoring.com/catalog/)
- Martin Fowler: [Code Smell](https://martinfowler.com/bliki/CodeSmell.html)

