# API de Controle de Estoque

API REST desenvolvida em ASP.NET Core para gerenciamento de produtos e movimentações de estoque.

## Funcionalidades

- Cadastro de produtos
- Entrada e saída de estoque
- Histórico de movimentações
- Autenticação JWT
- Proteção de endpoints
- Swagger/OpenAPI
- Repository Pattern
- Service Layer

## Tecnologias

- ASP.NET Core
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- C#

## Arquitetura

Controller → Service → Repository → Database

## Como executar

1. Clonar o repositório
2. Configurar connection string
3. Executar migrations
4. Rodar o projeto

```bash
dotnet ef database update
dotnet run
