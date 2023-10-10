# Agenda Médica em MVC com .NET Core

Este é um projeto de Agenda Médica desenvolvido em MVC (Model-View-Controller) com .NET Core. Ele permite o cadastro de clientes, médicos e agendamento de consultas, tudo isso utilizando o banco de dados Oracle e o Entity Framework.

## Pré-requisitos

Certifique-se de que você possui os seguintes pré-requisitos instalados:

- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Oracle Database](https://www.oracle.com/database/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

## Configuração do Banco de Dados

Antes de executar o projeto, você precisará configurar a conexão com o banco de dados Oracle. Abra o arquivo `appsettings.json` e substitua a seção de conexão com o banco de dados com suas próprias credenciais:

```json
"ConnectionStrings": {
  "DefaultConnection": "sua_string_de_conexao_aqui"
}
