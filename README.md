# Car Rental API | ASP.NET Core Web API + SQL Server

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=flat&logo=dotnet&logoColor=white)
![SQL Server](https://img.shields.io/badge/SQL_Server-CC2927?style=flat&logo=microsoftsqlserver&logoColor=white)

<p align="justify">API REST desenvolvida em C# com ASP.NET Core para gerenciamento de uma locadora de veículos, integrada ao SQL Server por meio do Entity Framework Core. O sistema contempla operações CRUD, aplicação de regras de negócio e consultas avançadas com JOINs entre tabelas, simulando um cenário real de backend..</p>
<p align="justify">O sistema permite o controle de fabricantes, categorias, veículos, clientes e aluguéis, com tratamento de relacionamentos entre entidades, validações de integridade e documentação de endpoints via Swagger.</p>

---

## 🛠️ Tecnologias

- C#
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server Express
- Swagger (OpenAPI)

---

## 🚀 Funcionalidades

### 📦 Gerenciamento de Entidades

- Cadastro de fabricantes
- Cadastro de categorias de veículos
- Cadastro de veículos
- Cadastro de clientes
- Registro de aluguéis

### 🔄 Operações CRUD

- Criar registros
- Listar dados
- Buscar por ID
- Atualizar informações
- Remover registros

### ⚙️ Regras de Negócio

- Um veículo só pode ser alugado se estiver disponível
- Ao registrar um aluguel, o veículo se torna indisponível
- Ao remover um aluguel, o veículo volta a ficar disponível
- Validação de existência de entidades relacionadas (FKs)
- Validação de CPF e e-mail únicos para clientes

### 🔍 Filtros e Consultas (Joins)

- Listar veículos com fabricante e categoria
- Buscar veículos disponíveis por categoria
- Listar veículos com histórico de aluguel (LEFT JOIN)
- Buscar aluguéis por cliente
- Buscar aluguéis por veículo
- Listar aluguéis em aberto

## Documentação Completa

As etapas detalhadas do projeto podem ser acessadas abaixo:

- [Documentos](docs/01-Introducao.md)
---

## 📦 Estrutura do Projeto

- Controllers
- Models
- Data (DbContext)
- Migrations
- Configuração (Program.cs / appsettings.json)

## 🔗 Endpoints Principais

### Veículos

| Método | Rota                                           | Descrição                         |
|--------|------------------------------------------------|----------------------------------|
| GET    | /api/veiculos                                  | Lista todos os veículos          |
| GET    | /api/veiculos/{id}                             | Busca veículo por ID             |
| GET    | /api/veiculos/com-detalhes                     | Veículos com fabricante e categoria |
| GET    | /api/veiculos/disponiveis-por-categoria/{id}   | Veículos disponíveis por categoria |
| GET    | /api/veiculos/com-historico-aluguel            | Veículos com histórico (LEFT JOIN) |
| POST   | /api/veiculos                                  | Cria um veículo                  |
| PUT    | /api/veiculos/{id}                             | Atualiza veículo                 |
| DELETE | /api/veiculos/{id}                             | Remove veículo                   |

---

### Aluguéis

| Método | Rota                                  | Descrição                          |
|--------|----------------------------------------|-----------------------------------|
| GET    | /api/alugueis                          | Lista todos os aluguéis           |
| GET    | /api/alugueis/{id}                     | Busca aluguel por ID              |
| GET    | /api/alugueis/por-cliente/{id}         | Aluguéis de um cliente            |
| GET    | /api/alugueis/por-veiculo/{id}         | Aluguéis de um veículo            |
| GET    | /api/alugueis/em-aberto                | Aluguéis em aberto                |
| POST   | /api/alugueis                          | Cria um aluguel                   |
| PUT    | /api/alugueis/{id}                     | Atualiza aluguel                  |
| DELETE | /api/alugueis/{id}                     | Remove aluguel                    |

---

## 📄 Exemplo de Aluguel (JSON)

Outros exemplos de requisições estão disponíveis nos [Apendices](docs/10-Apendices.md).

```json
{
  "idAluguel": 0,
  "dataRetirada": "2026-04-12T10:00:00",
  "dataPrevistaDevolucao": "2026-04-15T10:00:00",
  "dataDevolucao": null,
  "quilometragemInicial": 25000,
  "quilometragemFinal": null,
  "valorDiaria": 150.00,
  "valorTotal": 450.00,
  "status": "Ativo",
  "idCliente": 1,
  "idVeiculo": 1
}
```
## Como Executar

1. Clone o repositório:  
   ```bash
   git clone <URL_DO_REPOSITORIO>
2. Abra a solução no Visual Studio
3. Configure a string de conexão com o SQL Server no arquivo appsettings.json (caso necessário)
4. Execute o projeto

O Swagger será aberto automaticamente no navegador. Caso não abra, acesse manualmente:

   ```bash
   https://localhost:xxxx/swagger
   ```

## Testes
Os endpoints estão em fase de testes via Swagger, com validação contínua de operações CRUD e consultas com JOINs.
