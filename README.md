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
| **C# (.NET)** — Fundamentals, OOP, Inheritance, Polymorphism, Relations | 5 days |

---

## Database (SQL Server)

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

> **Note:** Running SQL Server on Linux? Check [installation for linux.md](./installation/SQL%20sever%20installation%20for%20linux.md) — I used Docker/Podman + VS Code SQL Server extension instead of the Windows GUI.
> **Note:** [windows check](./installation/SQL%20Installation%20Guide(windows).pdf)

---

## C# (.NET)

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

> **Note:** Running dotnet on Linux? Check [installation for linux.md](./installation/Dotnet%20installation.md) 
---

