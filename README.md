# CleanArchMvc

Projeto desenvolvido com o objetivo de demonstrar a aplicação da **Clean Architecture** em uma solução **ASP.NET Core MVC**, promovendo separação de responsabilidades, baixo acoplamento entre camadas e organização escalável do código.

A arquitetura segue a **regra de dependência**, onde as camadas externas dependem apenas das camadas internas.

## Estrutura da solução

A solução é composta pelos seguintes projetos:

* **CleanArchMvc.Domain**

  * Entidades do domínio
  * Interfaces
  * Regras de negócio

* **CleanArchMvc.Application**

  * Serviços de aplicação
  * DTOs
  * CQRS
  * Mapeamentos

* **CleanArchMvc.Infra.Data**

  * Implementação de repositórios
  * Entity Framework Core
  * DbContext e Migrations

* **CleanArchMvc.Infra.IoC**

  * Configuração de Injeção de Dependência
  * Registro de serviços da aplicação

* **CleanArchMvc.WebUI**

  * Camada de apresentação
  * Controllers
  * Views
  * ViewModels

* **CleanArchMvc.Domain.Tests**

  * Testes unitários utilizando xUnit

## Objetivo

Demonstrar uma estrutura de projeto baseada em boas práticas de arquitetura de software utilizando Clean Architecture em aplicações .NET.
