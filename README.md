# UnitTestingPractice

## Description
- Practicing on ASP.net core with (xUnit) unit testing using Mock for virtual database and applying on pipeline github actions to check for tests passed or failed over every push and pull request into main branch.
- there are one database model named `Product` with products info and service for CRUD operation to apply tests on it.

## The test.yml github pipeline action

```
name: tests

on:
  push:
    branches:
      - 'main'
  pull_request:
    branches:
      - main
  
jobs:
  tests:
    runs-on: windows-latest

    steps:
      - name: Checkout repository
        uses: actions/checkout@v2

      - name: Setup .NET Core SDK
        uses: actions/setup-dotnet@v1
        with:
            dotnet-version: '8.0'
             

      - name: Test
        working-directory: ./UnitTestingPractice
        run: dotnet test 
 
```

<BR/>

> ASP.net core with (xUnit) unit testing practicing using Mock for virtual database.
## Unit Tests Result Sample
![Screenshot 2024-04-22 003206](https://github.com/kareem983/UnitTestingPractice/assets/52586356/5d1d74d7-d66f-4c30-89ec-ab5f2644d57f)

<BR/>

> Applying on pipeline github actions to check for tests passed or failed over every push and pull request into main branch.

## Github Action Test pipeline Sample
![Screenshot 2024-04-22 002818](https://github.com/kareem983/UnitTestingPractice/assets/52586356/7997a6dd-594a-417b-a6f0-b55c3b0127b8)


## References/Resources

- [xUnit test Documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test)
 
- [xUnit test](https://xunit.net/docs/getting-started/netfx/visual-studio)

- [.Net Guide](https://visualstudio.microsoft.com/vs/features/net-development/)

- [Database Guide](https://learn.microsoft.com/en-us/sql/?view=sql-server-ver16)
  
