# Implementação Técnica

##  Tecnologias Utilizadas

A implementação do sistema foi realizada utilizando tecnologias modernas do ecossistema .NET, garantindo desempenho, organização e escalabilidade da aplicação.

As principais tecnologias utilizadas foram:

- **C# (.NET 6 ou superior)**  
  Linguagem principal utilizada no desenvolvimento do backend.

- **ASP.NET Core Web API**  
  Framework utilizado para criação da API REST, responsável por gerenciar as requisições HTTP e estruturar os endpoints da aplicação.

- **Entity Framework Core (EF Core)**  
  ORM (Object-Relational Mapper) utilizado para realizar a comunicação com o banco de dados, permitindo manipulação de dados através de objetos.

- **SQL Server Express**  
  Sistema de gerenciamento de banco de dados relacional utilizado para armazenamento das informações.

- **Swagger (Swashbuckle)**  
  Ferramenta utilizada para documentação e testes dos endpoints da API, permitindo visualização e execução das requisições de forma interativa.

---

##  Estrutura e Principais Classes

A aplicação foi estruturada seguindo uma arquitetura baseada em separação de responsabilidades, com organização em camadas.

### 📁 Models

Responsáveis por representar as entidades do sistema e mapear as tabelas do banco de dados.

Principais classes:

- **Fabricante**  
  Representa o fabricante do veículo, contendo informações como nome e país de origem.

- **CategoriaVeiculo**  
  Define a categoria do veículo e o valor base da diária.

- **Veiculo**  
  Representa os veículos disponíveis para aluguel, contendo informações como modelo, placa, quilometragem e relacionamento com fabricante e categoria.

- **Cliente**  
  Armazena os dados dos clientes, como nome, CPF, e-mail e telefone.

- **Aluguel**  
  Representa as operações de aluguel, relacionando cliente e veículo, além de armazenar informações como datas, valores e status.

---

### 📁 Data

- **AppDbContext**  
  Classe responsável pela configuração do Entity Framework e mapeamento das entidades para o banco de dados.  
  Contém os `DbSet` de cada entidade e gerencia a conexão com o SQL Server.

---

### 📁 Controllers

Responsáveis por expor os endpoints da API e controlar o fluxo das requisições.

Principais controllers:

- **FabricantesController**
- **CategoriasVeiculoController**
- **VeiculosController**
- **ClientesController**
- **AlugueisController**

Cada controller implementa operações de CRUD (Create, Read, Update, Delete) e, em alguns casos, consultas específicas com uso de joins entre entidades.

---

##  Decisões de Design e Padrões Utilizados

Durante o desenvolvimento, foram adotadas algumas boas práticas e decisões de design para garantir a qualidade do código:

### 🔹 API RESTful

A API foi construída seguindo os princípios REST, utilizando:
- Métodos HTTP apropriados (GET, POST, PUT, DELETE)
- Rotas organizadas por recurso
- Respostas padronizadas

---

### 🔹 Uso de ORM (Entity Framework Core)

A escolha do EF Core permitiu:

- Redução de código SQL manual
- Maior produtividade no desenvolvimento
- Facilidade na manutenção e evolução do sistema

---

### 🔹 Separação de Responsabilidades

O projeto foi estruturado em camadas distintas:

- **Models** → representação dos dados  
- **Data** → acesso ao banco  
- **Controllers** → lógica de requisições  

Essa separação facilita:
- manutenção
- leitura do código
- escalabilidade

---

### 🔹 Validação de Dados

Foram aplicadas validações utilizando:

- Data Annotations (`[Required]`, `[Key]`, etc.)
- Verificações manuais nos controllers

Garantindo:
- integridade dos dados
- prevenção de inconsistências

---

### 🔹 Consultas com Joins

Foram implementadas consultas utilizando:

- **Inner Join** (junção direta entre tabelas)
- **Left Join** (utilizando `DefaultIfEmpty()`)

Essas consultas permitem:
- recuperar dados relacionados
- construir respostas mais completas para a API

---

### 🔹 Uso do Swagger

O Swagger foi integrado à aplicação para:

- Documentar automaticamente os endpoints
- Facilitar testes durante o desenvolvimento
- Melhorar a experiência de uso da API

---

## Considerações Técnicas

<p align="justify">A implementação priorizou simplicidade e clareza, mantendo uma estrutura organizada e de fácil compreensão, ao mesmo tempo em que aplica conceitos importantes de desenvolvimento backend, como APIs REST, ORM, validação de dados e integração com banco relacional.</p>

<p align="justify">Essa abordagem permite que o sistema seja facilmente expandido, possibilitando futuras melhorias como autenticação, controle de permissões e integração com interfaces frontend.</p>
