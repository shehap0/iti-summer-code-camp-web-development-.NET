# ITI Summer Code Camp 2026 – Web development using .NET (suez canal branch, Egypt)

This repository documents my journey through the **ITI Summer Code Camp 2026** in suez canal, Egypt(online). The track covers **C# (.NET)** and **Database (SQL Server)** — with my notes, assignments, lab solutions, and everything I'm learning along the way.

![ITI Summer Code Camp](./iti%20cover.jpg)

## Course Details

| Info | Details |
|------|---------|
| **Location** | Information Technology Institute (ITI), suez canal branch, Egypt |
| **Duration** | July 2026 |
| **total training hours** | +144 |
| **Schedule** | 6 hours/day |

## Curriculum

| Module | Duration |
|--------|--------|
| **Database (SQL Server)** — ERD, Mapping, DDL/DML, Joins, Subqueries, Aggregates | 4 days |
| **C# (.NET)** — Fundamentals, OOP, Inheritance, Polymorphism, Relations, Delegates, LINQ | 9 days |
| **Entity Framework** — Code-First, DbContext, Relationships, Loading | 1 day |
| **MVC** — xxxx | x day |

---

## Database (SQL Server)
> **Note:** Running SQL Server on Linux? Check [installation for linux.md](./installation/SQL%20sever%20installation%20for%20linux.md) — I used Docker/Podman + VS Code SQL Server extension instead of the Windows GUI.
> **Note:** [windows check](./installation/SQL%20Installation%20Guide(windows).pdf)
### Day 1 — ERD Fundamentals
- Entity types, attributes (simple, composite, derived, multi-value), keys
- Strong vs weak entities, relationships, cardinality, participation
- Case study solved together in class
- **Lab:** 3 ER diagram tasks using draw.io (all correct first try)

### Day 2 — Mapping ER to Relational Schema
- Mapping rules for regular/weak entities, 1:1, 1:N, M:N, unary & n-ary relationships
- Handling multivalued, composite, and derived attributes
- **Lab:** Draw relational schemas from ER diagrams

### Day 3 — SQL DDL & DML
- SQL Server data types, CREATE DATABASE/TABLE, ALTER, DROP
- INSERT, UPDATE, DELETE, SELECT with WHERE, LIKE, ORDER BY, DISTINCT, TOP
- **Lab:** Create database from ER diagram, add data, generate visual diagrams; restore backup and write queries

### Day 4 — Advanced SQL
- Joins (INNER, OUTER, CROSS, Self), subqueries
- Aggregate functions (COUNT, SUM, etc.), GROUP BY / HAVING
- GRANT / REVOKE permissions
- **Assignment:** Complex queries on the company database


---

## C# (.NET)
> **Note:** Running dotnet on Linux? Check [installation for linux.md](./installation/Dotnet%20installation.md) 

### Day 1 — Fundamentals
- Bits, bytes, ASCII, SDLC
- Data types (int, decimal, float, char, string), variables
- Binary/unary/compound/comparison/logical operators
- Compiler vs interpreter
- **Tools:** Using VS Code / JetBrains Rider (since Visual Studio isn't on Linux)

### Day 2 — Control Flow
- Loops (for, while, do-while), nested loops
- Conditionals (if, switch)
- Arrays, 2D arrays
- **Structs** — Employee struct with id, name, age, salary

### Day 3 — OOP
- Classes instead of structs
- Access modifiers (private, public)
- Properties (with validation in setters/getters)
- Methods — return vs print, ref parameters, swap function
- Constructors & destructors (GC)

### Day 4 — Object-Oriented Relations
- **Association** — loosely coupled, peer-to-peer (e.g., Teacher ↔ Subject)
- **Aggregation** — whole/part, temporary (e.g., Student ↔ Department)
- **Composition** — tight ownership
- Inheritance, constructor chaining, `protected` access modifier
- **Lab:** Person/Student/Doctor/Professor/House/Room class hierarchy

### Day 5 — Advanced OOP (Polymorphism & Abstract)
- **Abstract classes** — `Geoshape` as an abstract base class (cannot instantiate)
- **Abstract methods** — `CArea()` forcing all shapes to implement their own area calculation
- **Shape hierarchy** — `Geoshape → Rectangle, Circle, Triangle, Square` and `Rectangle → SquareV2`
- **Early (static) binding** — compiler resolves method calls at compile time based on reference type
- **Late (dynamic) binding** — runtime resolves method calls based on object type using `virtual`/`override`
- **Open-Closed Principle** — `SumOfAreasV2(Geoshape[] shapes)` vs `SumOfAreasV1(Rectangle, Square, Triangle)`
- **`sealed` keyword** — prevents further inheritance
- **Lab:** Shape area calculator with static vs dynamic binding demo

### Day 6 — Classes, Properties & Object Initializers
- Value types vs reference types (copy by value vs copy by reference)
- Encapsulation with private fields + public properties
- **Object Initializer** syntax — `new Employee { Id = 1, Name = "Ali" }` (recommended)
- Auto-properties (`public int Age { get; set; }`)
- Property with validation (e.g., Salary range check)
- Overriding `ToString()` for easy printing
- **Lab:** Employee + Student class with various property styles

### Day 7 — Interfaces, Generics & Collections
- **Interfaces** — contracts with method signatures, multiple interface implementation
- **IComparable\<T\>** — custom sorting via `CompareTo()` (sort by Age, Name, HireDate)
- **ICloneable** — deep copy vs shallow copy (rebuilding nested `HireDate`)
- **Object equality** — `==` (identity) vs `.Equals()` (content) vs `ReferenceEquals()`
- **Singleton pattern** — private ctor + private static field + public static factory
- **Generic methods** — `Swap<T>()` passing by value (ref needed for real swap)
- **List\<T\>** — dynamic array, Capacity doubles on overflow, Count vs Capacity
- **Dictionary\<TKey, TValue\>** — key-value lookup, `.Add()` vs indexer semantics
- **`var` keyword** — implicit typing, must be initialized immediately
- **Lab:** Employee array sorted by hire month, Singleton demo, Point equality

### Day 8 — Delegates, Lambdas & Filtering
- **Custom delegates** — `MyDelegate` that returns bool for filtering
- **Evolution of filtering:** hard-coded methods → `FilterByAny` → delegate-based
- **Anonymous methods** & **Lambda expressions** — `e => e.Salary > 5000`
- **Built-in delegates** — `Predicate<T>`, `Action<T>`, `Func<T, TResult>`
- **Nullable value types** — `int?` for database compatibility
- **Lab:** Employee filtering pipeline using delegates and lambdas

---

## LINQ

- **Prerequisites:** `var`, extension methods, anonymous types
- **Fluent syntax** — static methods on `Enumerable` (passing delegates like Predicate)
- **Extension methods** — most common LINQ style
- **Query syntax** — SQL-like expressions (from → where → select)
- **Transformation** — `Select()` to project data
- **Ordering** — `OrderBy()`, `OrderByDescending()`, `ThenBy()`
- **Aggregates** — `Count()`, `Sum()`, `Average()`, `Min()`, `Max()`
- **Set operators** — `Distinct()`, `Union()`, `Intersect()`, `Except()`, `Concat()`
- **Joins** — joining sequences with LINQ
- **Hybrid syntax** — mixing fluent and query styles
- **Lab:** LINQ queries on Student/Subject collections

## Entity Framework (Code-First)
> **Note:** some issue with fix since i used linux that you might face. Check [Entity Framework linux issues.md](./installation/Entity%20Framework%20linux%20issues.md) 

- **Approach:** Code-First only (Model First = dead, Database First = rare)
- **Relationships:** FK property + virtual navigation property + `virtual ICollection<T>`
- **Lazy Loading** — virtual keyword defers loading until accessed
- **Eager Loading** — `.Include()` to load related data upfront
- **Explicit Loading** — runtime load into memory in one request
- **DbContext** — `MyContext : DbContext` with connection string and `DbSet<T>` properties
- **Packages:** `Microsoft.EntityFrameworkCore.SqlServer` + `Microsoft.EntityFrameworkCore.Design` (via NuGet or `dotnet add package`)
- **Lab:** Build data models with relationships and query via LINQ to EF

---

