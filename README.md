# Vendinha

Sistema simples para cadastro de clientes e controle de dívidas de uma vendinha.

## Funcionalidades

- Cadastro, edição, listagem e exclusão de clientes.
- Validação de CPF e verificação de CPF duplicado.
- Busca de clientes por nome.
- Paginação da lista de clientes.
- Cadastro de uma dívida aberta por cliente.
- Marcação de dívida como paga.
- Consulta das dívidas em uma janela independente.

## Estrutura da solução

A solução utiliza três camadas, cada uma em um projeto:

### Vendinha.Desktop

Projeto Windows Forms responsável por exibir as telas, ler os campos e mostrar mensagens. Não possui regras de negócio.

### Vendinha.Negocio

Biblioteca de classes que contém as entidades, os serviços, as validações e as regras do sistema.

### Vendinha.Dados

Biblioteca de classes que contém a conexão SQLite e os repositórios com comandos ADO.NET.

Referências entre projetos:

```text
Vendinha.Desktop -> Vendinha.Negocio
Vendinha.Desktop -> Vendinha.Dados
Vendinha.Dados -> Vendinha.Negocio
```

## Tecnologias e pacote NuGet

- C#
- .NET 8
- Windows Forms
- SQLite
- ADO.NET
- Microsoft.Data.Sqlite 10.0.15

O projeto não utiliza Entity Framework.

## Como executar

1. Abra `Vendinha.slnx` no Visual Studio.
2. Defina `Vendinha.Desktop` como projeto de inicialização.
3. Execute a solução com `F5` ou pelo botão de execução.
4. Na primeira execução, o banco e as tabelas serão criados automaticamente.

O projeto antigo de console não faz parte da arquitetura final.

## Arquivo do banco

O arquivo do banco é criado em:

```text
bin/Debug/net8.0-windows/database/vendinha.db
```

O caminho pode variar entre `Debug` e `Release`. O script de estrutura está em:

```text
database/schema.sql
```

## Regras de negócio

- Nome, CPF e data de nascimento são obrigatórios.
- O CPF é validado pelos dígitos verificadores.
- O CPF é armazenado somente com números.
- Não pode haver dois clientes com o mesmo CPF.
- O e-mail é opcional; quando informado, deve conter `@`.
- A data de nascimento não pode ser futura.
- O valor da dívida deve ser maior que zero.
- Um cliente pode ter várias dívidas em aberto.
- Um cliente com dívida em aberto não pode ser excluído.
- Ao pagar uma dívida, a situação muda para `Paga` e a data atual é registrada.
- Ao excluir um cliente, suas dívidas também são excluídas pelo relacionamento em cascata.

## Arquivos principais

- `Vendinha.Negocio/Entidades/Cliente.cs`
- `Vendinha.Negocio/Entidades/Divida.cs`
- `Vendinha.Negocio/Validacoes/ValidadorCpf.cs`
- `Vendinha.Negocio/Servicos/ClienteServico.cs`
- `Vendinha.Negocio/Servicos/DividaServico.cs`
- `Vendinha.Dados/Banco/BancoDados.cs`
- `Vendinha.Dados/Repositorios/ClienteRepositorio.cs`
- `Vendinha.Dados/Repositorios/DividaRepositorio.cs`
- `Vendinha.Desktop/FormsPrincipal.cs`
- `Vendinha.Desktop/FormsCadastroCliente.cs`
- `Vendinha.Desktop/FormsDividas.cs`
- `Vendinha.Desktop/FormsNovaDivida.cs`

## Mensagens de commit sugeridas

1. `Criar estrutura inicial da solução Vendinha`
2. `Implementar entidades e regras de negócio`
3. `Criar banco SQLite e repositórios`
4. `Implementar tela principal de clientes`
5. `Implementar cadastro e edição de clientes`
6. `Implementar controle de dívidas`
7. `Adicionar schema e documentação do projeto`
