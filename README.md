# 🏛️ Good Hamburger 

> *Clean Architecture API* • Domain-Driven Design • Built with .NET

<div align="center">

[![.NET](https://img.shields.io/badge/.NET-10-512BD4?style=for-the-badge&logo=dotnet)](https://dotnet.microsoft.com/)
[![EF Core](https://img.shields.io/badge/EF%20Core-7.0-512BD4?style=for-the-badge&logo=dotnet)](https://learn.microsoft.com/ef/core/)
[![PostgreSQL](https://img.shields.io/badge/PostgreSQL-Ready-336791?style=for-the-badge&logo=postgresql)](https://www.postgresql.org/)
[![Status](https://img.shields.io/badge/Status-Production%20Ready-27AE60?style=for-the-badge)](/)

</div>

---

## ✨ Escolha arquitetural / Abordagem de desenvolvimento

Este projeto foi deliberadamente superdimensionado (overengineered). Embora as funcionalidades pudessem ser resolvidas com uma Minimal API simples e sem acesso ao banco, a estrutura atual foi escolhida para demonstrar explicitamente o domínio de:

* Design Patterns complexos (Strategy, Mediator/Command, CQRS, etc).

* Arquitetura Limpa e separação de interesses.

* Desacoplamento total entre camadas.

O sistema poderia inclusive ser dividido em Contextos Delimitados (Bounded Contexts), para escala em microsserviços futuramente. No entanto, para manter o escopo deste desafio técnico gerenciável, os contextos permanecem unificados por questões de simplicidade e legibilidade.

Para tal projeto, escolhi uma Clean Architecture com a abordagem Domain Driven Design, o padrão de design Mediator/Command (Gang of Four), por considerar que estes garantem uma separação ideal do código, sem sacrificar a simplicidade. 
Também fiz um padrão CQRS com escrita e leitura separadamente, com Dapper e Entity Framework, priorizando a máxima performance em queries sem perder a segurança de um ORM.

---

## 🗄️ Migrations (os itens do Menu são aplicados por meio de Seed)

Para gerar as migrations e aplicá-las no banco:

### Passo 1️⃣ Selecione o projeto que contém o NpgSql & Entity framework
```
cd src/Infrastructure/Core.Template.Infrastructure.PostgreSQL/
```

### Passo 2️⃣ Criar uma migração
```
dotnet ef migrations add MigrationName
  -o Migrations 
  -s ../../Presentation/GoodHamburger.Presentation/Core.Template.Presentation.csproj
```

### Passo 3️⃣ Aplicar a migração ao banco

* Isso é realizado no momento de inicialização da aplicação pelo próprio Entity propositalmente.
```
dotnet ef database update 
  -s ../../Presentation/GoodHamburger.Presentation/GoodHamburger.Presentation.csproj
```

### Caso necessário, remover a migração

```
dotnet ef migrations remove 
  -s ../../GoodHamburger/GoodHamburger.Presentation/GoodHamburger.Presentation.csproj
```

---

## 📁 Estrutura do projeto

```
ddd-core-template/
├── src/
│   ├── Presentation/
│   │   └── Core.Template.Presentation/       # API 
│   ├── Application/
│   │   └── Core.Template.Application/        # Lógica de orquestração & Casos de uso
│   ├── Domain/
│   │   ├── Core.Template.Domain/             # Entidades & Regras de domínio
│   │   └── Core.Template.Shared/             # Shared Kernel 
│   └── Infrastructure/
│       ├── Core.Template.Infrastructure.PostgreSQL/    # Database 
├── tests
     └── UnitTests                            #Testes unitários para garantir confiabilidade das regras de domínio
```

---

</div>
