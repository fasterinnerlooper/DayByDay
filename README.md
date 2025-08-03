# DayByDay

This repository contains a Windows Phone application and accompanying unit tests.

## Running Tests

Use the `dotnet` CLI to execute tests defined in `DayByDay.Tests` and to check
code formatting.

```
dotnet format --verify-no-changes
dotnet test DayByDay.sln
```

`dotnet format` ensures the codebase follows the formatting rules and
`dotnet test` builds the solution and runs all tests in the test project.

### Pre-commit Hooks

This repository includes a `.pre-commit-config.yaml` file so you can install
pre-commit hooks locally:

```
pre-commit install
```

The hooks run `dotnet format` and `dotnet test` before each commit.
