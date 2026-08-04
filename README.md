# ITI Summer Code Camp 2026 – Web development using .NET (suez canal branch, Egypt)

This repository documents my journey through the **ITI Summer Code Camp 2026** in suez canal, Egypt(online). The track covers **C# (.NET)**, **Database (SQL Server)**, **Entity Framework** and **MVC** — with my notes, assignments, lab solutions, and everything I'm learning along the way.

![ITI Summer Code Camp](./iti%20cover.jpg)

## Course Details

| Info | Details |
|------|---------|
| **Location** | Information Technology Institute (ITI), suez canal branch, Egypt |
| **Duration** | July 2026 |
| **total training hours** | +144 |

## Curriculum

| Module | Duration |
|--------|--------|
| **Database (SQL Server)** — ERD, Mapping, DDL/DML, Joins, Subqueries, Aggregates | 4 days |
| **C# (.NET)** — Fundamentals, OOP, Inheritance, Polymorphism, Relations, Delegates, LINQ | 9 days |
| **Entity Framework** — Code-First, DbContext, Relationships, Loading, Migrations, Database-First | 2 days |
| **MVC** — Controllers, Views, ViewModels, Validation, Tag Helpers, EF Core Integration, File Upload | 5 days |

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

### Day 1 — Code-First, Lazy Loading, Eager Loading

- **Approach:** Code-First only (Model First = dead, Database First = rare)
- **Relationships:** FK property + virtual navigation property + `virtual ICollection<T>`
- **Lazy Loading** — virtual keyword defers loading until accessed
- **Eager Loading** — `.Include()` to load related data upfront
- **Explicit Loading** — runtime load into memory in one request
- **DbContext** — `MyContext : DbContext` with connection string and `DbSet<T>` properties
- **Packages:** `Microsoft.EntityFrameworkCore.SqlServer` + `Microsoft.EntityFrameworkCore.Design` (via NuGet or `dotnet add package`)
- **Lab:** Build data models with relationships and query via LINQ to EF

### Day 2 — Relationships, Migrations, Annotations & Database-First
- **Ways to model entities** — conventions, data annotations, Fluent API, external configuration classes (`IEntityTypeConfiguration<T>`)
- **Data Annotations showcase** — `[Table]`, `[Key]`, `[Required]`, `[StringLength]`, `[NotMapped]`, `[ForeignKey]`, `[InverseProperty]`, `[PrimaryKey]`, `[DatabaseGenerated]`
- **Migrations strategy** — `dotnet ef migrations add` evolving the schema without dropping data (6 versioned migrations: O2M → M2M → explicit composite keys → 1:1)
- **Relationships in depth** — one-to-many, many-to-many (auto & explicit join tables), one-to-one, self-referencing (e.g., Employee → Manager)
- **Database-First** — reverse-engineer an existing DB with `dotnet ef dbcontext scaffold` (see [database first.md](./Entity%20Framework/Day%202/database%20first.md))
- **Labs:** Transform 2 ERDs to code-first (Music, Real-Estate) + scaffold the Company database


## MVC (ASP.NET Core)

### Day 1 — MVC Basics
- Request pipeline: `AddControllersWithViews()`, `UseRouting()`, `MapDefaultControllerRoute()`, default route `{controller=Home}/{action=Index}/{id?}`
- Controllers, actions, and return types (`ContentResult`, `JsonResult`, `ViewResult`, `IActionResult`)
- Simple models passed from controllers to views (static in-memory lists)
- Scaffolding: `_Layout.cshtml` (Bootstrap), `_ViewImports.cshtml` (tag helpers), `_ViewStart.cshtml`

### Day 2 — ViewData/ViewBag, ViewModels & CRUD
- Passing data via **ViewData** / **ViewBag** + a `Constants.cs` helper for magic-string keys
- **ViewModels** to decouple the entity shape from what the view renders
- Full **CRUD** lifecycle: `GetAll`, `GetById`, Create/Edit/Delete with `RedirectToAction`
- Manual model binding via `name="..."` form attributes (pre–tag helper stage)
- Strongly typed views with `@model`

### Day 3 — First EF Core Integration
- Real database via `MyDbContext` with `OnConfiguring` + seeding
- Fluent API external configuration (`IEntityTypeConfiguration<T>`) and a real FK relationship + migration
- **V1 vs V2 refactor** — raw entities + `ViewBag` dropdown vs ViewModels + `SelectListItem`
- `Helper.GetDeptsDropDown()` to build and reuse dropdown items

### Day 4 — Validation & Tag Helpers
- **DataAnnotations validation** — `[Required]`, `[Range]`, `[EmailAddress]`, `[Compare]`, `[DisplayName]`
- **Custom validation attributes** — `MinAgeAttribute` (DateOnly DOB), `NotFutureDateAttribute`
- Standard CRUD pattern: `[HttpGet]`/`[HttpPost]` pairs + `ModelState.IsValid` + `[ValidateAntiForgeryToken]`
- **Tag Helpers** — `asp-action`, `asp-controller`, `asp-for`, `asp-validation-for` vs legacy HTML Helpers

### Day 5 — File Upload, Layouts, Partials & Routing
- **File upload** — `IFormFile`, `enctype="multipart/form-data"`, saving image URLs to the DB
- **Layouts & sections** — `RenderSection` / `RenderSectionAsync("Scripts")`, switching layouts per-view/area via `_ViewStart`
- **Partial views** — `<partial>` tag helper, `@Html.Partial`, `RenderPartialAsync`, reusable detail partials
- **Routing constraints** — `[Route]`, `[HttpGet("{id:int}")]`, `{name:alpha}` overloads

### Project — "Shoply" e-commerce app ([MVC/project](./MVC/project))
> Capstone applying every MVC + EF Core concept: storefront + admin portal, net10.0, EF Core with DI (`AddDbContext` + `appsettings.json`), `Database.EnsureCreated()` at startup.

- **Storefront** — `HomeController`: featured products, category filtering + search, product details with related items; dark/light theme toggle persisted in `localStorage`
- **Admin portal** — `ProductController` / `CategoryController` async CRUD with image upload/removal, `TempData` flash messages, duplicate-name checks, delete blocking while related data exists
- **Services** — `ImageHandler` validating extensions (.jpg/.jpeg/.png/.webp/.gif) and 5 MB size cap, saving to `wwwroot/images/products/`
- **ViewModels** — validated forms with `IFormFile`, `SelectList` dropdowns, details/index VMs
- **Layouts & partials** — `_Layout` (storefront) vs `_PortalLayout` (admin sidebar), `_ProductCard`, `_ProductForm`, `_FlashMessage`, `_ThemeToggle`, `asp-append-version` cache busting

---

