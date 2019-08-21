# Projeto KnowLedge.IO

O projeto Knowledge.IO é um sistema web de identificação e autorização desenvolvido na plataforma .NET Core. Neste projeto foi utilizado conceitos arquiteturais
de modelagem de domínio (DDD), separação de comandos e consultas (CQRS) e implementações voltadas a testes com os fundamentos do TDD.


## Metodologia
Realizei estudos sobre as arquiteturas citadas anteriormente e então desenvolvi uma aplicação capaz de fornecer uma API para identificar usuários
e aplicar políticas de autorização baseadas em **permissões** por **perfil**. Todo o módulo de identidade e acesso foi completamente isolado da aplicação web e customizado
com _IdentityServer_, com o propósito de descartar a implementação do IdentityCore, porque para o contexto atual não se encaixava.


#### Tecnologias Utilizadas
 - [x] .NET Core / Standard
 - [x] ASP.NET Core Web Application
 - [x] EntityFramework Core
 - [x] MediatR
 - [x] IdentityServer 4
 - [x] Angular 8 
 - [x] Elmah.IO 
 - [ ] RobbitMQ

 #### Arquiteturas
 - [x] Domain Driven-Design
 - [x] Test Driven-Development
 - [x] CQRS
 - [x] Domain Events
 - [x] Domain Notifications
 - [x] Mediator Pattern
 - [x] Unit Of Work
 - [ ] Event Sourcing
