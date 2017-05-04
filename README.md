# CYC Development Team coding standards
This repository contains a sample solution and documentation explaining CYC Coding standards and styles

## Index
##### Naming Conventions
1. [Casing](#casing)
2. [Things to avoid](#things-to-avoid)
3. [Abbreviations](#abbreviations)
4. [Underscores](#underscores)
5. [Namespaces](#namespaces)
6. [Classes](#classes)
7. [Partial Classes](#partial-classes)
8. [Interfaces](#interfaces)
9. [Enums](#enum-naming-conventions)
10. [Files](#files)
##### Types
1. Usage of var
2. Enums
##### Class structure
1. Braces
2. Variable placement
3. Constructor placement
4. Regions
##### Commenting
1. How to comment your code
---
## Naming Conventions
Naming conventions are used to ensure that all developers can quickly identify the type, purpose or scope of a variable, method, class etc in the codebase. By maintaining a standard, we aim to make it easier for other developers (including those that might join in the future) to pick up a project.

### Casing
Use [**pascal case**](https://en.wikipedia.org/wiki/PascalCase) for class and method names. 

```cs
public class ClientActivity
{
    public void ClearStatistics()
    {
        // ...
    }
    
    private void resetActivityList()
    {
        // ...
    }
}
```

>**Why?** Easier to identify methods on static classes. Follows .NET Framework standards.

>**Exceptions:** private methods use camel case to make them easier to spot in Intellisense tools.

Use [**camel case**](https://en.wikipedia.org/wiki/Camel_case) for method arguments, private methods and local variables.
```cs
public class UserLog
{
    public void Add(LogEvent logEvent)
    {
        int itemCount = getItemCount(logEvent.Items)
        // ...
    }
    
    private void getItemCount(List<Item> items)
    {
        return items.Count;
    }
}
```
>**Why?** Easily identify scope of a variable. Follows .NET Framework standards.

### Things to avoid
Don't use Hungarian notation - C# doesn't need it.
```cs
// Correct
int counter;
string name;

// Avoid
int iCounter; // We know it's an int so don't add the i
string strName; // Same issue
```
Don't use screaming caps for constants or readonly variables
```cs
// Correct
public static const string ShippingType = "DropShip";

// Avoid
public static const string SHIPPINGTYPE = "DropShip";
```

### Abbreviations