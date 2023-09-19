
# AppFinanceiro

Esse projeto � uma pequena demonstra��o de conhecimentos sobre .NET, Postgres e principios b�sicos de Web Api.




## Stack utilizada

**Back-end:** C#

**ORM**: Entity Framework

**Banco de Dados**: PostgreSQL


## Rodando localmente

**Voc� precisar� do PostgreSQL, Visual Studio (ou Visual Studio Code) em sua m�quina para rodar este projeto.**

Clone o projeto

```bash
  git clone https://github.com/William-Gabriel-RL/AppFinanceiro.git
```

Abra o projeto no Visual Studio Code ou Visual Studio (Prefer�ncia)

Abra o appsettings.json e reconfigure a string "AppFinanceiro" para direcionar ao seu banco de dados. Exemplo:

```bash
   "Host = localhost; Port = 5432; Pooling = true; Database = AppFinanceiro; User Id=postgres; Password=password"
```

Em Data.Context abre o arquivo AppFinanceiroContext e modifique a ConnectionString em "OnConfiguring" para apontar para o mesmo banco de dados.

**No Visual Studio**

Abra o Console do Gerenciador de Pacotes e digite:

```bash
   Update-Database
```
Isso realizar� a migration no seu banco de dados. Ap�s isso basta rodar o projeto API e utilizar via swagger ou em um gerenciador de endpoints de sua prefer�ncia.

**No Visual Studio Code**

Abra o terminal e digite:
```bash
   dotnet ef database update
```
Ap�s isso navegue no terminal at� o diret�rio API e execute o comando:

```bash
    dotnet run
```


## Documenta��o da API

### POST api/people

  #### Realizar a cria��o de uma pessoa

  Request:
  ```
  {
    "name": "Carolina Rosa Marina Barros",
    "document": "569.679.155-76",
    "password": "senhaforte"
  }
  ```

  Response:
  ```
  {
    "idPeople": "4ca336a9-b8a5-4cc6-8ef8-a0a3b5b45ed7",
    "name": "Carolina Rosa Marina Barros",
    "document": "56967915576",
    "createdAt": "2022-08-01T14:30:41.203653",
    "updatedAt": "2022-08-01T14:30:41.203653"
  }
  ```

### POST api/people/:peopleId/accounts

  #### Realizar a cria��o de uma conta para uma pessoa.

  Request:
  ```
  {
    "branch": "001",
    "account": "2033392-5",
  }
  ```

  Response:
  ```
  {
    "idAccount": "b0a0ec35-6161-4ebf-bb4f-7cf73cf6448f",
    "branch": "001",
    "accountNumber": "2033392-5",
    "createdAt": "2022-08-01T14:30:41.203653",
    "updatedAt": "2022-08-01T14:30:41.203653"
  }
  ```

### GET api/people/:peopleId/accounts

  #### Realiza a listagem de todas as contas de uma pessoa

  Response:

  ```
  [
    {
      "idAccount": "48bb7773-8ccc-4686-83f9-79581a5e5cd8",
      "branch": "001",
      "accountNumber": "2033392-5",
      "createdAt": "2022-08-01T14:30:41.203653",
      "updatedAt": "2022-08-01T14:30:41.203653"
    }
  ]
  ```

### POST api/accounts/:accountId/cards

  #### Realiza a cria��o de um cart�o em uma conta.

  Request:
  ```
  {
    "type": "virtual",
    "number": "5179 7447 8594 6978",
    "cvv": "512"
  }
  ```

  Response:
  ```
  {
    "idCard": "b0a0ec35-6161-4ebf-bb4f-7cf73cf6448f",
    "type": "virtual",
    "number": "6978",
    "cvv": "512",
    "createdAt": "2022-08-01T14:30:41.203653",
    "updatedAt": "2022-08-01T14:30:41.203653"
  }
  ```

### GET api/accounts/:accountId/cards

  #### Realiza a listagem de todos os cart�es de uma conta.

  Response:
  ```
  {
    "idAccount": "48bb7773-8ccc-4686-83f9-79581a5e5cd8",
    "branch": "001",
    "accountNumber": "2033392-5",
    "cards": [
      {
        "idCard": "05a0ab2d-5ece-45b6-b7d3-f3ecce2713d5",
        "type": "physical",
        "number": "0423",
        "cvv": "231",
        "createdAt": "2022-08-01T14:30:41.203653",
        "updatedAt": "2022-08-01T14:30:41.203653"
      },
      {
        "idCard": "b0a0ec35-6161-4ebf-bb4f-7cf73cf6448f",
        "type": "virtual",
        "number": "2145",
        "cvv": "512",
        "createdAt": "2022-08-01T14:30:41.203653",
        "updatedAt": "2022-08-01T14:30:41.203653"
      }
    ],
    "createdAt": "2022-08-01T14:30:41.203653",
    "updatedAt": "2022-08-01T14:30:41.203653"
  }
  ```

### GET api/people/:peopleId/cards

  #### Realiza a listagem de todos os cart�es de uma pessoa.

  Response:
  ```
  {
    "cards": [
      {
        "idCard": "05a0ab2d-5ece-45b6-b7d3-f3ecce2713d5",
        "type": "physical",
        "number": "0423",
        "cvv": "231",
        "createdAt": "2022-08-01T14:30:41.203653",
        "updatedAt": "2022-08-01T14:30:41.203653"
      },
      {
        "idCard": "b0a0ec35-6161-4ebf-bb4f-7cf73cf6448f",
        "type": "virtual",
        "number": "6978",
        "cvv": "512",
        "createdAt": "2022-08-01T14:30:41.203653",
        "updatedAt": "2022-08-01T14:30:41.203653"
      }
    ],
    "pagination": {
      "itemsPerPage": 5,
      "currentPage": 1
    }
  }
  ```

### POST api/accounts/:accountId/transactions

  #### Realiza a cria��o de uma transa��o em uma conta.

  Request:
  ```
  {
    "value": 100.00,
    "description": "Venda do cimento para Clodson"
  }
  ```

  Response:
  ```
  {
    "idTransaction": "05a0ab2d-5ece-45b6-b7d3-f3ecce2713d5",
    "value": 100.00,
    "description": "Venda do cimento para Lucas",
    "createdAt": "2022-08-01T14:30:41.203653",
    "updatedAt": "2022-08-01T14:30:41.203653"
  }
  ```

### GET api/accounts/:accountId/transactions

  #### Listagem de todas as transa��es de uma conta, com pagina��o opcional via query parameters.

  Response:
  ```
  {
    "transactions": [
      {
        "idTransaction": "05a0ab2d-5ece-45b6-b7d3-f3ecce2713d5",
        "value": 100.00,
        "description": "Venda do cimento para Lucas.",
        "createdAt": "2022-08-01T14:30:41.203653",
        "updatedAt": "2022-08-01T14:30:41.203653"
      }
    ],
    "pagination": {
      "itemsPerPage": 5,
      "currentPage": 1
    }
  }
  ```

### GET api/accounts/:accountId/balance

  #### Retorna o saldo de uma conta.

  Response:
  ```
  {
    "balance": 100.00
  }
  ```

### POST api/accounts/:accountId/transactions/:transactionId/revert

  #### Realiza a revers�o de uma transa��o, portanto a a��o inversa deve ser realizada. Caso seja a transa��o seja de cr�dito, deve ser feito um d�bito e vice-versa.

  Response:
  ```
  {
    "idTransaction": "092ec73f-d7c3-4afb-bac0-9c7e8eb33eae",
    "value": 100.00,
    "description": "Estorno de cobran�a indevida.",
    "createdAt": "2022-08-01T14:30:41.203653",
    "updatedAt": "2022-08-01T14:30:41.203653"
  }
  ```