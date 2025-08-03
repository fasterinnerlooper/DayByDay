# DayByDay

This repository contains a Windows Phone application and accompanying unit tests.
After converting the app to .NET MAUI you can target modern iOS and Android devices.

## Prerequisites

Before building for mobile ensure the MAUI workload is installed:

```bash
dotnet workload install maui
```

Building for iOS requires Xcode (on macOS). Building for Android requires the
Android SDK and emulator or a connected device.

## Building and Running on Mobile

Use the `dotnet` CLI to build and deploy the MAUI app. Specify the target
framework for the platform you want to run:

```bash
# Run on Android
dotnet build -t:Run -f net8.0-android

# Run on iOS (requires macOS with Xcode installed)
dotnet build -t:Run -f net8.0-ios
```

The commands above build the app and attempt to deploy it to the default
emulator or connected device for the chosen platform.


## Running Tests

After converting to MAUI the unit tests can still be executed with the
`dotnet` CLI. Tests remain in `DayByDay.Tests`.

```
dotnet test DayByDay.sln
```

`dotnet test` will build the solution and run all tests in the test project.
