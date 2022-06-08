# Introdução

Serviços desenvolvidos para a imersão Impulse Tech, com o objetivo de disponibilizar uma aplicação para o desenvolvimento de funcionalidades para o treinamento dos participantes.

A ideia do sistema, é simular um consultório médico o qual utiliza este sistema para manter o registro de seus pacientes, além
também do agendamento e gerenciamento de consultas.

**Recursos:**

- Usuários do Sistema;
- Cadastro de pacientes;
- Gerenciamento do cadastro dos pacientes;
- Cadastro de agendamento de consultas;
- Gerenciamento do agendamento de consultas;
- Gerenciamento do cadastro de médicos;

**Aplicações disponíveis:**

- Api (.net framework 4.8);
- App (asp.net MVC framework 4.8)

---

## Compilando em seu ambiente

**Clone script:**
  
```bash
git clone https://github.com/andreguedesantunes877/ImpulseTech.git
```
---

## Tecnologias da stack

- .net framework 4.8
- asp.net MVC
- SQL Server
- Web API
- Entity Framework

## Executando em seu ambiente

- .net: Para debugar sem influenciar no servidor compartilhado, deve ter instalado na máquina local o .net Build and Tools com o .net framework 4.8, além do SQL Server (versão superior a 2012);
- Para o desenvolvimento, pode ser utilizado uma IDE da preferência do desenvolvedor (sugerido: Visual Studio 2019 Community)

---

## Componentes da aplicação

- Api: Suporte a disponibilização de funcionalidades como serviço para ser integrado em outro sistema. Sistemas de terceiros integram por esta porta de entrada e deve-se tomar muito cuidado quanto a refatoração de métodos e mudança em estrutura de objetos expostos;
- Web: Suporte a front-end web de nossa responsabilidade, onde podemos refatorar métodos e estrutura de objetos sem se preocucpar com sistemas de terceiros conectados;

---

## Documentações relacionadas

- **IMPORTANTE** Ler convenção de versionamento de branches **[Git Flow](https://www.atlassian.com/br/git/tutorials/comparing-workflows/gitflow-workflow)**;
- Adicionando [migrations](docs/EF%20Migrations.md) ao manipular modelo de dados;
- Entenda a estrutura e hierarquia de arquivos para configurações de parâmetros do projeto;
- Consulte a pasta [docs](docs) para ver a relação completa deste projeto;
- Não deixe de ler as Convensões de projetos .net C# para ajudar a manter o projeto sustentável;  

---

## Estrutura de diretórios

|Pasta              | Conteúdo|
|-------------------|---------|
|[docs](docs)       | Documentações relacionadas ao projeto|
|[src](src)         | Código fonte|
|[scripts](scripts) | Scripts para automatação de processos|
|[tests](tests)     | Código fonte dos testes de unidade, testes de integração, load tests, etc...; |


