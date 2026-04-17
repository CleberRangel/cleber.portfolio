# Rule Examples

Use these examples when the user wants a concrete C# refactor suggestion or a before/after comparison.

## 1. Five lines

**Bad**

```csharp
public decimal CalculateTotal(Order order)
{
    var tax = order.Price * 0.2m;
    var discount = order.IsPremium ? order.Price * 0.1m : 0m;
    return order.Price + tax - discount;
}
```

**Good**

```csharp
public decimal CalculateTotal(Order order)
{
    return order.Price + GetTax(order) - GetDiscount(order);
}
```

## 2. Either call or pass, but not both

**Bad**

```csharp
public void SendWelcome(User user)
{
    var name = user.Name.Trim().ToUpperInvariant();
    emailSender.Send(name);
}
```

**Good**

```csharp
public void SendWelcome(User user)
{
    emailSender.Send(FormatName(user));
}
```

## 3. If only at the start

**Bad**

```csharp
public decimal GetPrice(Item item)
{
    var price = item.BasePrice + 10m;
    if (item.IsLuxury)
    {
        price *= 1.5m;
    }

    return price;
}
```

**Good**

```csharp
public decimal GetPrice(Item item)
{
    if (item.IsLuxury)
    {
        return GetLuxuryPrice(item);
    }

    return item.BasePrice + 10m;
}
```

## 4. Never use `if` with `else`

**Bad**

```csharp
public string GetLabel(string status)
{
    if (status == "active")
    {
        return "Active user";
    }
    else
    {
        return "Inactive user";
    }
}
```

**Good**

```csharp
public string GetLabel(string status)
{
    if (status == "active")
    {
        return "Active user";
    }

    return "Inactive user";
}
```

## 5. Never use switch

**Bad**

```csharp
public int GetSpeed(string vehicle)
{
    return vehicle switch
    {
        "car" => 100,
        "bike" => 30,
        _ => 0
    };
}
```

**Good**

```csharp
public interface IVehicle
{
    int Speed();
}

public sealed class Car : IVehicle
{
    public int Speed() => 100;
}

public sealed class Bike : IVehicle
{
    public int Speed() => 30;
}

public int GetSpeed(IVehicle vehicle) => vehicle.Speed();
```

## 6. Only inherit from interfaces

**Bad**

```csharp
public class Animal
{
    public void Move() => Console.WriteLine("Moving");
}

public class Dog : Animal
{
}
```

**Good**

```csharp
public interface IMovable
{
    void Move();
}

public sealed class Dog : IMovable
{
    public void Move() => Console.WriteLine("Running");
}
```

## 7. Use pure conditions

**Bad**

```csharp
if ((user = GetUser()) != null)
{
    DoWork(user);
}
```

**Good**

```csharp
var user = GetUser();
if (user != null)
{
    DoWork(user);
}
```

## 8. No interface with only one implementation

**Bad**

```csharp
public interface ILogger
{
    void Log(string message);
}

public sealed class ConsoleLogger : ILogger
{
    public void Log(string message) => Console.WriteLine(message);
}
```

**Good**

```csharp
public sealed class ConsoleLogger
{
    public void Log(string message) => Console.WriteLine(message);
}
```

## 9. Do not use getters or setters

**Bad**

```csharp
public sealed class Circle
{
    public double Radius { get; }

    public double GetRadius() => Radius;
}

var area = Math.PI * circle.GetRadius() * circle.GetRadius();
```

**Good**

```csharp
public sealed class Circle
{
    public double Radius { get; }

    public double Area() => Math.PI * Radius * Radius;
}
```

## 10. Never have common affixes

**Bad**

```csharp
public sealed class UserManager { }
public sealed class UserHelper { }
public sealed class UserService { }
```

**Good**

```csharp
public sealed class UserRegistration { }
public sealed class EmailNotifier { }
public sealed class PasswordValidator { }
```

## Pattern examples

### Extract Method

**Bad**

```csharp
public void PrintSummary(Order order)
{
    var tax = order.Price * 0.2m;
    var discount = order.IsPremium ? order.Price * 0.1m : 0m;
    var total = order.Price + tax - discount;
    Console.WriteLine($"Order for {order.Name}");
    Console.WriteLine($"Total: {total}");
}
```

**Good**

```csharp
public void PrintSummary(Order order)
{
    Console.WriteLine($"Order for {order.Name}");
    Console.WriteLine($"Total: {CalculateTotal(order)}");
}

private static decimal CalculateTotal(Order order)
{
    return order.Price + GetTax(order) - GetDiscount(order);
}
```

### Replace Type Code with Classes

**Bad**

```csharp
public int GetSpeed(string vehicleType)
{
    return vehicleType switch
    {
        "car" => 100,
        "bike" => 30,
        "truck" => 80,
        _ => 0
    };
}
```

**Good**

```csharp
public interface IVehicle
{
    int Speed();
}

public sealed class Car : IVehicle
{
    public int Speed() => 100;
}

public sealed class Bike : IVehicle
{
    public int Speed() => 30;
}

public sealed class Truck : IVehicle
{
    public int Speed() => 80;
}

public int GetSpeed(IVehicle vehicle)
{
    return vehicle.Speed();
}
```

### Push Code into Classes

**Bad**

```csharp
public void DrawTile(string tileType)
{
    if (tileType == "stone")
    {
        DrawGray();
        return;
    }

    if (tileType == "air")
    {
        DrawBlue();
    }
}
```

**Good**

```csharp
public interface ITile
{
    void Draw();
}

public sealed class Stone : ITile
{
    public void Draw() => DrawGray();

    private static void DrawGray() { }
}

public sealed class Air : ITile
{
    public void Draw() => DrawBlue();

    private static void DrawBlue() { }
}

public void DrawTile(ITile tile)
{
    tile.Draw();
}
```

### Inline Method

**Bad**

```csharp
public string GetFullName(User user)
{
    return BuildName(user);
}

private static string BuildName(User user)
{
    return $"{user.FirstName} {user.LastName}";
}
```

**Good**

```csharp
public string GetFullName(User user)
{
    return $"{user.FirstName} {user.LastName}";
}
```

### Specialize Method

**Bad**

```csharp
public void Move(Player player, string direction, int distance)
{
    if (direction == "left")
    {
        player.X -= distance;
    }

    if (direction == "right")
    {
        player.X += distance;
    }
}
```

**Good**

```csharp
public void MovePlayerLeft(Player player, int distance)
{
    player.X -= distance;
}

public void MovePlayerRight(Player player, int distance)
{
    player.X += distance;
}

```

### Unify Similar Classes

**Bad**

```csharp
public sealed class EmailNotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public sealed class SmsNotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}
```

**Good**

```csharp
public interface INotification
{
    void Send(string message);
}

public sealed class EmailNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"Email: {message}");
    }
}

public sealed class SmsNotification : INotification
{
    public void Send(string message)
    {
        Console.WriteLine($"SMS: {message}");
    }
}
```

### Combine Ifs

**Bad**

```csharp
if (user.IsAdmin)
{
    if (user.IsActive)
    {
        GrantAccess();
    }
}
```

**Good**

```csharp
if (user.IsAdmin && user.IsActive)
{
    GrantAccess();
}
```

### Introduce Strategy Pattern

**Bad**

```csharp
public sealed class Sorter
{
    public int[] Sort(int[] data, string algorithm)
    {
        if (algorithm == "bubble")
        {
            return BubbleSort(data);
        }

        if (algorithm == "quick")
        {
            return QuickSort(data);
        }

        return data;
    }

    private static int[] BubbleSort(int[] data) => data;
    private static int[] QuickSort(int[] data) => data;
}
```

**Good**

```csharp
public interface ISortStrategy
{
    int[] Sort(int[] data);
}

public sealed class BubbleSort : ISortStrategy
{
    public int[] Sort(int[] data) => data;
}

public sealed class QuickSort : ISortStrategy
{
    public int[] Sort(int[] data) => data;
}

public sealed class Sorter
{
    private readonly ISortStrategy strategy;

    public Sorter(ISortStrategy strategy)
    {
        this.strategy = strategy;
    }

    public int[] Sort(int[] data)
    {
        return strategy.Sort(data);
    }
}
```

### Extract Interface from Implementation

**Bad**

```csharp
public sealed class ConsoleLogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }

    public void Warn(string message)
    {
        Console.WriteLine($"WARN: {message}");
    }
}
```

**Good**

```csharp
public interface ILogger
{
    void Log(string message);
}

public sealed class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}
```

### Eliminate Getter or Setter

**Bad**

```csharp
public sealed class Circle
{
    public double Radius { get; }

    public double GetRadius()
    {
        return Radius;
    }
}

var area = Math.PI * circle.GetRadius() * circle.GetRadius();
```

**Good**

```csharp
public sealed class Circle
{
    public Circle(double radius)
    {
        Radius = radius;
    }

    public double Area()
    {
        return Math.PI * Radius * Radius;
    }

    public double Radius { get; }
}
```

### Encapsulate Data

**Bad**

```csharp
public string userFirstName = "Alice";
public string userLastName = "Smith";
public int userAge = 30;
```

**Good**

```csharp
public sealed class User
{
    public User(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
}
```

### Try Delete then Compile

**Bad**

```csharp
public string LegacyFormatDate(DateTime date)
{
    return date.ToString("yyyy-MM-dd");
}
```

**Good**

```csharp
// Delete the method first.
// If callers break, restore it.
// If nothing breaks, remove it permanently.
```