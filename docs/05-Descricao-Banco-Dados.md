#  Descrição do Banco de Dados

## Modelo de Dados

O sistema utiliza um banco de dados relacional implementado no **SQL Server Express**, com modelagem baseada nas entidades principais do domínio de uma locadora de veículos.

O modelo foi estruturado para garantir integridade dos dados e refletir corretamente os relacionamentos entre as entidades do sistema.

As principais entidades são:

- Fabricante
- CategoriaVeiculo
- Veiculo
- Cliente
- Aluguel

---

## Tabelas e Estrutura

### Fabricante

Armazena informações sobre os fabricantes dos veículos.

| Campo           | Tipo         | Descrição                     |
|----------------|--------------|------------------------------|
| IdFabricante   | int (PK)     | Identificador único          |
| Nome           | string       | Nome do fabricante           |
| PaisOrigem     | string       | País de origem               |

---

### CategoriaVeiculo

Define as categorias dos veículos e seus valores base.

| Campo               | Tipo         | Descrição                     |
|--------------------|--------------|------------------------------|
| IdCategoria        | int (PK)     | Identificador único          |
| Nome               | string       | Nome da categoria            |
| ValorDiariaBase    | decimal      | Valor base da diária         |

---

### Veiculo

Representa os veículos disponíveis para aluguel.

| Campo              | Tipo         | Descrição                          |
|-------------------|--------------|------------------------------------|
| IdVeiculo         | int (PK)     | Identificador único                |
| Modelo            | string       | Modelo do veículo                  |
| AnoFabricacao     | int          | Ano de fabricação                  |
| Quilometragem     | int          | Quilometragem atual                |
| Placa             | string       | Placa do veículo                   |
| Cor               | string       | Cor do veículo                     |
| Disponivel        | bool         | Indica se está disponível          |
| IdFabricante      | int (FK)     | Relacionamento com Fabricante      |
| IdCategoria       | int (FK)     | Relacionamento com Categoria       |

---

### Cliente

Armazena os dados dos clientes.

| Campo        | Tipo     | Descrição                     |
|-------------|----------|------------------------------|
| IdCliente   | int (PK) | Identificador único          |
| Nome        | string   | Nome do cliente              |
| Cpf         | string   | CPF do cliente               |
| Email       | string   | E-mail                       |
| Telefone    | string   | Telefone (opcional)          |

---

### Aluguel

Representa as operações de aluguel realizadas no sistema.

| Campo                     | Tipo         | Descrição                          |
|--------------------------|--------------|------------------------------------|
| IdAluguel                | int (PK)     | Identificador único                |
| DataRetirada             | datetime     | Data de início do aluguel          |
| DataPrevistaDevolucao    | datetime     | Data prevista para devolução       |
| DataDevolucao            | datetime     | Data real de devolução (opcional)  |
| QuilometragemInicial     | int          | Quilometragem no início            |
| QuilometragemFinal       | int          | Quilometragem no fim (opcional)    |
| ValorDiaria              | decimal      | Valor da diária                    |
| ValorTotal               | decimal      | Valor total do aluguel             |
| Status                   | string       | Status do aluguel                  |
| IdCliente                | int (FK)     | Relacionamento com Cliente         |
| IdVeiculo                | int (FK)     | Relacionamento com Veículo         |

---

## Relacionamentos

O modelo de dados apresenta os seguintes relacionamentos:

- **Fabricante 1:N Veiculo**  
  Um fabricante pode estar associado a vários veículos.

- **CategoriaVeiculo 1:N Veiculo**  
  Uma categoria pode conter vários veículos.

- **Cliente 1:N Aluguel**  
  Um cliente pode realizar vários aluguéis.

- **Veiculo 1:N Aluguel**  
  Um veículo pode ser alugado diversas vezes ao longo do tempo.

---

## Restrições de Integridade

Para garantir a consistência dos dados, foram aplicadas as seguintes restrições:

- **Chaves Primárias (PK)** em todas as tabelas
- **Chaves Estrangeiras (FK)** para garantir os relacionamentos:
  - Veiculo → Fabricante
  - Veiculo → CategoriaVeiculo
  - Aluguel → Cliente
  - Aluguel → Veiculo

- **Campos obrigatórios** definidos através de validações (`NOT NULL`)
- Controle de disponibilidade de veículos através do campo `Disponivel`

---

## Exemplos de Consultas SQL

A seguir, alguns exemplos de consultas relevantes para o sistema:

---

### Listar veículos com fabricante e categoria

```sql
SELECT v.Modelo, v.Placa, f.Nome AS Fabricante, c.Nome AS Categoria
FROM Veiculos v
INNER JOIN Fabricantes f ON v.IdFabricante = f.IdFabricante
INNER JOIN CategoriasVeiculo c ON v.IdCategoria = c.IdCategoria;
```
### Buscar veículos disponíveis por categoria

```sql
SELECT v.Modelo, v.Placa
FROM Veiculos v
INNER JOIN CategoriasVeiculo c ON v.IdCategoria = c.IdCategoria
WHERE v.Disponivel = 1 AND c.IdCategoria = 1;
```

### Listar aluguéis com cliente e veículo

```sql
SELECT a.IdAluguel, c.Nome AS Cliente, v.Modelo, a.DataRetirada, a.ValorTotal
FROM Alugueis a
INNER JOIN Clientes c ON a.IdCliente = c.IdCliente
INNER JOIN Veiculos v ON a.IdVeiculo = v.IdVeiculo;
```

### Listar aluguéis em aberto
```sql
SELECT *
FROM Alugueis
WHERE DataDevolucao IS NULL;
```

### Veículos com ou sem histórico de aluguel (LEFT JOIN)

```sql
SELECT v.Modelo, a.IdAluguel
FROM Veiculos v
LEFT JOIN Alugueis a ON v.IdVeiculo = a.IdVeiculo;
```

## Considerações

<p align="justify">O modelo de dados foi projetado de forma a refletir as regras de negócio da locadora, garantindo integridade, organização e facilidade de manutenção.</p>
<p align="justify">A utilização de relacionamentos bem definidos e consultas com joins permite a recuperação eficiente de dados, possibilitando a construção de funcionalidades mais completas e realistas dentro da aplicação.</p>
