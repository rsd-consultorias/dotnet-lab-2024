# Projeto de Exemplo

## Decisões de arquitetura

[Repository Pattern](https://learn.microsoft.com/en-us/ef/core/testing/choosing-a-testing-strategy#repository-pattern)

## Comandos úteis

```bash
# Criação do projeto da API
dotnet % dotnet new webapi -n API

# Criação do projeto do Core
dotnet new classlib -n Core

# Criaçao do projeto de Testes
dotnet new nunit -n Tests

# Adicionar referências dos projetos
dotnet add API/API.csproj reference Core/Core.csproj
dotnet add Tests/Tests.csproj reference Core/Core.csproj

# Criação da solução
dotnet new sln --name ProjetoExemplo

# Adicionar todos os projetos na Solution
dotnet sln ProjetoExemplo.sln add API/API.csproj
dotnet sln ProjetoExemplo.sln add Core/Core.csproj
dotnet sln ProjetoExemplo.sln add Tests/Tests.csproj

# Listar projetos da solução
dotnet sln ProjetoExemplo.sln list

# Clean
dotnet clean

# Build da solução
dotnet build

# Rodar testes unitários
dotnet test --collect:"XPlat Code Coverage"

# Relatório de cobertura
reportgenerator -reports:Tests/TestResults/8d9ec5ac-c31f-443c-b05a-f97aeea9f5b5/coverage.cobertura.xml -targetdir:".docs/coveragereport" -reporttypes:Html

# Publish da solução
dotnet publish


# ## Tools
# Relatório de cobertura de testes
dotnet tool install --global dotnet-reportgenerator-globaltool --version 5.2.4
export PATH="$PATH:/Users/rafaeldias/.dotnet/tools"
```