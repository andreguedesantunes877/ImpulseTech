# Camada de Infra Data

```bash
- A cama da de infra data é responsável pelo contexto da aplicação, mapeamentos de banco de dados, migrações para alteração de banco de dados e também
realizar consulta em bancos de dados ou serviços externos.

- Os serviços de repositórios herdam os métodos genéricos do repositório base, podendo ser utilizado para qualquer tipo de repositório sem a necessidade
de duplicação de código. Com isso, cada repositório deverá implementar apenas suas particularidades já que o base realiza o CRUD básico.
```

## DICAS
```bash
- Você pode usar qualquer componente que seja necessário para a sua implementação funcionar desde que este componente possa ser instalável via Nuget e esteja disponível na web.
- Esta camada não deve ser acessada diretamente pela API, qualquer acesso a esta camada deve ser feita pela camada de domínio.
- Esta camada não deve conter regras de negócio
- Siga os padrões de nome de migration MigrationX_Tabela_Criacao, MigrationX_Tabela_Alteracao, MigrationX_Tabela_Exclusao
- Para utilização dos migrations, no Visual Studio, utilize o Package Manager Console apontando para o projeto Impulse.Infra.Data. Os comandos podem ser consultados na documentação da Microsoft ou na pasta Docs.  
```


