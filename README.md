# Projeto KnowLedge.IO

O projeto Knowledge.IO é um sistema web de identificação e autorização desenvolvido na plataforma .NET Core. Neste projeto foi utilizado conceitos arquiteturais
de modelagem de domínio (DDD), separação de comandos e consultas (CQRS) e implementações voltadas a testes com os fundamentos do TDD.


## Metodologia
Realizei estudos sobre as arquiteturas citadas anteriormente e então desenvolvi uma aplicação capaz de fornecer uma API, para identificar usuários
e aplicar políticas de autorização baseadas em **permissões** por **perfil**. Todo o módulo de identidade e acesso foi completamente isolado da aplicação web e customizado
com _IdentityServer_, com o propósito de descartar a implementação do IdentityCore, porque para o contexto atual não se encaixava.


#### Tecnologias Implementadas
 - [x] ASP.NET Core 2.2 (com .NET Core 2.2)
 - [x] ASP.NET WebApi Core
 - [x] Identity Server 4
 - [x] Entity Framework Core 2.2
 - [x] .NET Core DI Nativa
 - [x] MediatR
 - [x] FluentValidator
 - [x] Angular 8 
 - [x] Elmah.IO 
 - [x] Swagger UI
 - [ ] RobbitMQ

 #### Arquiteturas
 - [x] Domain Driven Design (Camadas e Domain Model Pattern)
 - [x] Test Driven Development
 - [x] CQRS (abordagem simples)
 - [x] Domain Events
 - [x] Domain Notifications
 - [x] Repository e Generic Repository
 - [x] Unit Of Work
 - [ ] Event Sourcing


####  Links dos Apps

[SPA - Angular](https://spaknowledge.azurewebsites.net)
[API](https://knowledgeback.azurewebsites.net)