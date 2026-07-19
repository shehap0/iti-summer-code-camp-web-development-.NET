# C# OOP & Generics — Full Study Guide
### Based on: Employee.cs, FTP.cs, HireDate.cs, InterfaceRegion.cs, Point.cs, Program.cs, Utility.cs

**Topics covered:** Interfaces & multiple implementation · IComparable (custom sorting) · ICloneable (deep copy) · Object equality (`==` vs `Equals` vs `ReferenceEquals`) · Singleton pattern · Generic methods · `var` · `List<T>` · `Dictionary<TKey,TValue>`

Let's go. 👇

---

## 1. Interfaces — The Fundamentals

**What it is (in one sentence):**
An interface is a contract that says "any class implementing me MUST provide these members" — it has no implementation of its own.

**The full explanation:**
Your `InterfaceRegion.cs` file defines two interfaces:

```csharp
interface IMyInterface
{
    string Name { get; set; }
    int Age { set; get; }
    void Register();
    void Login();
    void Logout();
}

interface IMyInterface2
{
    void Commission();
    void Deduction();
}
```

Key rules baked into this code:
- An interface can only contain **method headers** (no body — that's why `Register()`, `Login()`, `Logout()` have no `{}` in the interface, only a `;`) and **auto-properties** (`Name`, `Age`).
- You **never write access modifiers** (`public`, `private`) inside an interface. Every member is implicitly `public` because it's meant to be inherited and used publicly.
- You **cannot create an object** directly from an interface — `new IMyInterface()` is illegal. It only exists to be implemented.
- Interfaces are **reference types**, and they must be declared inside a namespace (never nested logic — just headers).

The comment block in `Program.cs` sums up *why* interfaces exist:
> "in c# multi level inheritance is supported only class X:Y,Z{} XXX not Supported — issue: i need to inherit data from multiple resources"

This is the core motivation: **a C# class can only inherit from ONE parent class**, but real-world designs often need a class to "act like" several unrelated things at once (e.g., something that can Login AND handle Commission). Interfaces solve that.

**Key things to remember:**
- 🎯 **Exam Likely** — Interface members have no access modifiers; they're implicitly public.
- 🎯 **Exam Likely** — You cannot instantiate an interface (`new IMyInterface()` = compile error).
- Interfaces can hold only method signatures + auto-property declarations — no fields, no method bodies.
- A class implementing an interface must implement **every single member**, or the class itself must be declared `abstract`.

**Example:**
`Department` (below) implements `IMyInterface`, meaning it is legally *required* to provide working `Name`, `Age`, `Register()`, `Login()`, `Logout()` members, or the code won't compile.

---

## 2. Multiple Interface Implementation + Single Class Inheritance

**What it is (in one sentence):**
A C# class can inherit from **one** class but implement **many** interfaces — this is how C# fakes "multiple inheritance."

**The full explanation:**
```csharp
class ParentDept { }

class Department : ParentDept, IMyInterface, IMyInterface2
{
    public string Name { get; set; }
    public int Age { get; set; }

    public void Commission() { throw new NotImplementedException(); }
    public void Deduction()  { throw new NotImplementedException(); }
    public void Login()      { throw new NotImplementedException(); }
    public void Logout()     { throw new NotImplementedException(); }
    public void Register()   { throw new NotImplementedException(); }
}
```
`Department` inherits from `ParentDept` (its ONE allowed base class) **and** implements both `IMyInterface` and `IMyInterface2` in the same comma-separated list. This is legal precisely because interfaces aren't "real" inheritance of implementation — they're just promises to implement.

Notice every interface method body here is `throw new NotImplementedException();`. That's a common placeholder pattern: it satisfies the compiler's requirement that the member exists, while marking "I haven't written the real logic yet" — if this method actually runs before you fill it in, the program crashes loudly instead of silently doing nothing wrong.

**Key things to remember:**
- 🎯 **Exam Likely** — Syntax order convention: base **class** first, then **interfaces**, all comma-separated: `class Department : ParentDept, IMyInterface, IMyInterface2`.
- A class can implement unlimited interfaces but only ONE base class.
- `NotImplementedException` ≠ a design pattern — it's just a stub/placeholder.

**Example:**
Because `Department` implements `IMyInterface`, this becomes legal:
```csharp
IMyInterface myInterface2 = new Department(); // valid — polymorphism through interface
```
(You can see this exact line commented out in `Program.cs`'s "Interface Example" region.)

---

## 3. IComparable — Making Custom Types Sortable

**What it is (in one sentence):**
`IComparable` is the interface that tells `Array.Sort()` (and similar methods) *how* to order your own custom objects.

**The full explanation:**
Built-in types like `int` and `string` already know how to compare themselves, so `Array.Sort(arr1)` and `Array.Sort(names)` just work. But the compiler has no idea whether one `Employee` should come "before" another `Employee` — Age? Name? Salary? You have to tell it, by implementing `IComparable` and writing the rule yourself inside `CompareTo`.

Two versions appear in your files:

**Non-generic**, in `HireDate.cs`:
```csharp
class HireDate : IComparable
{
    public int CompareTo(object? obj)
    {
        HireDate right = obj as HireDate;
        return this.Year.CompareTo(right.Year);
    }
}
```

**Generic**, in `Employee.cs`:
```csharp
class Employee : IComparable<Employee>, ICloneable
{
    public int CompareTo(Employee? other)
    {
        return this.Age.CompareTo(other.Age);
    }
}
```
`this` refers to the object doing the comparing (the "left" side), `other`/`right` is the object being compared against. `int.CompareTo(int)` returns negative/zero/positive, and that's exactly what your own `CompareTo` must also return — which is why `this.Age.CompareTo(other.Age)` works: you're just *delegating* to `int`'s own built-in comparison logic.

The commented-out block in `Employee.cs` is worth understanding even though it's disabled:
```csharp
// return this.Name.CompareTo(right.Name);
// return this.Age.CompareTo(right.Age);
// return this.HDate.Year.CompareTo(right.HDate.Year);
// return this.HDate.CompareTo(right.HDate);
```
⚠️ **Common Mistake** — Only the **first** `return` in a method ever executes; everything after it is unreachable. This block shows four *alternative* sort keys (by name, by age, by hire year, by full hire date) — you pick exactly one active rule per class, not all four at once.

**Key things to remember:**
- 🎯 **Exam Likely** — `Array.Sort(employees)` only compiles/works if `Employee` implements `IComparable`/`IComparable<T>`.
- Generic `IComparable<T>` is preferred in modern C# — no casting needed, type-safe.
- `CompareTo` return value convention: negative = "I come before", 0 = "equal", positive = "I come after".

**Example:**
```csharp
Employee[] employees = { /* 5 employees with different ages */ };
Array.Sort(employees); // internally calls CompareTo on pairs of elements
```
This sorts strictly by `Age` because that's what `Employee.CompareTo` implements — even though `Name`, `Salary`, `HDate` all exist on the object, none of them affect ordering.

---

## 4. ICloneable — Deep Copy vs Reference Copy

**What it is (in one sentence):**
`ICloneable` lets you create a genuinely independent duplicate of an object instead of just copying a reference to the same object.

**The full explanation:**
For reference types, `Employee e2 = e1;` does **not** create a new employee — `e2` and `e1` are two names pointing at the exact same object in memory. Change one, and you change "both" (because there's really only one).

`Employee.Clone()` solves this:
```csharp
public object Clone()
{
    return new Employee
    {
        Id = this.Id,
        Name = this.Name,
        Age = this.Age,
        Salary = this.Salary,
        HDate = new HireDate { Day = this.HDate.Day, Month = this.HDate.Month, Year = this.HDate.Year },
    };
}
```
This builds a **brand new** `Employee` object with copied-over values. Critically, notice `HDate` is also rebuilt as a **new** `HireDate` — not just reassigned (`HDate = this.HDate`). That second part matters: if you only copied the reference to the *same* `HireDate` object, you'd have a "shallow copy" — changing the clone's hire date would silently also change the original's. Rebuilding `HireDate` from scratch makes this a true **deep copy**.

The commented `Program.cs` code shows the contrast directly:
```csharp
// int[] arr4 = arr1.Clone() as int[];   // built-in Clone() — returns object, needs casting
// Employee e2 = e1.Clone() as Employee; // same idea for your custom class
```

**Key things to remember:**
- 🎯 **Exam Likely** — `Clone()` returns `object` (not `Employee`) because `ICloneable.Clone()` is defined that way — you must cast: `e1.Clone() as Employee`.
- ⚠️ **Common Mistake** — Forgetting to deep-copy nested reference-type fields (like `HDate`) results in a "shallow clone" that still shares state with the original.
- `e1.GetHashCode()` vs `e2.GetHashCode()` will differ after cloning, proving they're separate objects in memory.

**Example:**
```csharp
Employee e1 = new Employee { Id = 2, Name = "Ali", Age = 22, Salary = 4567,
                              HDate = new HireDate { Day = 4, Month = 4, Year = 2004 } };
Employee e2 = e1.Clone() as Employee;
e2.Name = "Changed";
// e1.Name is still "Ali" — because e2 is a totally separate object
```

---

## 5. Object Equality — `==` vs `.Equals()` vs `ReferenceEquals()`

**What it is (in one sentence):**
For reference types, C# gives you three different tools to check "are these the same?" — and by default they all mean the exact same thing (same memory address) until you override one of them.

**The full explanation:**
`Point.cs` overrides the default behavior:
```csharp
public override bool Equals(object? obj)
{
    Point right = obj as Point;
    if (right == null) { return false; }
    if (object.ReferenceEquals(this, right) == true) { return true; }
    return this.X == right.X && this.Y == right.Y;
}
```
Walking through the logic step by step:
1. `obj as Point` — safely tries to convert `obj` to a `Point`. If `obj` isn't actually a `Point` (or is `null`), this returns `null` instead of throwing an exception.
2. If `right` came back `null`, they obviously can't be equal → `return false`.
3. `ReferenceEquals(this, right)` is a shortcut/optimization: if they're literally the same object in memory, we already know they're equal without checking fields.
4. Otherwise, fall back to **content comparison**: are `X` and `Y` the same values?

This is why, in the commented `Program.cs` block, all of these can give *different* answers on the *same* two points:
```csharp
// if (p1 == p4)                        // == : Identity (reference) — UNLESS overloaded
// if (p1.Equals(p3))                   // Equals : content comparison (because we overrode it)
// if (object.Equals(p1, p4))           // static Equals : safely calls .Equals(), handles nulls
// if (object.ReferenceEquals(p1, p4))  // ALWAYS pure identity, ignores overrides entirely
```
Since `Point` did **not** overload the `==` operator (only `Equals`), `p1 == p3` would still check *reference* identity and return false even for two points with identical X/Y — while `p1.Equals(p3)` would return true. This gap is a classic exam trap.

⚠️ **Common Mistake** — `Point` overrides `Equals()` but does **not** override `GetHashCode()`. In real .NET, if you override `Equals`, you are expected to also override `GetHashCode` so that two "equal" objects always produce the same hash code — otherwise `Point` objects will misbehave if you ever put them in a `Dictionary` or `HashSet`.

**Key things to remember:**
- 🎯 **Exam Likely** — `ReferenceEquals` **always** means "same memory address," no matter what overrides exist.
- 🎯 **Exam Likely** — Overriding `Equals()` does NOT automatically change what `==` does — those are separate mechanisms.
- The `as` operator + null-check pattern is the safe way to "downcast" in an `Equals` override.

**Example:**
```csharp
Point p1 = new Point { X = 3, Y = 4 };
Point p3 = new Point { X = 3, Y = 4 };   // different object, same values
Point p4 = p1;                            // same object, different name

p1.Equals(p3)               // true  (content matches)
object.ReferenceEquals(p1, p3) // false (different objects)
object.ReferenceEquals(p1, p4) // true  (literally the same object)
```

---

## 6. Singleton Design Pattern

**What it is (in one sentence):**
Singleton is a design pattern that guarantees a class can only ever have **one** object created from it, no matter how many times you try to make more.

**The full explanation:**
```csharp
class FTP
{
    public int Id { get; set; }
    public string Name { get; set; }

    private FTP() { Id = 1; Name = "XEROX"; }
    private FTP(int _id, string _name) { Id = _id; Name = _name; }

    static FTP obj;

    public static FTP CreateObject()
    {
        if (obj is null)
        {
            obj = new FTP();
            return obj;
        }
        else
        {
            return obj;
        }
    }
}
```
Three ingredients make this a Singleton:
1. **Private constructors** — `private FTP()` means code *outside* the class can never do `new FTP()`. The only door in is through the class itself.
2. **A private static field** (`static FTP obj`) — this holds the one-and-only instance, shared across the entire application (that's what `static` means: one copy total, not one per object).
3. **A public static factory method** (`CreateObject()`) — this is the only way outside code can get access. The first time it's called, `obj` is `null`, so it builds one. Every call after that, `obj` already has a value, so it just hands back the *same* object.

The commented `Program.cs` code proves this works:
```csharp
// FTP o1 = FTP.CreateObject();
// FTP o2 = FTP.CreateObject();
// FTP o3 = FTP.CreateObject();
// Console.WriteLine(o1.GetHashCode()); // same value
// Console.WriteLine(o2.GetHashCode()); // same value — proves o1 == o2 == o3
```
Compare that to the *non-singleton* version shown just above it in the file (`new FTP()` three times) — those would print **three different** hash codes, because each `new` genuinely creates a separate object.

**Key things to remember:**
- 🎯 **Exam Likely** — The three ingredients: private constructor + private static field + public static access method.
- ⚠️ **Common Mistake** — This particular implementation is **not thread-safe**: if two threads call `CreateObject()` at the exact same moment while `obj` is still `null`, they could both pass the `if (obj is null)` check and create two separate instances. (Fixing this needs a `lock` — worth knowing this limitation exists even if not asked to fix it.)
- The pattern is called "Singleton" because *single* + *-ton* (like "ton" in "carton" — a container holding exactly one).

**Example:**
```csharp
FTP a = FTP.CreateObject();
FTP b = FTP.CreateObject();
// a and b point to the exact same object — a.GetHashCode() == b.GetHashCode()
```

---

## 7. Generic Methods — and the Pass-by-Value Trap

**What it is (in one sentence):**
Generics let you write **one** method that works for **any** data type, instead of writing a near-identical copy for every type.

**The full explanation:**
`Utility.cs` shows the "before and after" of discovering generics. First, the repetitive, non-generic way:
```csharp
public static void SwapI(int left, int right) { ... }
public static void SwapS(string left, string right) { ... }
public static void SwapEmp(Employee left, Employee right) { ... }
```
Three separate methods, identical logic, only the type changes. That's the exact problem generics exist to solve:
```csharp
public static void Swap<STU>(STU left, STU right)
{
    STU tmp;
    tmp = left;
    left = right;
    right = tmp;
}
```
`<STU>` is a **type parameter** — a placeholder the caller fills in later. `STU` isn't a real type; it's a stand-in name (you'll also commonly see `<T>` used for the same purpose). One method body now works whether you call it with `int`, `string`, or `Employee`:
```csharp
Utility.Swap(x, y);           // compiler infers STU = int
Utility.Swap<int>(x, y);      // explicitly stating STU = int (same result)
```

⚠️ **Common Mistake** — and this is a real bug hiding in your own code: **none of these Swap methods actually swap anything the caller can see.** In C#, arguments are passed **by value** by default. That means `left` and `right` inside the method are *local copies*. Swapping the copies has zero effect on the original `x` and `y` back in `Main`. To make a real swap work, you'd need the `ref` keyword on every parameter:
```csharp
public static void Swap<STU>(ref STU left, ref STU right) { ... }
// called as: Utility.Swap(ref x, ref y);
```
This exact gap (value types being copied into methods) is one of the most commonly tested C# concepts — expect a question that asks "what does `x` equal after calling `Swap(x, y)` without `ref`?" (Answer: unchanged.)

**Key things to remember:**
- 🎯 **Exam Likely** — Generics eliminate code duplication across types while staying type-safe (no casting, no boxing for value types).
- 🎯 **Exam Likely** — Parameters are passed **by value** unless marked `ref` or `out` — local reassignment inside a method never affects the caller's variable.
- The type parameter name (`STU`, `T`) is arbitrary — it's a placeholder, not a keyword.

---

## 8. `var` — Implicit Typing

**What it is (in one sentence):**
`var` lets the compiler figure out a variable's type from what you assign to it — it is NOT a dynamic or loosely-typed keyword.

**The full explanation:**
```csharp
int x;
x = 3;
var y = 22;        // compiler infers: y is int
var str = "Ali";   // compiler infers: str is string
var map = new Dictionary<string, int>(); // compiler infers the full generic type

var z; // Compile Error!
```
C# is a **strongly typed** language — every variable has one fixed type, forever, decided at compile time. `var` doesn't change that; it just saves you from typing the type name yourself when it's obvious from context. The compiler substitutes the real type behind the scenes — `var y = 22;` becomes exactly `int y = 22;` once compiled.

**Key things to remember:**
- 🎯 **Exam Likely** — `var` **must** be initialized on the same line it's declared (`var z;` alone is a compile error) because the compiler needs the right-hand side to know what type to lock in.
- `var` is especially useful for long generic type names, like `Dictionary<string, List<Employee>>`.
- `var` ≠ `dynamic` — once inferred, the type can never change.

---

## 9. Generic Collection: `List<T>`

**What it is (in one sentence):**
`List<T>` is a resizable array — it solves the core weakness of plain arrays, which have a fixed size forever.

**The full explanation:**
Arrays (`int[] arr1 = {...}`) lock in their size at creation. `List<int>` grows automatically as you add more items. Internally, a `List<T>` keeps an actual array behind the scenes and swaps in a bigger one when it runs out of room:
```csharp
List<int> Nums = new List<int>(5); // starts with room ("Capacity") for 5
Nums.Add(1); ... Nums.Add(5);       // Count = 5, Capacity = 5 (full)
Nums.Add(6);                        // exceeds capacity → doubles to 10
Nums.Add(7); ... Nums.Add(11);      // exceeds 10 → doubles again to 20
Console.WriteLine(Nums.Capacity);   // 20
```
This is why the code comments predict `Capacity = 20` — the internal array **doubles** every time it fills up, which is far more efficient than growing by 1 each time.

Two distinct concepts to keep separate:
- **`Count`** = how many items are actually stored.
- **`Capacity`** = how much room currently exists before the next resize.

`TrimExcess()` shrinks unused capacity back down to match `Count`, freeing wasted memory.

The indexer (`arr[i]`) works for **get and update only** — never insert:
```csharp
arr[0] = 1000;   // ✅ update — index 0 already exists
arr[10] = 4000;  // ❌ RUNTIME ERROR if Count <= 10 — can't "insert" via indexer
```
To add new elements you must use `.Add()` (single item) or `.AddRange()` (multiple items at once).

**Key things to remember:**
- 🎯 **Exam Likely** — Arrays: fixed size. `List<T>`: dynamic size, doubles capacity on overflow.
- ⚠️ **Common Mistake** — Using the indexer to "insert" beyond the current `Count` throws `ArgumentOutOfRangeException`.
- `.Remove(value)` removes by **value** (first match); there's a separate `.RemoveAt(index)` for removing by position.

---

## 10. Generic Collection: `Dictionary<TKey, TValue>`

**What it is (in one sentence):**
`Dictionary<TKey, TValue>` stores data as key–value pairs, letting you look values up instantly by a unique key instead of scanning through a list.

**The full explanation:**
```csharp
Dictionary<int, string> map = new Dictionary<int, string>();
map.Add(1, "Ali");
map.Add(2, "Sara");
map.Add(5, "Aalaa");

map.Add(5, "Ziad");  // ❌ ERROR — key 5 already exists, .Add() refuses duplicates

map[6] = "Ahmed";    // ✅ indexer INSERTS if key 6 doesn't exist yet
map[5] = "Ziad";     // ✅ indexer UPDATES if key 5 already exists
Console.WriteLine(map[3]); // ✅ indexer SELECTS the value for key 3
```
This is the key contrast with `List<T>`: **the Dictionary indexer can insert**, because it's not indexed by position — it's indexed by key, and keys are supposed to be unique lookups, not sequential positions.

Iterating a dictionary hands you `KeyValuePair<TKey,TValue>` objects:
```csharp
foreach (var item in map)
{
    Console.WriteLine($"{item.Key}:{item.Value}");
}
```

**Key things to remember:**
- 🎯 **Exam Likely** — `.Add(key, value)` throws if the key already exists; the indexer `map[key] = value` never throws — it inserts-or-updates silently.
- Keys must be **unique**; values can repeat freely (notice `"Ali"` appears as a value for two different keys in the example).
- Dictionaries give near-instant (`O(1)` average) lookups by key, unlike scanning a `List` (`O(n)`).

---

# 📋 Master Cheat Sheet

| Concept | One-liner | Exam-critical detail |
|---|---|---|
| **Interface** | Contract of method headers + auto-properties, no bodies | All members implicitly `public`; can't instantiate |
| **Multiple interfaces** | `class X : BaseClass, IFace1, IFace2` | Only 1 base class, unlimited interfaces |
| **IComparable / IComparable<T>** | Defines how `Array.Sort()` orders custom objects | `CompareTo`: negative/0/positive = before/equal/after |
| **ICloneable** | Manual deep-copy via `Clone()` | Returns `object` → must cast; nested refs need rebuilding too |
| **`==` (unoverloaded)** | Reference/identity comparison for reference types | Not automatically linked to `Equals()` override |
| **`.Equals()`** | Can be overridden for content comparison | Should be paired with `GetHashCode()` override |
| **`ReferenceEquals()`** | ALWAYS pure identity check, ignores overrides | Static method on `object` |
| **Singleton pattern** | Guarantees exactly one instance of a class | private ctor + private static field + public static getter; not thread-safe here |
| **Generic method `<T>`** | One method body, works for any type | Params still pass **by value** unless `ref`/`out` used |
| **`var`** | Compiler infers the type at compile time | Must be initialized immediately; still strongly typed |
| **`List<T>`** | Resizable array | Capacity **doubles** on overflow; indexer can't insert |
| **`Dictionary<TKey,TValue>`** | Key→value lookup table | `.Add()` throws on duplicate key; indexer inserts OR updates |

---

### 🎯 The Lab Assignment This Code Is Building Toward
(from the bottom of `Program.cs`)
- `HireDate` (day/month/year), `Department` (id/name), `Employee` (id/name/age/salary/hiredate/department)
- Read + write one `Employee`
- Build an array of 10 employees, **sort by hire-date month**
- Try out the Singleton pattern
- Try out `Point.Equals`

To hit the "sort by hire-date month" requirement, you'd change `Employee.CompareTo` (or `HireDate.CompareTo`) to compare `Month` instead of `Age`/`Year` — same pattern you already have, just a different field.
