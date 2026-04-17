# cleber.portfolio — C# Example Projects

Small collection of C# example projects and experiments used in this portfolio.

Included projects
- `Grpc` — gRPC server and client examples.
- `MinimalAPI` — minimal ASP.NET Core example with endpoint definitions.
- `SerialExample/SerialPortExample` — console app that demonstrates sending values over a serial port.
- `WpfBuildWithSquirrel` — WPF sample used to demonstrate packaging with Squirrel.

Requirements
- .NET 7 SDK (or later)

Quick start

Build all projects:

```bash
dotnet build
```

Run the Serial port example (adjust COM port as needed):

```bash
dotnet run --project SerialExample/SerialPortExample/SerialPortExample.csproj
```

Run the Minimal API:

```bash
dotnet run --project MinimalAPI/MinimalAPI/MinimalAPI.csproj
```

Notes
- The `SerialPortExample` uses `System.IO.Ports`; make sure a device is connected and you know the correct COM port.
- These projects are small demos — check each project folder for README or comments with additional details.

If you'd like, I can add per-project READMEs or improve the run instructions for a specific project.
