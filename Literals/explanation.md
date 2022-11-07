# Literals, Constants and Variables

- A **Literal** is a value appearing in your program. Examples:

  - String literal: `"Hello World"`
  - Character literal: `'A'`
  - Integer literal: `42`
  - Floating point literal: `3.1415`, `42f`
  - Boolean literal: `true`, `false`
  - Long literal: `42L`

- A **Constant** is a symbolic name for a literal

  - The value of a constant _cannot_ change!
  - The names of constants in C# are usually written in _UPPERCASE LETTERS_.
  - E.g. `const int ANSWER = 42` or `const string GREETINGS = "Hello World";`

- A **Variable** is a symbolic name whose value _can_ change
  - The names of variables in C# are usually written in _lowercase letters_.
  - _Assignment:_ statement that assigns a value to a variable.
  - E.g. `int answer = 42`, `string greetings = "Hello World";`

## Code examples:

**Literals:**

```csharp
Console.Write("Take "); // "Take " is a String Literal
Console.Write(3); // 3 is an Integer Literal
Console.Write(1.5); // 1.5 is a Floating Point Literal
Console.Write(true); // true is a Boolean Literal
```

**Constants:**

```csharp
const int MAX_NUMBER = 100; // MAX_NUMBER is a constant and holds the Integer Literal 100
Console.Write(MAX_NUMBER);
```

**Variables:**

```csharp
string name = Console.ReadLine()!; // Assign user input to the variable name
Console.WriteLine(name);
name = Console.ReadLine()!; // change the value of name -> cannot be a constant
Console.WriteLine(name);
```
