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
##### Class structure
1. [Braces](#braces)
2. [Regions](#regions)
##### Commenting
1. [How to comment your code](#how-to-comment-your-code)
##### Syntactic Sugar
1. Ternary operators
2. Using var
3. Inline methods
4. String formatting
---
## Naming Conventions
Naming conventions are used to ensure that all developers can quickly identify the type, purpose or scope of a variable, method, class etc in the codebase. By maintaining a standard, we aim to make it easier for other developers (including those that might join in the future) to pick up a project.

### Casing
Use [**pascal case**](https://en.wikipedia.org/wiki/PascalCase) for class and method names. 
>**Why?** Easier to identify methods on static classes. Follows .NET Framework standards.

>**Exceptions:** private methods use camel case to make them easier to spot in Intellisense tools.

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

Use [**camel case**](https://en.wikipedia.org/wiki/Camel_case) for method arguments, private methods and local variables.

>**Why?** Easily identify scope of a variable. Follows .NET Framework standards.

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
Only use abbreviations when they are used in the business domain (e.g. an abbreviation commonly used as a name). You can use [pascal casing](http://wikipedia.org/wiki/PascalCase) for abbreviations of 3 characters or more (2 charecters are both uppercase).

>**Why?** Abbreviations can lead to confusion if the developer is not used to the problem domain
```cs
// Correct
UserGroup userGroup;
Assignment employeeAssigment;

// Avoid
UserGroup usrGrp;
Assignment empAssigment;

//Exceptions
CustomerId customerId; // Instead of CustomerIdentifier
XmlDocument xmlDocument; // Instead of ExtensibleMarkupLanguageDocument
```

### Underscores
You should only use underscores when naming private class variables or event handlers.
>**Why?** Easier to read. Private variables are easier to spot. Conforms with .NET Framework standards. Avoids underline stress.
```cs
// Correct
public DateTime ClientAppointment;
public TimeSpan TimeLeft;
AppointmentService _appointmentService;

// Avoid
public DateTime Client_Appointment
public TimeSpan Time_Left;
AppointmentService _appointment_Service;
```

### Namespaces
Namespaces should be organised with a clear structure. CYC.{TeamName}.{SolutionName}.{Project}[.{SubModule}
>**Why?** 
```cs
namespace CYC.DigitalHub.Product.Module { }
namespace CYC.DigitalHub.Health.Logic { }
namespace CYC.DigitalHub.Profiles.Presentation { }
```
### Classes
Classes should be named using noun or noun phrases.
>**Why?** Easy to remember. Conforms with .NET Framework standards.
```cs
public class Employee
{

}
public class BusinessLocation
{

}
public class DocumentCollection
{

}
```

### Partial classes
Partial classes should have a file name that reflects their source or purpose. File name should contain a part that specifies how it differs from others parts of the same class.
>**Why?** Keep related files grouped, maintains alphabetical structure. Consistent with .NET Framework standards.
```
// Located in Task.cs
public partial class Task
{
    //...
}
// Located in Task.generated.cs

public partial class Task
{
    //...
}
```

### Interfaces
Interface names should always be preceeded by an 'I'. Interface names are nouns or adjectives.
>**Why?** Easy to distinguish an interface. Conforms to .NET Framework standards.
```cs
public interface IShape
{
}
public interface IShapeCollection
{
}
public interface IGroupable
{
}
```

### Enums
Enumerations should use singular names e.g. *PlasticType* not *PlasticTypes*
>**Why?** Easier to read. Consistent with .NET Framework.

>**Exceptions:** bit field enumerations should be pluralised as you can select more than one value.

```cs
// Correct
public enum Color 
{
    Red,
    Green,
    Blue,
    Yellow,
    Magenta,
    Cyan
}

// Exception
[Flags]
public enum Dockings
{
    None = 0,
    Top = 1,
    Right = 2,
    Bottom = 4,
    Left = 8
}
```

Don't suffix enum names with 'Enum'
>**Why?** No need to, we don't particularly care that it's an enumeration
```cs
// Avoid
public enum DockingsEnum 
{
    //...
}
```

### Files
File names should match the name of the class within the file. Multiple classes may exist in the same file if the supporting classes are not used for other purposes in the application
```cs
// In file 'UserDetailViewModel.cs'
public class UserDetailViewModel 
{
    public String Username { get; set; }
    public UserAddressViewModel { get; set; }
    //...
}

// also in file 'UserDetailViewModel' as it is only used in / relevant to the context of this view.
public class UserAddressViewModel 
{
    public List<Address> Addresses { get; private set; }
    private int _primaryAddressIndex;
    public Address PrimaryAddress 
    {
        get 
        {
            return Addresses[_primaryAddressIndex];
        }
    }
    
    public UserAddressViewModel(List<Addresses> addresses, int primaryAddressIndex)
    {
        Addresses =  new List<Address>();
        Addresses.AddRang(addresses);
        
        if(primaryAddressIndex > 0 && primaryAddressIndex < addresses.Count)
        {
            _primaryAddressIndex = primaryAddressIndex;
        }
    }
}
```

## Class structure
Structuring files in a set way makes it easy to find the code you are looking for, even if you've not seen it before. Generally a file will read like this (top to bottom):
1. Using statements
2. Namespace delcaration
3. class declaration
4. Public properties
5. Private variables
6. Constructor
7. Public methods
8. Private methods

```cs
// Using statements 1st
using System;
using System.Collections;
using System.Collections.Generic;

// Namespace 2nd
namespace CYC.DigitalHub.CodingStandards
{
    // Class declaration 3rd
    public class Book
    {
        // Public properties 4th
        public string Title { get; private set; }
        public List<string> ChapterTitles { get; private set; }
        
        // Private variables 5th
        private int currentChapter = 0;
        
        // Constructor 6th
        public Book(string title, List<string> chapterTitles)
        {
            Title = title;
            ChapterTitles = chapterTitles;
        }
        
        // Public methods 7th
        public void GoToChapter(int chapterIndex) 
        {
            currentChapter = chapterIndex;
        }
        
        // Private methods last
        private bool isLastChapter() 
        {
            return currentChapter == ChapterTitles.Count - 1;
        }
    }
}
```

### Brackets
Brackets should be vertically aligned
>**Why?** To keep consistency with .NET Framework
```cs
// Correct
class Program
{
    static void Main(string[] args)
    {
    }
}
```

### Regions
Code can be aggregated using regions if it is getting unwieldy. At the **class level**, regions can be used to group variables / methods by scope or purpose. **Inside a method** regions can be used to condense large logic blocks, this is preferred to splitting code out into separate methods *unless you need to reuse the code*.

Regions should be well named to reflect what they contain.

```cs
public class Polygon 
{
// Grouping by scope
#region Public properties
    public List<Vector2D> Vertices { get; private set; }
    public Color LineColour { get; set; }
    //...
#endregion

// Grouping by purpose
#region Vertices manipulation methods
    private void Twist(int factor, Direction direction = right)
    {
        //...
    }
#endregion
}
```

## Commenting

>**Why?** Commenting business logic makes it easier to maintain for other developers. Maintaining a standard for comments means we're more likely to understand them in a year or two.

### How to comment your code

Comments should always be on a new line above the code being referred to.
>**Exception:** Multiline code such as initialisers may contain a comment to the right if it makes it easier to understand

```cs
// Correct

// Retrieve house numbers by postcode
var houseNumbers = postcodeService.GetNumbers(postcode)

var House = new House()
{
    ExternalDoors = 2,
    Windows = 4,
    Floors = houseHeight / averageHeightPerFloor // We don't know how many floors so we're going make a guess
}

//Incorrect
var houseNumbers = postcodeService.GetNumbers(postcode) // Retrieve house numbers by postcode
```

Begin a comment with a space then an uppercase letter.

Comment text should be completed with a full stop.

Classes and method should be commented using the /// format. 


>**Why?** Visual studio will auto complete this to a summary comment that explains the use of the class or method.